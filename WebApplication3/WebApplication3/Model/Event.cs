using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Model
{
    public class Event
    {
        public int Id { get; set; }

        public string NameEvent { get; set; }

        public string TypeEvent { get; set; }

        public string StatusEvent { get; set; }

        public DateTime DateTimeEvent { get; set; }

        public string Description { get; set; }
    }
}