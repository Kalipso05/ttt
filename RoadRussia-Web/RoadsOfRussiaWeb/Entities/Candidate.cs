using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class Candidate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string PathToResume { get; set; } = null!;
}
