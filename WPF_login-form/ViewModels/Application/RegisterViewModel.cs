using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Serilog;
using WPF_login_form.Core;

namespace WPF_login_form;

public partial class RegisterViewModel : BaseViewModel
{
    private readonly ILogger _logger;


    /// <summary>
    /// The email of the user
    /// </summary>
    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private bool _loginIsRunning;

    public RegisterViewModel()
    {
        //Email = "choshinyoun@naver.com";

    }

    [RelayCommand]
    private async Task OnRegisterAsync()
    {

    }

    // LoginCommand
    [RelayCommand]
    private async Task OnLoginAsync(object parmeter)
    {
        (App.Current.MainWindow.DataContext as WindowViewModel).CurrentPage = ApplicationPage.Login;
        await Task.Delay(1);
    }
}
