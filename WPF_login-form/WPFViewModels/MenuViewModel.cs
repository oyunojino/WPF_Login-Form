using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Input;
using WPF_login_form.Word;

namespace WPF_login_form;

public class MenuViewModel
{
    private Window _window;
    private WindowResizer _windowResizer;

    public ICommand Menu1Command { get; set; }

    public ICommand MinimizeCommand { get; set; }

    public ICommand MaximizeCommand { get; set; }

    public ICommand CloseCommand { get; set; }

    public MenuViewModel(Window window)
    {
        _window = window;

        // ERROR : 초기화가 안되면 null로 리턴됨
        _windowResizer = new WindowResizer(_window);

        //Menu1Command = new RelayCommand(OnMenuCommandExcuted);
        Menu1Command = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));
        MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
        MaximizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Maximized);
        CloseCommand = new RelayCommand(() => _window.Close());
    }

    private void OnMenuCommandExcuted()
    {
        //MessageBox.Show("menu button click");
        SystemCommands.ShowSystemMenu(_window, GetMousePosition());
    }

    private Point GetMousePosition()
    {
        return _windowResizer.GetCursorPosition();
    }

}
