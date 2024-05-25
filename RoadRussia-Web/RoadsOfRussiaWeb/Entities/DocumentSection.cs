using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class DocumentSection
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();
}
