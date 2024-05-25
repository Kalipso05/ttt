using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class JobTitle
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? IdStructuralDivision { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual StructuralDivision? IdStructuralDivisionNavigation { get; set; }
}
