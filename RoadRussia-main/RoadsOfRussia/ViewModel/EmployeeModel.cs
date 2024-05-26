using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsOfRussia.ViewModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string StructuralDivision { get; set; }
        public int IdStructuralDivision { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string JobTitle { get; set; }
        public int IdJobTitle { get; set; }

        public string Cabinet { get; set; }

        public string Email { get; set; }
        public string WorkPhone { get; set; }
        public string Phone { get; set; }

        public string Director { get; set; }

        public string AsssistantDirector { get; set; }

        public string OtherInformation { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
