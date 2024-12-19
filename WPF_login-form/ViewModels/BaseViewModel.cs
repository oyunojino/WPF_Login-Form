using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq.Expressions;

namespace WPF_login_form;

public class BaseViewModel : ObservableObject
{
    protected object mPropertyValueCheckLock = new object();

    protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
    {
        lock (mPropertyValueCheckLock)
        {
            if (updatingFlag.GetPropertyValue()) return;

            updatingFlag.SetPropertyValue(true);
        }

        try
        {
            await action();
        }
        finally
        {
            updatingFlag.SetPropertyValue(false);
        }
    }

}


