using ProyectoFinalDesarrolloMovil.Views;

namespace ProyectoFinalDesarrolloMovil;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("ListadoGastosPage", typeof(ListadoGastosPage));
        Routing.RegisterRoute("DetalleGastoPage", typeof(DetalleGastoPage));
        Routing.RegisterRoute("AgregarGastoPage", typeof(AgregarGastoPage));
        Routing.RegisterRoute("EditarGastoPage", typeof(EditarGastoPage));
        Routing.RegisterRoute("AjustesPage", typeof(AjustesPage));
    }
}
