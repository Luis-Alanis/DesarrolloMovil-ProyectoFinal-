using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Gasto> Gastos { get; set; } = new();

        public ICommand AgregarGastoCommand { get; }

        public MainPageViewModel()
        {
            // Datos de ejemplo
            Gastos.Add(new Gasto { Id = 1, Descripcion = "Supermercado", Monto = 120.50m, Fecha = DateTime.Now.AddDays(-1) });
            Gastos.Add(new Gasto { Id = 2, Descripcion = "Gasolina", Monto = 800m, Fecha = DateTime.Now.AddDays(-2) });

            AgregarGastoCommand = new Command(OnAgregarGasto);
        }

        private void OnAgregarGasto()
        {
            // Más adelante esto navegará a la página AgregarGastoPage
            App.Current.MainPage.DisplayAlert("Agregar Gasto", "Funcionalidad pendiente", "OK");
        }
    }
}
