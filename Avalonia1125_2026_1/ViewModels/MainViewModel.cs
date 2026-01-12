using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia1125_2026_1.Models;
using Avalonia1125_2026_1.Models.DB;
using Avalonia1125_2026_1.ViewModels.Utils;
using Avalonia1125_2026_1.Views;

namespace Avalonia1125_2026_1.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public List<Human> Humans { get; }
    public ICommand SelectDutyMan { get; }

    public MainViewModel()
    {
        DB.Load();
        Humans = DB.Humans;

        SelectDutyMan = new RelayCommand(SelectDutyExecute);
    }

    private void SelectDutyExecute()
    {
        List<Human> luckys;
        //что делать, если все болеют, или здоров только один
        int checkNotIll = Humans.Where(s => !s.Illness).Count();
        if (checkNotIll < 2)
            luckys = DB.Humans.Where(s => s.FirstName == "Захар").ToList();
        else
            luckys =
                Humans.Where(s => !s.Illness).OrderBy(s => s.DutyCount).Take(2).ToList();

        ShowLucky win = new ShowLucky(luckys);
        win.Show();
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}