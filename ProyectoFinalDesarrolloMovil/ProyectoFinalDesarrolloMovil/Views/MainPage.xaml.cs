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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is MainPageViewModel vm)
            {
                await vm.RefrescarLista();
            }
        }
    }
}