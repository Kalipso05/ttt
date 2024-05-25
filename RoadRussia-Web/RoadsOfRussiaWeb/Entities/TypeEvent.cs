using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class TypeEvent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
