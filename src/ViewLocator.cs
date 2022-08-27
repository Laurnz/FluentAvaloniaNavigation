using AvaloniaNavigation.ViewModels;
using AvaloniaNavigation.Views;
using ReactiveUI;

namespace AvaloniaNavigation;

public class ViewLocator : IViewLocator
{
    public bool Match(object data) => data is ViewModelBase;

    public IViewFor ResolveView<T>(T? viewModel, string? contract = null)
        => viewModel switch
           {
               HomeViewModel context => new HomeView { DataContext = context },
               AboutViewModel context => new AboutView() { DataContext = context },
               _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
           };
}
