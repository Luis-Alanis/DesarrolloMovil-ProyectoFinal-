using ProyectoFinalDesarrolloMovil.ViewModels;

namespace ProyectoFinalDesarrolloMovil.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}