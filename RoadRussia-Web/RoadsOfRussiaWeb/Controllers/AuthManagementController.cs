using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using RoadsOfRussiaWeb.Configuration;
using System.Text;
using RoadsOfRussiaWeb.Models;
using RoadsOfRussiaWeb.Entities;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly JwtConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthManagementController(IOptionsMonitor<JwtConfig> optionsMonitor, TokenValidationParameters tokenValidationParameters)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
            _tokenValidationParameters = tokenValidationParameters;
        }

        private static string ComputeSHA256Hash(string text)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if(ModelState.IsValid)
            {
                using (var db = new DbRoadContext())
                {
                    var existingUser = await db.Employees.FirstOrDefaultAsync(c => c.Login == user.Login);
                    
                    if (existingUser == null)
                    {
                        return BadRequest(new ResultResponse()
                        {
                            Success = false,
                            Errors = new List<string>()
                            {
                                "Invalid authentication request"
                            }
                        });
                    }

                    var isCorrect = existingUser.Password == user.Password;
                    if (isCorrect)
                    {
                        return Ok(await GenerateJwtToken(existingUser));
                    }
                    else
                    {
                        //если нет, то ошибку
                        return BadRequest(new ResultResponse()
                        {
                            Success = false,
                            Errors = new List<string>()
                        {
                            "Invalid authentication request"
                        }
                        });
                    }
                }
            }
            return BadRequest(new ResultResponse()
            {
                Success = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }


        private async Task<ResultResponse> GenerateJwtToken(Employee user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            //использование ключа для шифрации
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            //данные токена
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Login", user.Login),
                    new Claim(JwtRegisteredClaimNames.Sub, $"{user.Surname} {user.Name} {user.MiddleName}"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.Add(_jwtConfig.ExpiryTimeFrame),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            //получение токена
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            //запись токена
            var jwtToken = jwtTokenHandler.WriteToken(token);
            //генерация рефреш токена
            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                IsUsed = false,
                IdUser = user.Id,
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddYears(1),
                IsRevoked = false,
                Token = RandomString(25) + Guid.NewGuid()
            };

            //Сохранение токена в БД
            //await _apiDbContext.RefreshTokens.AddAsync(refreshToken);
            //await _apiDbContext.SaveChangesAsync();
            //возврат токенов
            return new ResultResponse()
            {
                Token = jwtToken,
                Success = true,
                RefreshToken = refreshToken.Token
            };
        }

        private string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }
    }
}
