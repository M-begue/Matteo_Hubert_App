namespace Matteo_Hubert_App;

public partial class GifPage : ContentPage
{
    public GifPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}