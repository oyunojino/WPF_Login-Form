using System.Globalization;
using WPF_login_form.Core;

namespace WPF_login_form;

public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((ApplicationPage)value)
        {
            case ApplicationPage.Login:
                return new LoginPage();
            case ApplicationPage.Register:
                return new RegisterPage();
            case ApplicationPage.Chat:
                return new ChatPage();
            default:
                return null;
        }
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
