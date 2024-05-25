namespace RoadsOfRussiaWeb.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int IdUser { get; set; } // Привязан к идентификатору пользователя AspNet Identity
        public string Token { get; set; }
        public string JwtId { get; set; } // Сопоставьте токен с jwtId
        public bool IsUsed { get; set; } // если он используется, мы не хотим генерировать новый токен Jwt с тем же токеном обновления
        public bool IsRevoked { get; set; } // если он был отозван по соображениям безопасности
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; } // Токен обновления является долговечным, его может хватить на несколько месяцев.
    }
}
