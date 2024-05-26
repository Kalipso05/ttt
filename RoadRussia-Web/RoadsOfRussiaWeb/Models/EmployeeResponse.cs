using RoadsOfRussiaWeb.Entities;

namespace RoadsOfRussiaWeb.Models
{
    public class EmployeeResponse
    {
        public int Id { get; set; }

        public byte[]? Photo { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? MiddleName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public string StructuralDivision { get; set; }
        public int IdStructuralDivision {  get; set; }

        public string JobTitle { get; set; }
        public int IdJobTitle { get; set; }

        public string Cabinet { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string WorkPhone { get; set; } = null!;
        public string? Phone { get; set; }

        public string? Director { get; set; }

        public string? AsssistantDirector { get; set; }

        public string? OtherInformation { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public EmployeeResponse(Employee employee)
        {
            Id = employee.Id;
            Photo = employee.Photo;
            Name = employee.Name;
            Surname = employee.Surname;
            MiddleName = employee.MiddleName;
            StructuralDivision = employee.IdStructuralDivisionNavigation.Title;
            JobTitle = employee.IdJobTitleNavigation.Title;
            IdJobTitle = employee.IdJobTitle;
            IdStructuralDivision = employee.IdStructuralDivision;
            Cabinet = employee.Cabinet;
            Email = employee.Email;
            WorkPhone = employee.WorkPhone;
            Phone = employee.Phone;
            Director = employee.Director;
            AsssistantDirector = employee.AsssistantDirector;
            OtherInformation = employee.OtherInformation;
            DateOfBirth = employee.DateOfBirth;
            Login = employee.Login;
            Password = employee.Password;
            
        }
    }
}
