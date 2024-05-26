using RoadsOfRussiaWeb.Entities;

namespace RoadsOfRussiaWeb.Models
{
    public class InformationProjectResponse
    {
        public int Id { get; set; }

        public string NameProject { get; set; } = null!;

        public int IdDirectorProject { get; set; }
        public string DirectorProject { get; set; }

        public DateOnly StartProject { get; set; }

        public DateOnly EndProject { get; set; }

        public int DeviationOfDeadline { get; set; }

        public int IdDevelopmentStage { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Status { get; set; }

        public InformationProjectResponse(InformationProject informationProject)
        {
            Id = informationProject.Id;
            NameProject = informationProject.NameProject;
            IdDirectorProject = informationProject.IdDirectorProject;
            DirectorProject = $"{informationProject.IdDirectorProjectNavigation.Surname} {informationProject.IdDirectorProjectNavigation.Name} {informationProject.IdDirectorProjectNavigation.MiddleName}";
            StartProject = informationProject.StartProject;
            EndProject = informationProject.EndProject;
            DeviationOfDeadline = informationProject.DeviationOfDeadline;
            IdDevelopmentStage = informationProject.IdDevelopmentStage;

            Name = informationProject.IdDevelopmentStageNavigation.Name;
            Description = informationProject.IdDevelopmentStageNavigation.Description;
            StartDate = informationProject.IdDevelopmentStageNavigation.StartDate;
            EndDate = informationProject.IdDevelopmentStageNavigation.EndDate;
            Status = "Завершен";

        }
    }
}
