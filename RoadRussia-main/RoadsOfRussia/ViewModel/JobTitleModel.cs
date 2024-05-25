using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsOfRussia.ViewModel
{
    public class JobTitleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int IdStructuralDivision { get; set; }
        public string StructuralDivision { get; set; }
    }
}
