using ReactiveUI;

namespace AvaloniaNavigation.ViewModels;

public class AboutViewModel : ViewModelBase, IRoutableViewModel
{
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    public IScreen HostScreen { get; }

    public AboutViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}
