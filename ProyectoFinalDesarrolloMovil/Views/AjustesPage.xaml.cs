using ProyectoFinalDesarrolloMovil.ViewModels;


namespace ProyectoFinalDesarrolloMovil.Views;

public partial class AjustesPage : ContentPage
{
	public AjustesPage()
	{
		InitializeComponent();
        BindingContext = new AjustesViewModel();

    }
}