using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Services;
using ProyectoFinalDesarrolloMovil.Models;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    [QueryProperty(nameof(GastoId), "gastoId")]
    public class EditarGastoViewModel : BaseViewModel
    {
        private string gastoId;
        public string GastoId
        {
            get => gastoId;
            set
            {
                gastoId = value;
                CargarGasto(value);
            }
        }

        public string Descripcion { get; set; }
        public string Monto { get; set; }
        public DateTime Fecha { get; set; }

        public Command GuardarCambiosCommand { get; }

        public EditarGastoViewModel()
        {
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
        }

        private async void CargarGasto(string id)
        {
            if (!int.TryParse(id, out int gastoId))
            {
                await App.Current.MainPage.DisplayAlert("Error", "ID de gasto inválido", "OK");
                return;
            }

            var gasto = await ApiService.ObtenerGastoPorIdAsync(gastoId);

            if (gasto == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No se encontró el gasto", "OK");
                return;
            }

            Descripcion = gasto.Descripcion;
            Monto = gasto.Monto.ToString();
            Fecha = gasto.Fecha;

            OnPropertyChanged(nameof(Descripcion));
            OnPropertyChanged(nameof(Monto));
            OnPropertyChanged(nameof(Fecha));
        }

        private async Task GuardarCambios()
        {
            var gasto = new Gasto
            {
                Id = int.Parse(GastoId),
                Descripcion = Descripcion,
                Monto = decimal.Parse(Monto),
                Fecha = Fecha
            };

            await ApiService.EditarGastoAsync(gasto);
            await Shell.Current.GoToAsync("..");
        }
    }

}
