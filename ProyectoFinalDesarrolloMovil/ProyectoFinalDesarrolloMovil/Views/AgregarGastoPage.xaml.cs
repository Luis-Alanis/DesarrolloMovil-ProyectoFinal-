using ProyectoFinalDesarrolloMovil.ViewModels;

namespace ProyectoFinalDesarrolloMovil.Views;

public partial class AgregarGastoPage : ContentPage
{
	public AgregarGastoPage()
	{
		InitializeComponent();
        BindingContext = new AgregarGastoViewModel();
    }
}