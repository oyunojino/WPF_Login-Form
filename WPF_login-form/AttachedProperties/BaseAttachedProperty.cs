using System.Windows;

namespace WPF_login_form;

public abstract class BaseAttachedProperty<Parent, Property>
    where Parent : class, new()
{
    // # 인스턴스 생성
    public static Parent Instance { get; private set; } = new Parent();

    #region Public Events
    public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
    public event Action<DependencyObject, object> ValueUpated = (sender, value) => { };
    #endregion


    public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);


    public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);


    // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.RegisterAttached("Value"
            , typeof(Property)
            , typeof(BaseAttachedProperty<Parent, Property>)
            , new UIPropertyMetadata(
                default(Property),
                new PropertyChangedCallback(OnValuePropertyChanged),
                new CoerceValueCallback(OnValuePropertyUpdated)));

    private static object OnValuePropertyUpdated(DependencyObject d, object value)
    {
        (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);
        (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpated(d, value);

        return value;
    }

    private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);
        (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
    }


    public virtual void OnValueUpdated(DependencyObject d, object value) { }

    public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }
}
