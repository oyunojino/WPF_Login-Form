using CommunityToolkit.Mvvm.ComponentModel;

namespace WPF_login_form;
/// <summary>
/// A view model for each chat List Item in the overrview chat List
/// </summary>
public partial class ChatListViewModel : BaseViewModel
{
    [ObservableProperty]
    public List<ChatListItemViewModel>? _items;

}
