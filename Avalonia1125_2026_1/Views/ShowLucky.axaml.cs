using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia1125_2026_1.Models;
using Avalonia1125_2026_1.ViewModels;

namespace Avalonia1125_2026_1.Views;

public partial class ShowLucky : Window
{
    public ShowLucky(List<Human> humans)
    {
        InitializeComponent();
        DataContext = new LuckyViewModel(
            humans, 
            ()=>Close()
            );
    }
}