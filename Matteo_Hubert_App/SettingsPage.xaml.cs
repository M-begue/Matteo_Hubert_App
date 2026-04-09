using Matteo_Hubert_App.ViewModels;

namespace Matteo_Hubert_App;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}