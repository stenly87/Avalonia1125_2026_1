using System;
using System.Collections.Generic;

namespace Avalonia1125_2026_1.Models;

public class Duty : BaseModel
{
    public DateTime Date { get; set; } = DateTime.Now;
    public List<int> HumanIds { get; set; } = new List<int>();
}