using System.Text.Json.Serialization;

namespace Avalonia1125_2026_1.Models;

public class Human : BaseModel
{
    public string FirstName { get; set; } = "Захар";
    public string LastName { get; set; } = "Цуренко";
    
    [JsonIgnore]
    public int DutyCount { get; set; }
}