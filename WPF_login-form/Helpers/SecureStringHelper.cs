using System.Runtime.InteropServices;
using System.Security;

namespace WPF_login_form;

public static class SecureStringHelper
{
    public static string? Unsecure(this SecureString secureString)
    {
        if(secureString == null)
            return string.Empty;

        var unmanagedString = IntPtr.Zero;

		try
		{
            // Unsecures the password
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(unmanagedString);
        }
		finally
		{
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
		}
    }
}
