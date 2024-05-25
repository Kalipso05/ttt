using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class News
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateNews { get; set; }

    public int IdAuthor { get; set; }

    public string Description { get; set; } = null!;

    public virtual Employee IdAuthorNavigation { get; set; } = null!;
}
