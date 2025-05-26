using ProyectoFinalDesarrolloMovil.ViewModels;
namespace ProyectoFinalDesarrolloMovil.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

    }

}
