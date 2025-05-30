using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrolloMovil.Helpers
{
    public static class AppSettings
    {
#if ANDROID
        public static string ApiBaseUrl = "https://10.0.2.2:7175/api/";
#else
        public static string ApiBaseUrl = "https://localhost:7175/api/";
#endif
    }
}