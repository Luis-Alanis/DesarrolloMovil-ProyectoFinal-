using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Services;
using ProyectoFinalDesarrolloMovil.Models;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class SplashViewModel
    {
        public SplashViewModel()
        {
            Task.Delay(2000).ContinueWith(_ =>
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync("//LoginPage");
                });
            });
        }
    }
}
