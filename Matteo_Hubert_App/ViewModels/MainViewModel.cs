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

    [ObservableProperty]
    public ObservableCollection<Game> _games = new();

    [ObservableProperty] private string _newGameName = string.Empty;
    [ObservableProperty] private string _newGameGenre = string.Empty;
    [ObservableProperty] private string _newGameDev = string.Empty;
    [ObservableProperty] private string _newGamePublisher = string.Empty;
    [ObservableProperty] private string _newGameDate = string.Empty;

    public MainViewModel()
    {
        
    }

    [RelayCommand]
    public async Task AddCustomGame()
    {
        if (string.IsNullOrWhiteSpace(NewGameName)) return;

        var customGame = new Game
        {
            Name = NewGameName,
            Genre = NewGameGenre,
            Developers = NewGameDev,
            Publishers = NewGamePublisher,
            ReleaseDates = new Dictionary<string, string> { { "Saisie manuelle", NewGameDate } }
        };

        Games.Insert(0, customGame);

        NewGameName = NewGameGenre = NewGameDev = NewGamePublisher = NewGameDate = string.Empty;

        await Shell.Current.DisplayAlertAsync("Succès", "Jeu ajouté !", "OK");
        await Shell.Current.GoToAsync(".."); 
    }

    [RelayCommand]
    private async Task LoadGamesAsync()
    {
        if (IsBusy || Games.Count > 0) return; 

        try
        {
            IsBusy = true;
            var gamesFromApi = await _apiService.GetGamesAsync();
            foreach (var game in gamesFromApi)
            {
                Games.Add(game);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Erreur", "Problème de connexion", "OK", ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ClearGames()
    {
        bool confirm = await Shell.Current.DisplayAlertAsync("Attention", "Voulez-vous vraiment vider la liste ?", "Oui", "Non");
    
        if (confirm)
        {
            Games.Clear();
            await Shell.Current.DisplayAlertAsync("Info", "La liste a été vidée.", "OK");
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