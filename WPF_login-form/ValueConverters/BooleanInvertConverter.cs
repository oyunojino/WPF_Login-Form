using System.Globalization;
using System.Windows.Data;

namespace WPF_login_form;

public class BooleanInvertConverter : BaseValueConverter<BooleanInvertConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => !(bool)value;


    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();

}