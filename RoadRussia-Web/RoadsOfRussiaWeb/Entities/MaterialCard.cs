using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class MaterialCard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfApproval { get; set; }

    public DateOnly DateOfChange { get; set; }

    public int? IdStatus { get; set; }

    public string? Type { get; set; }

    public string? Area { get; set; }

    public int? IdAuthor { get; set; }

    public virtual Employee? IdAuthorNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }
}
