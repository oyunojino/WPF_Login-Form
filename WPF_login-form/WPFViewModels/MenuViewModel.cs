﻿using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using WPF_login_form.Word;
using WPF_login_form.Word.Core;

namespace WPF_login_form;

public class MenuViewModel
{
    private Window _window;
    private WindowResizer _windowResizer;

    #region # Commands
    public ICommand Menu1Command { get; set; }

    public ICommand MinimizeCommand { get; set; }

    public ICommand MaximizeCommand { get; set; }

    public ICommand CloseCommand { get; set; }
    #endregion


    public ApplicationPage _currentPage = ApplicationPage.Login;

    #region #window size / move

    // # 창의 제목 표시줄 높이
    public int TitleHeight { get; set; } = 42;

    // # 창의 외부 여백
    private Thickness _outerMarginSize = new Thickness(5);

    // # 창이 현재 화면의 모서리에 도킹 되었는지 또는 자유롭게 위치할 수 있는지 나타내는 필드
    private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

    // # 창이 최대화 상태이거나 도킹된 경우 true / 그 외에 false
    public bool Borderless => (_window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked);

    // # 창 최대화 테두리 두께 0 / 그 외의 경우 4
    public int ResizeBorder => _window.WindowState == WindowState.Maximized ? 0 : 4;

    // # 창의 외부 여백 크기
    //  get -> 최대화일 떄, 현재 모니터의 여백 / 그 외일 때, _outerMarginSize
    //  set -> 외부 여백 크기 설정
    public Thickness OuterMarginSize
    {
        // If it is maximized or docked, no border
        get => _window.WindowState == WindowState.Maximized ? _windowResizer.CurrentMonitorMargin : (Borderless ? new Thickness(0) : _outerMarginSize);
        set => _outerMarginSize = value;
    }

    // # 창 테두리 크기
    public Thickness ResizeBorderThickness => new Thickness(OuterMarginSize.Left + ResizeBorder,
                                                                OuterMarginSize.Top + ResizeBorder,
                                                                OuterMarginSize.Right + ResizeBorder,
                                                                OuterMarginSize.Bottom + ResizeBorder);
    #endregion

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
