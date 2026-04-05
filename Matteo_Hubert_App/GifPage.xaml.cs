using Matteo_Hubert_App.ViewModels;

namespace Matteo_Hubert_App;

public partial class GifPage : ContentPage
{
    public GifPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}