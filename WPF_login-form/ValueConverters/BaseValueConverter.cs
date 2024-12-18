using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPF_login_form;

public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
    where T : class, new()
{
    #region  Private Members
    private static T Converter = null;
    #endregion

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Converter ?? (Converter = new T());
    }

    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
}
