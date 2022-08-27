using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaNavigation.ViewModels;

namespace AvaloniaNavigation.Views
{
    public partial class HomeView : ReactiveUserControl<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}
