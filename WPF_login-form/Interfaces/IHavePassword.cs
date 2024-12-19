using System.Security;

namespace WPF_login_form;

internal interface IHavePassword
{
    SecureString SecurePassword { get; }
}
