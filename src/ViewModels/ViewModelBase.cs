using System.Runtime.CompilerServices;
using ReactiveUI;

namespace AvaloniaNavigation.ViewModels;

public class ViewModelBase : ReactiveObject
{
    protected bool SetProperty<T>(ref T member, T value, Action action, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(member, value))
            return false;

        action();
        this.RaiseAndSetIfChanged(ref member, value, propertyName);
        return true;
    }
    
    protected bool SetProperty<T>(ref T member, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(member, value))
            return false;

        this.RaiseAndSetIfChanged(ref member, value, propertyName);
        return true;
    }
}
