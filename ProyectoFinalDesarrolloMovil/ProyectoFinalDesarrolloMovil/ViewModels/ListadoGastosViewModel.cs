using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Services;
using ProyectoFinalDesarrolloMovil.Models;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class ListadoGastosViewModel : BaseViewModel
    {
        public ObservableCollection<Gasto> Gastos { get; set; } = new();

        public Command CargarGastosCommand { get; }
        public Command IrAgregarCommand { get; }

        public ListadoGastosViewModel()
        {
            CargarGastosCommand = new Command(async () => await CargarGastos());
            IrAgregarCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("AgregarGastoPage");
            });
        }

        private async Task CargarGastos()
        {
            IsBusy = true;
            try
            {
                var gastos = await ApiService.ObtenerGastosAsync();
                Gastos.Clear();
                foreach (var gasto in gastos)
                    Gastos.Add(gasto);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}
