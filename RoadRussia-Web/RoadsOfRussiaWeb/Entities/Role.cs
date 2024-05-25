﻿using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}