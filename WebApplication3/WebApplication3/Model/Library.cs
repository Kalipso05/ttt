using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Model
{
    public class Library
    {
        public int Id { get; set; }

        public string DocumentSection { get; set; }

        public string Name { get; set; }

        public string PathToDocument { get; set; }
    }
}