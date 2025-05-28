using ProyectoFinalDesarrolloMovil.ViewModels;
namespace ProyectoFinalDesarrolloMovil.Views;

[QueryProperty(nameof(GastoId), "gastoId")]
public partial class DetalleGastoPage : ContentPage
{
    private readonly DetalleGastoViewModel viewModel;
    public string GastoId { get; set; }


    public DetalleGastoPage()
    {
        InitializeComponent();
        viewModel = new DetalleGastoViewModel();
        BindingContext = viewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!string.IsNullOrEmpty(GastoId))
        {
            await viewModel.CargarGasto(GastoId);
        }
    }

}