using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;
using WPF_login_form.Interfaces;

namespace WPF_login_form;

public static class CoreDI
{
    //
    // 요약:
    //     Gets the configuration
    public static IConfiguration Configuration => App.Current.Services.GetRequiredService<IConfiguration>();

    //
    // 요약:
    //     Gets the default logger
    public static ILogger Logger => App.Current.Services.GetRequiredService<ILogger>();

    /// <summary>
    /// A shortcut to access the <see cref="ITaskManager"/>
    /// </summary>
    public static ITaskManager TaskManager => App.Current.Services.GetRequiredService<ITaskManager>();
}
