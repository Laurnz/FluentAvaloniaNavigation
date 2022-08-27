using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaNavigation.ViewModels;

namespace AvaloniaNavigation.Views
{
    public partial class AboutView : ReactiveUserControl<AboutViewModel>
    {
        public AboutView()
        {
            InitializeComponent();
        }
    }
}
