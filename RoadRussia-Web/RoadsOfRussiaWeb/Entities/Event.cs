using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class Event
{
    public int Id { get; set; }

    public string NameEvent { get; set; } = null!;

    public int IdTypeEvent { get; set; }

    public int IdStatusEvent { get; set; }

    public DateTime DateTimeEvent { get; set; }

    public string Description { get; set; } = null!;

    public int? IdEmployee { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual Status IdStatusEventNavigation { get; set; } = null!;

    public virtual TypeEvent IdTypeEventNavigation { get; set; } = null!;
}
