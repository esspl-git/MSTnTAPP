using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSTnTAPP.Helpers
{
    public interface IAuthHelper
    {
        void SetParent(object parent);
        Task<UserContext> SignInAsync();
        Task<UserContext> SignOutAsync();
        Task<UserContext> EditProfileAsync();
        Task<UserContext> ResetPasswordAsync();
        Task<UserContext> AcquireTokenAsync();
        Task<UserContext> SignInInteractivelyAsync();
    }
}
