using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Services;
using ProyectoFinalDesarrolloMovil.Models;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class AjustesViewModel : BaseViewModel
    {
        private string temaSeleccionado;
        public string TemaSeleccionado
        {
            get => temaSeleccionado;
            set
            {
                if (temaSeleccionado != value)
                {
                    temaSeleccionado = value;
                    OnPropertyChanged();
                    AplicarTema(value);
                }
            }
        }

        private void AplicarTema(string tema)
        {
            App.Current.UserAppTheme = tema switch
            {
                "Claro" => AppTheme.Light,
                "Oscuro" => AppTheme.Dark,
                _ => AppTheme.Unspecified
            };
        }

        public AjustesViewModel()
        {
            TemaSeleccionado = App.Current.UserAppTheme == AppTheme.Dark ? "Oscuro" : "Claro";
        }
    }

}