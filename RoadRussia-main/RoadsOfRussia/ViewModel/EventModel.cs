using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsOfRussia.ViewModel
{
    public class EventModel
    {
        public int Id { get; set; }

        public string NameEvent { get; set; }

        public string TypeEvent { get; set; }
        public int IdTypeEvent { get; set; }

        public string StatusEvent { get; set; }

        public DateTime DateTimeEvent { get; set; }

        public string Description { get; set; }
        public string NameEmployee { get; set; }
        public string Email { get; set; }
    }
}
