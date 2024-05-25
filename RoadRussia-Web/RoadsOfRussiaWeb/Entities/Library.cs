using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class Library
{
    public int Id { get; set; }

    public int IdDocumentSection { get; set; }

    public string Name { get; set; } = null!;

    public string? PathToDocument { get; set; }

    public byte[]? DocumentFile { get; set; }

    public virtual DocumentSection IdDocumentSectionNavigation { get; set; } = null!;
}
