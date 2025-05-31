using ProyectoFinalDesarrolloMovil.Views;

namespace ProyectoFinalDesarrolloMovil;

public partial class AppShell : Shell
{
    private bool _navegadoSplash = false;

    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("SplashPage", typeof(SplashPage));
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("ListadoGastosPage", typeof(ListadoGastosPage));
        Routing.RegisterRoute("DetalleGastoPage", typeof(DetalleGastoPage));
        Routing.RegisterRoute("AgregarGastoPage", typeof(AgregarGastoPage));
        Routing.RegisterRoute("EditarGastoPage", typeof(EditarGastoPage));
        Routing.RegisterRoute("AjustesPage", typeof(AjustesPage));
        Routing.RegisterRoute(nameof(AgregarGastoPage), typeof(Views.AgregarGastoPage));
        Routing.RegisterRoute("RegistroPage", typeof(RegistroPage));

        this.Appearing += AppShell_Appearing;
    }

    private async void AppShell_Appearing(object sender, EventArgs e)
    {
        if (!_navegadoSplash)
        {
            _navegadoSplash = true;
            await Shell.Current.GoToAsync("//SplashPage");
        }
    }
}
