using ProyectoFinalDesarrolloMovil.ViewModels;

namespace ProyectoFinalDesarrolloMovil.Views;

public partial class RegistroPage : ContentPage
{
	public RegistroPage()
	{
		InitializeComponent();
        BindingContext = new RegistroViewModel();
    }
}