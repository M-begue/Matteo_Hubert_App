using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Matteo_Hubert_App.Models;
using Matteo_Hubert_App.Services;

namespace Matteo_Hubert_App.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ApiService _apiService = new ApiService();

    [ObservableProperty]
    private bool _isBusy;

    public ObservableCollection<Game> Games { get; } = new();

    public MainViewModel()
    {
        LoadGamesCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadGamesAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var games = await _apiService.GetGamesAsync();
            
            Games.Clear();
            foreach (var game in games)
                Games.Add(game);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task OpenGifPage()
    {
        await Shell.Current.GoToAsync(nameof(GifPage));
    }

    [RelayCommand]
    private async Task GoToDetails(Game selectedGame)
    {
        if (selectedGame == null) return;

        var parameters = new Dictionary<string, object>
        {
            { "Game", selectedGame }
        };

        await Shell.Current.GoToAsync(nameof(DetailsPage), parameters);
    }
}