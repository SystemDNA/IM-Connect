using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public static class SessionManager
    {
        private const string AuthKey = "IsAuthenticated";

        public static bool IsAuthenticated =>
            Preferences.Default.Get(AuthKey, false);

        public static void SetAuthenticated() =>
            Preferences.Default.Set(AuthKey, true);

        public static void ClearAuthentication() =>
            Preferences.Default.Set(AuthKey, false);
    }
}
