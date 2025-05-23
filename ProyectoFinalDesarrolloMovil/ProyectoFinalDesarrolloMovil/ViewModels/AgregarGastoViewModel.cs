using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Services;
using ProyectoFinalDesarrolloMovil.Models;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class AgregarGastoViewModel : BaseViewModel
    {
        public string Descripcion { get; set; }
        public string Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today;

        public Command GuardarCommand { get; }

        public AgregarGastoViewModel()
        {
            GuardarCommand = new Command(async () => await Guardar());
        }

        private async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(Descripcion) || string.IsNullOrWhiteSpace(Monto))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            var gasto = new Gasto
            {
                Descripcion = Descripcion,
                Monto = decimal.Parse(Monto),
                Fecha = Fecha
            };

            await ApiService.AgregarGastoAsync(gasto);

            await Shell.Current.GoToAsync("..");
        }
    }

}
