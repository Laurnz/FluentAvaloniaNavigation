using System.Windows.Input;
using ReactiveUI;

namespace AvaloniaNavigation.ViewModels;

public class HomeViewModel : ViewModelBase, IRoutableViewModel
{
    private MainWindowViewModel mainWindow;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    public IScreen HostScreen { get; }

    public ICommand NavigateToAboutPage { get; }
    
    public HomeViewModel(MainWindowViewModel screen)
    {
        mainWindow = screen;
        HostScreen = screen;

        NavigateToAboutPage = ReactiveCommand.Create(Navigate);
    }
    
    public void Navigate()
    {
        mainWindow.CurrentRoute = MainWindowViewModel.Routes.About;
    }
}
