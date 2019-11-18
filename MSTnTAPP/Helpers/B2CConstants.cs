using System;
using System.Collections.Generic;
using System.Text;

namespace MSTnTAPP.Helpers
{
    public static class B2CConstants
    {
        public static bool tokenRequested = false; // flag to avoid duplicate calls
        // Azure AD B2C Coordinates
        public static string Tenant = "esspltnt.onmicrosoft.com";
        public static string AzureADB2CHostname = "esspltnt.b2clogin.com";
        //public static string AzureADB2CHostname = "login.microsoftonline.com";
        public static string ClientID = "f95b65b0-6ed2-4125-890c-273d177470f2";
        public static string PolicySignUpSignIn = "B2C_1_TnTAppSignIn";
        public static string PolicyEditProfile = "b2c_1_edit_profile";
        public static string PolicyResetPassword = "b2c_1_reset";

        public static string[] Scopes = { "" };

        public static string AuthorityBase = $"https://{AzureADB2CHostname}/tfp/{Tenant}/";
        public static string AuthoritySignInSignUp = $"{AuthorityBase}{PolicySignUpSignIn}";
        public static string AuthorityEditProfile = $"{AuthorityBase}{PolicyEditProfile}";
        public static string AuthorityPasswordReset = $"{AuthorityBase}{PolicyResetPassword}";
        public static string IOSKeyChainGroup = "com.microsoft.adalcache";
    }
}
