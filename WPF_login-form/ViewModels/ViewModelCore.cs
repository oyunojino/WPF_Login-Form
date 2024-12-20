using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_login_form;

public class ViewModelCore : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;


    // 선택적 매개변수를 사용
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
