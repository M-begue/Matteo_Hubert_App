using CommunityToolkit.Mvvm.ComponentModel;
using Matteo_Hubert_App.Models;

namespace Matteo_Hubert_App.ViewModels;

[QueryProperty(nameof(CurrentGame), "Game")]
public partial class DetailsViewModel : ObservableObject
{
    [ObservableProperty]
    private Game _currentGame = default!;
}