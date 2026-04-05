using Matteo_Hubert_App.ViewModels;

namespace Matteo_Hubert_App;

public partial class SearchPage : ContentPage
{
	public SearchPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	protected override async void OnAppearing()
    {
		base.OnAppearing();
        var vm = (MainViewModel)BindingContext;
        await vm.LoadGamesCommand.ExecuteAsync(null);
    }
}