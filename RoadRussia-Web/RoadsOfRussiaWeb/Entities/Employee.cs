using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public byte[]? Photo { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? MiddleName { get; set; }

    public int IdStructuralDivision { get; set; }

    public int IdJobTitle { get; set; }

    public string Cabinet { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string WorkPhone { get; set; } = null!;

    public string? Director { get; set; }

    public string? AsssistantDirector { get; set; }

    public string? OtherInformation { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? Idrole { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual JobTitle IdJobTitleNavigation { get; set; } = null!;

    public virtual StructuralDivision IdStructuralDivisionNavigation { get; set; } = null!;

    public virtual Role? IdroleNavigation { get; set; }

    public virtual ICollection<InformationProject> InformationProjects { get; set; } = new List<InformationProject>();

    public virtual ICollection<MaterialCard> MaterialCards { get; set; } = new List<MaterialCard>();

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual ICollection<TemporaryAbsenceEmployee> TemporaryAbsenceEmployees { get; set; } = new List<TemporaryAbsenceEmployee>();
}
