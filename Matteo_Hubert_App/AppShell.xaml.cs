namespace Matteo_Hubert_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(GifPage), typeof(GifPage));
		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(AddGamePage), typeof(AddGamePage));
	}
}
