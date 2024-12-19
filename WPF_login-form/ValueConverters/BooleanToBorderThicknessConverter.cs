using System.Globalization;
using System.Windows.Data;

namespace WPF_login_form;

//public class BooleanToBorderThicknessConverter : IValueConverter
public class BooleanToBorderThicknessConverter : BaseValueConverter<BooleanToBorderThicknessConverter>
{
    //public static BooleanToBorderThicknessConverter Instance = new BooleanToBorderThicknessConverter();

    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (parameter == null)
        {
            return (bool)value ? 2 : 0;
        }
        else
        {
            return (bool)value ? 0 : 2;
        }
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //{
    //    if (parameter == null)
    //    {
    //        return (bool)value ? 2 : 0;
    //    }
    //    else
    //    {
    //        return (bool)value ? 0 : 2;
    //    }
    //}

    //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //{
    //    throw new NotImplementedException();
    //}
}
