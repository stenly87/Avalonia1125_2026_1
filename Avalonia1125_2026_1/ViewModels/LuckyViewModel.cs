using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia1125_2026_1.Models;
using Avalonia1125_2026_1.Models.DB;
using Avalonia1125_2026_1.ViewModels.Utils;

namespace Avalonia1125_2026_1.ViewModels;

public class LuckyViewModel : INotifyPropertyChanged
{
    private readonly Action _closeWindow;
    public List<Human> Humans { get; }
    public ICommand Confirm { get; }
    public LuckyViewModel(List<Human> humans, Action closeWindow)
    {
        _closeWindow = closeWindow;
        Humans  = humans;
        Confirm = new RelayCommand(ConfirmExecute);
    }

    private void ConfirmExecute()
    {
        DB.CreateDuty(Humans);
        _closeWindow();
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