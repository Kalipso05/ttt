using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsOfRussia.ViewModel
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string NameProject { get; set; }

        public int IdDirectorProject { get; set; }
        public string DirectorProject { get; set; }

        public DateTime StartProject { get; set; }

        public DateTime EndProject { get; set; }

        public int DeviationOfDeadline { get; set; }

        public int IdDevelopmentStage { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }
    }
}
