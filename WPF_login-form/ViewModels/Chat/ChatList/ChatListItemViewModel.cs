using CommunityToolkit.Mvvm.ComponentModel;

namespace WPF_login_form;
/// <summary>
/// A view model for each chat List Item in the overrview chat List
/// </summary>
public partial class ChatListItemViewModel : BaseViewModel
{
    [ObservableProperty]
    public string _name;

    [ObservableProperty]
    public string _message;

    [ObservableProperty]
    public string _initials;

    [ObservableProperty]
    public string _profilePictureRGB;

    [ObservableProperty]
    public bool _newContentAvailable;

    [ObservableProperty]
    public bool _isSelected;
}
