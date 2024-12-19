using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WPF_login_form;

public class BasePage : Page
{
    private object? _viewModel = null;

    #region Public Properties
    public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

    public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

    public float SlideSeconds { get; set; } = 0.9f;

    public Object? ViewModelObject
    {
        get => _viewModel;
        set
        {
            if (_viewModel == value) return;
            
            _viewModel = value;
            OnViewModelChanged();
            DataContext = _viewModel;
        }
    }

    #endregion

    protected virtual void OnViewModelChanged() { }


    #region Constructor
    public BasePage()
    {
        if (this.PageLoadAnimation != PageAnimation.None)
            this.Visibility = Visibility.Collapsed;
        this.Loaded += BasePage_Loaded;
    }
    #endregion

    #region Animation Load / Unload
    private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        await AnimateAsync();
    }

    private async Task AnimateAsync()
    {
        if(this.PageLoadAnimation == PageAnimation.None)
            return;

        switch (this.PageLoadAnimation)
        {
            case PageAnimation.SlideAndFadeInFromRight:
                //var sb = new Storyboard();
                //var slideAnimation = new ThicknessAnimation { 
                //    Duration = new Duration(TimeSpan.FromSeconds(SlideSeconds)),
                //    From = new Thickness(this.WindowWidth, 0, -this.WindowWidth, 0),
                //    To = new Thickness(0),
                //    DecelerationRatio = 0.9f
                //};

                //Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                //sb.Children.Add(slideAnimation);

                //sb.Begin(this);
                //Visibility = Visibility.Visible;

                //await Task.Delay((int)(this.SlideSeconds * 1000));

                await this.SlideAndFadeInFromRightAsync(SlideSeconds);

                break;
        }

    }

    #endregion
}

// # 템플릿
public class BasePage<VM> : BasePage
    where VM : ObservableObject, new()
{
    //proppfull
    public VM ViewModel
    {
        get => (VM)ViewModelObject;
        set => ViewModelObject = value;
    }

    public BasePage()
    {
        this.ViewModel= new VM();
    }
}
