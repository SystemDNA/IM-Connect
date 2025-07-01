using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IFirebaseTokenRetriever
    {
        string Token { get; }

        void SaveToken(string token);


        string GetToken();

    }
}
