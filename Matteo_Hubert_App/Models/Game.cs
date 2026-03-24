using System.Text.Json.Serialization;
using System.Text.Json;
using System.Linq;

namespace Matteo_Hubert_App.Models;

public class Game
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("genre")]
    public object? Genre { get; set; }

    [JsonPropertyName("developers")]
    public object? Developers { get; set; }

    [JsonPropertyName("publishers")]
    public object? Publishers { get; set; }

    [JsonPropertyName("releaseDates")]
    public object? ReleaseDates { get; set; }

    public string ReleaseDateDisplay
    {
        get
        {
            if (ReleaseDates == null) return "N/A";

            if (ReleaseDates is JsonElement element && element.ValueKind == JsonValueKind.Object)
            {
                var dates = new List<string>();
                foreach (var property in element.EnumerateObject())
                {
                    dates.Add($"{property.Name} : {property.Value}");
                }
                return string.Join(" | ", dates);
            }

            return ReleaseDates.ToString() ?? "N/A";
        }
    }

    public string GenreDisplay => ChangementFormat(Genre);
    public string DevelopersDisplay => ChangementFormat(Developers);
    public string PublishersDisplay => ChangementFormat(Publishers);

    private string ChangementFormat(object? data)
    {
        if (data == null) return "N/A";
        
        if (data is System.Text.Json.JsonElement element && element.ValueKind == System.Text.Json.JsonValueKind.Array)
        {
            return string.Join(", ", element.EnumerateArray().Select(x => x.GetString()));
        }

        return data.ToString() ?? "N/A";
    }
}