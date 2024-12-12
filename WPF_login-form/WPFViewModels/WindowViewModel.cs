using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;
using WPF_login_form.Word.Core;

namespace WPF_login_form.Word;

public partial class WindowViewModel : ObservableObject
{
    #region Private Member

    private Window _window;

    private WindowResizer _windowResizer;

    private Thickness _outerMarginSize = new Thickness(5);

    private int _windowRadius = 10;

    private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

    #endregion

    #region Public Properties

    [ObservableProperty]
    private double _windowMinimumWidth = 800;

    [ObservableProperty]
    private double _windowMinimumHeight = 500;

    [ObservableProperty]
    private bool _beingMoved;

    public bool Borderless => (_window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked);
    public int ResizeBorder => _window.WindowState == WindowState.Maximized ? 0 : 4;

    public Thickness ResizeBorderThickness => new Thickness(OuterMarginSize.Left + ResizeBorder,
                                                                OuterMarginSize.Top + ResizeBorder,
                                                                OuterMarginSize.Right + ResizeBorder,
                                                                OuterMarginSize.Bottom + ResizeBorder);

    public Thickness InnerContentPadding { get; set; } = new Thickness(0);

    public Thickness OuterMarginSize
    {
        // If it is maximized or docked, no border
        get => _window.WindowState == WindowState.Maximized ? _windowResizer.CurrentMonitorMargin : (Borderless ? new Thickness(0) : _outerMarginSize);
        set => _outerMarginSize = value;
    }

    public int WindowRadius
    {
        // If it is maximized or docked, no border
        get => Borderless ? 0 : _windowRadius;
        set => _windowRadius = value;
    }

    public int FlatBorderThickness => Borderless && _window.WindowState != WindowState.Maximized ? 1 : 0;

    public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

    public int TitleHeight { get; set; } = 42;

    public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

    public bool DimmableOverlayVisible { get; set; }

    public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
    #endregion

    #region Commands

    /// <summary>
    /// The command to minimize the window
    /// </summary>
    public ICommand MinimizeCommand { get; set; }

    /// <summary>
    /// The command to maximize the window
    /// </summary>
    public ICommand MaximizeCommand { get; set; }

    /// <summary>
    /// The command to close the window
    /// </summary>
    public ICommand CloseCommand { get; set; }

    /// <summary>
    /// The command to show the system menu of the window
    /// </summary>
    public ICommand MenuCommand { get; set; }

    #endregion

    public WindowViewModel(Window window)
    {
        _window = window;

        _window.StateChanged += (sender, e) =>
        {
            WindowResized();
        };
        //var log = App.Current.Services.GetService<ILogger>();
        ////var log = Ioc.Default.GetService<IApiLogger>();
        //log.Information("11111111111aaakkk");
        // Create commands
        MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
        MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
        CloseCommand = new RelayCommand(() => _window.Close());
        MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));

        // Fix window resize issue
        _windowResizer = new WindowResizer(_window);

        // Listen out for dock changes
        _windowResizer.WindowDockChanged += (dock) =>
        {
            // Store last position
            _dockPosition = dock;

            // Fire off resize events
            WindowResized();
        };

        // On window being moved/dragged
        _windowResizer.WindowStartedMove += () =>
        {
            // Update being moved flag
            BeingMoved = true;
        };

        // Fix dropping an undocked window at top which should be positioned at the
        // very top of screen
        _windowResizer.WindowFinishedMove += () =>
        {
            // Update being moved flag
            BeingMoved = false;

            // Check for moved to top of window and not at an edge
            if (_dockPosition == WindowDockPosition.Undocked && _window.Top == _windowResizer.CurrentScreenSize.Top)
                // If so, move it to the true top (the border size)
                _window.Top = -OuterMarginSize.Top;
        };
    }


    private Point GetMousePosition()
    {
        return _windowResizer.GetCursorPosition();
    }


    private void WindowResized()
    {
        OnPropertyChanged(nameof(Borderless));
        OnPropertyChanged(nameof(FlatBorderThickness));
        OnPropertyChanged(nameof(ResizeBorderThickness));
        OnPropertyChanged(nameof(OuterMarginSize));
        OnPropertyChanged(nameof(WindowRadius));
        OnPropertyChanged(nameof(WindowCornerRadius));
    }
}
