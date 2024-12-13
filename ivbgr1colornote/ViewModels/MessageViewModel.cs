using Avalonia.Media;

namespace ivbgr1colornote.ViewModels;

public class MessageViewModel : ViewModelBase
{
    public string Content { get; set; }
    public IBrush Color { get; set; }
    public string Info { get; set; }
}