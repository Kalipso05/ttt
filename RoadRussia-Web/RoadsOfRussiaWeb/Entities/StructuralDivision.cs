using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class StructuralDivision
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<JobTitle> JobTitles { get; set; } = new List<JobTitle>();
}
