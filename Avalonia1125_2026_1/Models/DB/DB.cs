using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Avalonia1125_2026_1.Models.DB;

public static class DB
{
    public static List<Human> Humans { get; set; }
    public static List<Duty> Dutys { get; set; }

    public static void Save()
    {
        using var humansFile = File.Create("humans.json");
        JsonSerializer.Serialize(humansFile, Humans);
        
        using var  dutysFile = File.Create("duties.json");
        JsonSerializer.Serialize(dutysFile, Dutys);
    }

    public static void Load()
    {
        if (File.Exists("humans.json"))
        {
            using var humansFile = File.OpenRead("humans.json");
            Humans = JsonSerializer.Deserialize<List<Human>>(humansFile);
        }
        else
        {
            Humans = new List<Human>();
            Humans.Add(new Human { FirstName = "Имя", LastName = "Фамилия" });
        }

        if (File.Exists("duties.json"))
        {
            using var dutiesFile = File.OpenRead("duties.json");
            Dutys = JsonSerializer.Deserialize<List<Duty>>(dutiesFile);

            foreach (var human in Humans)
            {
                human.DutyCount = Dutys.Count(s => s.HumanIds.Contains(s.Id));
            }
        }
        else
        {
            Dutys = new List<Duty>();
        }
    }

    public static void CreateDuty(List<Human> humans)
    {
        int nextID = Dutys.Max(s=>s.Id) + 1;
        Duty duty = new Duty
        {
            Id = nextID, 
            HumanIds = humans.Select(s => s.Id).ToList()
        };
        foreach (var human in humans)
            human.DutyCount++;
        Dutys.Add(duty);
        Save();
    }
}