using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsOfRussia.ViewModel
{
    public class AbsenceModel
    {
        public int Id { get; set; }

        public int IdEmployee { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public DateTime? VacantionUntil { get; set; }

        public DateTime? BusinessTripUntil { get; set; }
    }
}
