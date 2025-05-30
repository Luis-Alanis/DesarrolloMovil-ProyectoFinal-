using System.Threading.Tasks;

namespace ProyectoFinalDesarrolloMovil.Views;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
        StartTimer(); // Inicia el temporizador cuando se crea la página
    }

    private async void StartTimer()
    {
        await Task.Delay(3000); // Espera 3 segundos
        await Shell.Current.GoToAsync("//LoginPage"); // Navega a LoginPage
    }
}
