﻿using System;
using System.Collections.Generic;

namespace DbFirstApproachProject.Models;

public partial class StudentCard
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public virtual Student? Student { get; set; }
}
