namespace ProyectoFinalDesarrolloMovil.Views;
using ProyectoFinalDesarrolloMovil.Models;

public partial class ListadoGastosPage : ContentPage
{
	public ListadoGastosPage()
	{
		InitializeComponent();
	}

    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        var gasto = e.CurrentSelection.FirstOrDefault() as Gasto;
        if (gasto == null)
            return;

        await Shell.Current.GoToAsync($"DetalleGastoPage?gastoId={gasto.Id}");
    }

}