using FluentAvalonia.UI.Controls;
using ReactiveUI;

namespace AvaloniaNavigation.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    private readonly Dictionary<Routes, NavigationViewItem> RouteToNavigationItem;
    private readonly Dictionary<Routes, Lazy<IRoutableViewModel>> RouteToViewModels;
    private NavigationViewItem _selectedNavigationItem;
    private Routes _currentRoute = Routes.Home;
    
    public enum Routes
    {
        Home,
        About
    }

    public List<NavigationViewItem> MainNavigationItems { get; }

    public NavigationViewItem SelectedNavigationItem
    {
        get => _selectedNavigationItem;
        set
        {
            if (SetProperty(ref _selectedNavigationItem, value))
                CurrentRoute = (Routes) value.Tag!;
        }
    }

    public Routes CurrentRoute
    {
        get => _currentRoute;
        set
        {
            if (SetProperty(ref _currentRoute, value))
            {
                SelectedNavigationItem = GetNavigationViewItem(value);
                Router.Navigate.Execute(GetViewModel(value));
            }
        }
    }

    public RoutingState Router { get; } = new();
    

    public MainWindowViewModel()
    {
        MainNavigationItems = CreateNavigationItems();
        
        RouteToNavigationItem = MainNavigationItems.ToDictionary(element => (Routes) element.Tag!);
        RouteToViewModels = new Dictionary<Routes, Lazy<IRoutableViewModel>>
        {
            { Routes.Home, new Lazy<IRoutableViewModel>(() => new HomeViewModel(this)) },
            { Routes.About, new Lazy<IRoutableViewModel>(() => new AboutViewModel(this)) }
        };
        
        _selectedNavigationItem = GetNavigationViewItem(Routes.Home);
        Router.Navigate.Execute(GetViewModel(Routes.Home));
    }
    

    private NavigationViewItem GetNavigationViewItem(Routes route)
    {
        return RouteToNavigationItem[route];
    }

    private IRoutableViewModel GetViewModel(Routes route)
    {
        return RouteToViewModels[route].Value;
    }
    
    private List<NavigationViewItem> CreateNavigationItems()
        => new()
        {
            new NavigationViewItem
            {
                Content = "Home",
                Tag = Routes.Home,
                Icon = new IconSourceElement { IconSource = new SymbolIconSource { Symbol = Symbol.Home } },
                Classes = { "SampleAppNav" }
            },
            new NavigationViewItem
            {
                Content = "About",
                Tag = Routes.About,
                Icon = new IconSourceElement { IconSource = new SymbolIconSource { Symbol = Symbol.ContactInfo } },
                Classes = { "SampleAppNav" }
            }
        };
}
