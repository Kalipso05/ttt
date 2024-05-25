using RoadsOfRussiaWeb.Entities;

namespace RoadsOfRussiaWeb.Models
{
    public class AbsenceResponse
    {
        public int Id { get; set; }

        public int IdEmployee { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }

        public DateTime? VacantionUntil { get; set; }

        public DateTime? BusinessTripUntil { get; set; }

        public AbsenceResponse(TemporaryAbsenceEmployee temporary)
        {
            Id = temporary.Id;
            IdEmployee = temporary.IdEmployee;
            Name = temporary.IdEmployeeNavigation.Name;
            Surname = temporary.IdEmployeeNavigation.Surname;
            MiddleName = temporary.IdEmployeeNavigation.MiddleName;
            VacantionUntil = temporary.VacantionUntil;
            BusinessTripUntil = temporary.BusinessTripUntil;
        }

    }
}
