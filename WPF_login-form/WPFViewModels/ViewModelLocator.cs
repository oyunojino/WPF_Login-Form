namespace WPF_login_form;

/// <summary>
/// Locates view models from the IoC for use in binding in Xaml files
/// </summary>
public class ViewModelLocator
{
    #region Public Properties

    /// <summary>
    /// Singleton instance of the locator
    /// </summary>
    public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();


    public bool ServerReachable { get; set; } = true;


    // # LoginPage를 접근할 수 있도록 static으로 생성
    public static LoginPage LoginPage { get; set; } = new LoginPage();

    ///// <summary>
    ///// The application view model
    ///// </summary>
    //public ApplicationViewModel ApplicationViewModel => ViewModelApplication;

    ///// <summary>
    ///// The settings view model
    ///// </summary>
    //public SettingsViewModel SettingsViewModel => ViewModelSettings;

    #endregion
}