using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ProyectoFinalDesarrolloMovil.Views;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Gasto> Gastos { get; set; } = new();

        public ICommand AgregarGastoCommand { get; }
        public ICommand NavegarAgregarGastoCommand { get; }

        public MainPageViewModel()
        {
            Gastos.Add(new Gasto { Id = 1, Descripcion = "Supermercado", Monto = 120.50m, Fecha = DateTime.Now.AddDays(-1) });
            Gastos.Add(new Gasto { Id = 2, Descripcion = "Gasolina", Monto = 800m, Fecha = DateTime.Now.AddDays(-2) });

            //AgregarGastoCommand = new Command(OnAgregarGasto);
            NavegarAgregarGastoCommand = new Command(NavegarAgregarGasto);
        }

        private void OnAgregarGasto()
        {
            App.Current.MainPage.DisplayAlert("Agregar Gasto", "Funcionalidad pendiente", "OK");
        }

        private async void NavegarAgregarGasto()
        {
            await Shell.Current.GoToAsync(nameof(AgregarGastoPage));
        }
    }
}
