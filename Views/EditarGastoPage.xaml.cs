using ProyectoFinalDesarrolloMovil.ViewModels;

namespace ProyectoFinalDesarrolloMovil.Views;

public partial class EditarGastoPage : ContentPage
{
	public EditarGastoPage()
	{
		InitializeComponent();
        BindingContext = new EditarGastoViewModel();
    }
}