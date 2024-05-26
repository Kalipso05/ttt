using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class DevelopmentStage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int IdStatus { get; set; }

    public virtual ICollection<InformationProject> InformationProjects { get; set; } = new List<InformationProject>();
}
