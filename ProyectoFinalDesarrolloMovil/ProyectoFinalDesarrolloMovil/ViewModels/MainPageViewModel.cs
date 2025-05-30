using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDesarrolloMovil.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ProyectoFinalDesarrolloMovil.Views;
using ProyectoFinalDesarrolloMovil.Services;

namespace ProyectoFinalDesarrolloMovil.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Gasto> Gastos { get; set; } = new();

        public ICommand AgregarCommand { get; }
        public ICommand NavegarAgregarGastoCommand { get; }
        public ICommand VerDetalleCommand { get; }
        public ICommand AjustesCommand { get; }

        public MainPageViewModel()
        {
            //Gastos.Add(new Gasto { Id = 1, Descripcion = "Supermercado", Monto = 120.50m, Fecha = DateTime.Now.AddDays(-1) });
            //Gastos.Add(new Gasto { Id = 2, Descripcion = "Gasolina", Monto = 800m, Fecha = DateTime.Now.AddDays(-2) });

            //AgregarGastoCommand = new Command(OnAgregarGasto);
            //NavegarAgregarGastoCommand = new Command(NavegarAgregarGasto);

            AgregarCommand = new Command(async () => await Shell.Current.GoToAsync("AgregarGastoPage"));
            AjustesCommand = new Command(async () => await Shell.Current.GoToAsync("AjustesPage"));
            VerDetalleCommand = new Command<Gasto>(async (gasto) =>
            {
                if (gasto == null) return;
                await Shell.Current.GoToAsync($"DetalleGastoPage?gastoId={gasto.Id}");
            });

            // Llamada inicial para cargar datos
            _ = CargarGastosAsync();
        }


        private async Task CargarGastosAsync()
        {
            IsBusy = true;

            try
            {
                var gastosDesdeApi = await ApiService.ObtenerGastosAsync();

                Gastos.Clear();
                foreach (var gasto in gastosDesdeApi)
                    Gastos.Add(gasto);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"No se pudieron cargar los gastos: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task RefrescarLista()
        {
            await CargarGastosAsync();
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