using RoadsOfRussiaWeb.Entities;

namespace RoadsOfRussiaWeb.Models
{
    public class JobTitleResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int? IdStructuralDivision { get; set; }
        public string? StructuralDivision { get; set; }

        public JobTitleResponse(JobTitle jobTitle)
        {
            Id = jobTitle.Id;
            Title = jobTitle.Title;
            IdStructuralDivision = jobTitle.IdStructuralDivision;
            StructuralDivision = jobTitle.IdStructuralDivisionNavigation?.Title;
        }
    }
}
