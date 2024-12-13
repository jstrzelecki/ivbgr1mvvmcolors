using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Windows.Input;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tmds.DBus.Protocol;

namespace ivbgr1colornote.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _newMessage;
    [ObservableProperty] private IBrush _selectedColor = Brushes.Black;
    public ObservableCollection<MessageViewModel> Messages { get; set; } = [];
    public ObservableCollection<IBrush> Colors { get; } =
    [
        Brushes.Black,
        Brushes.Red,
        Brushes.Orange,
        Brushes.Yellow
    ];
  
    public ICommand AddMessageCommand { get; }

    public MainWindowViewModel()
    {
        AddMessageCommand = new RelayCommand(AddMessage, CanAddMessages);
    }

    private void AddMessage()
    {
        var message = new MessageViewModel
        {
            Content = NewMessage,
            Color = SelectedColor,
            Info = $"Liczba znaków: {NewMessage.Length}, Liczba słów: {NewMessage.Split(' ').Length}"
        };
        Messages.Add(message);
        NewMessage = string.Empty;
    }

    private bool CanAddMessages() => !string.IsNullOrWhiteSpace(NewMessage);

    partial void OnNewMessageChanged(string v)
    {
       ((RelayCommand)AddMessageCommand).NotifyCanExecuteChanged(); 
    }
    
}