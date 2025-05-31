using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Services;
using ProyectoFinalDesarrolloMovil.Models;
using ProyectoFinalDesarrolloMovil.Views;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public Command IniciarSesionCommand { get; }
        public Command IrARegistroCommand { get; }

        public LoginViewModel()
        {
            IniciarSesionCommand = new Command(IniciarSesion);
            IrARegistroCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(RegistroPage)));
        }

        private async void IniciarSesion()
        {
            if (!string.IsNullOrWhiteSpace(Usuario) && !string.IsNullOrWhiteSpace(Contrasena))
            {
                var usuario = await ApiService.IniciarSesionAsync(Usuario, Contrasena);
                if (usuario != null)
                {
                    await Shell.Current.GoToAsync("///MainPage");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Credenciales incorrectas", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Llena todos los campos", "OK");
            }
        }
    }

}