using Matteo_Hubert_App.ViewModels;

namespace Matteo_Hubert_App;

public partial class AddGamePage : ContentPage
{
	public AddGamePage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

	}
}