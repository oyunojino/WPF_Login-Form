namespace WPF_login_form;

public class ChatListItemDesignModel : ChatListItemViewModel
{
    public static ChatListItemDesignModel Instance = new ChatListItemDesignModel();

    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    public ChatListItemDesignModel()
    {
        Initials = "LM";
        Name = "Luke";
        Message = "This chat app is awesome! I bet it will be fast too";
        ProfilePictureRGB = "3099c5";
    }

    #endregion
}
