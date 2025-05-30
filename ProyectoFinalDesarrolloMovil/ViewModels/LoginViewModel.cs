using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Services;
using ProyectoFinalDesarrolloMovil.Models;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public Command IniciarSesionCommand { get; }

        public LoginViewModel()
        {
            IniciarSesionCommand = new Command(IniciarSesion);
        }

        private async void IniciarSesion()
        {
            // Aquí podrías validar con backend si gustas
            if (!string.IsNullOrWhiteSpace(Usuario) && !string.IsNullOrWhiteSpace(Contrasena))
            {
                await Shell.Current.GoToAsync("///MainPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña inválidos", "OK");
            }
        }
    }

}