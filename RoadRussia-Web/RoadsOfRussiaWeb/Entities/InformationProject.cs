using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class InformationProject
{
    public int Id { get; set; }

    public string NameProject { get; set; } = null!;

    public int IdDirectorProject { get; set; }

    public DateOnly StartProject { get; set; }

    public DateOnly EndProject { get; set; }

    public int DeviationOfDeadline { get; set; }

    public int IdDevelopmentStage { get; set; }

    public virtual DevelopmentStage IdDevelopmentStageNavigation { get; set; } = null!;

    public virtual Employee IdDirectorProjectNavigation { get; set; } = null!;
}
