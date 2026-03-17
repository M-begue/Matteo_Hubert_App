using System.Net.Http.Json;
using Matteo_Hubert_App.Models;

namespace Matteo_Hubert_App.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string Url = "https://api.sampleapis.com/switch/games";

    public ApiService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Game>> GetGamesAsync()
    {
        try
        {
            var games = await _httpClient.GetFromJsonAsync<List<Game>>(Url);
            return games ?? new List<Game>();
        }
        catch (Exception exception)
        {
            await Shell.Current.CurrentPage.DisplayAlertAsync("Erreur API", exception.Message, "OK");
            return new List<Game>();
        }
    }
}