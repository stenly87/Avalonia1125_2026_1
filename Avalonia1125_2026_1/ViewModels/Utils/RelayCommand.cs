using System;
using System.Windows.Input;

namespace Avalonia1125_2026_1.ViewModels.Utils;

public class RelayCommand :  ICommand
{
    private Action action;

    public RelayCommand(Action action)
    {
        this.action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        action();
    }

    public event EventHandler? CanExecuteChanged;
}