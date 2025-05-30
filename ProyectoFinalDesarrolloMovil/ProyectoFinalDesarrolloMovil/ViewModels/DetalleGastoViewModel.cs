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
    public class DetalleGastoViewModel : BaseViewModel
    {
        public string gastoId;
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
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public Command EditarCommand { get; }
        public Command EliminarCommand { get; }

        public DetalleGastoViewModel()
        {
            EditarCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync($"EditarGastoPage?gastoId={GastoId}");
            });

            EliminarCommand = new Command(async () =>
            {
                var confirm = await App.Current.MainPage.DisplayAlert("Eliminar", "¿Seguro?", "Sí", "No");
                if (confirm)
                {
                    await ApiService.EliminarGastoAsync(int.Parse(GastoId));
                    await Shell.Current.GoToAsync("..");
                }
            });
        }

        public async Task CargarGasto(string id)
        {
            if (!int.TryParse(id, out int gastoId))
            {
                await App.Current.MainPage.DisplayAlert("Error", "ID de gasto inválido", "OK");
                return;
            }

            var gasto = await ApiService.ObtenerGastoPorIdAsync(gastoId);
            Descripcion = gasto.Descripcion;
            Monto = gasto.Monto;
            Fecha = gasto.Fecha;

            OnPropertyChanged(nameof(Descripcion));
            OnPropertyChanged(nameof(Monto));
            OnPropertyChanged(nameof(Fecha));
        }

    }

}