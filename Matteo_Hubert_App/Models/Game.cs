using System.Text.Json.Serialization;
using System.Linq;

namespace Matteo_Hubert_App.Models;

public class Game
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("genre")]
    public object? Genre { get; set; }

    [JsonPropertyName("releaseDate")]
    public string ReleaseDate { get; set; } = string.Empty;

    public string GenreDisplay
    {
        get
        {
            if (Genre == null) return "N/A";

            if (Genre is System.Text.Json.JsonElement element && element.ValueKind == System.Text.Json.JsonValueKind.Array)
            {
                var list = element.EnumerateArray().Select(x => x.GetString());
                return string.Join(", ", list);
            }
            return Genre.ToString() ?? "N/A";
        }
    }
}