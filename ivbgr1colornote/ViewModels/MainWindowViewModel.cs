using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Windows.Input;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ivbgr1colornote.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _newMessage;
    [ObservableProperty] private IBrush _selectedColor = Brushes.Black;

    public ObservableCollection<IBrush> Colors { get; } =
    [
        Brushes.Black,
        Brushes.Red,
        Brushes.Orange,
        Brushes.Yellow
    ];
  
    public ICommand AddColorCommand { get; }

    public MainWindowViewModel()
    {
        AddColorCommand = new RelayCommand(AddMessage);
    }

    private void AddMessage()
    {
        var message = new MessageViewModel
        {
            
        }
    }

}