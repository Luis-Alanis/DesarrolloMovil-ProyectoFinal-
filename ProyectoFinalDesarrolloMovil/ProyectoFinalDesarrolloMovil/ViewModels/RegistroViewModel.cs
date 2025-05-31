using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Models;
using ProyectoFinalDesarrolloMovil.Services;
using System.Windows.Input;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string ConfirmarContrasena { get; set; }

        public ICommand RegistrarCommand { get; }

        public RegistroViewModel()
        {
            RegistrarCommand = new Command(Registrar);
        }

        private async void Registrar()
        {
            if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Contrasena) || string.IsNullOrWhiteSpace(ConfirmarContrasena))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Completa todos los campos", "OK");
                return;
            }

            if (Contrasena != ConfirmarContrasena)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
                return;
            }

            var usuario = new Usuario
            {
                NombreUsuario = Usuario,
                Contrasena = Contrasena
            };

            var resultado = await ApiService.RegistrarUsuarioAsync(usuario);

            if (resultado)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre de usuario ya está en uso", "OK");
            }
        }
    }
}