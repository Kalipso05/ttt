using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class TemporaryAbsenceEmployee
{
    public int Id { get; set; }

    public int IdEmployee { get; set; }

    public DateTime? VacantionUntil { get; set; }

    public DateTime? BusinessTripUntil { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;
}
