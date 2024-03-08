using System.Text.Json.Serialization;

namespace CanvasClientBogdan;


public record class Course
{
    [JsonPropertyName("id")]
    public int CourseCode { get; set; }

    [JsonPropertyName("name")]
    public string CourseName { get; set; }

    [JsonPropertyName("start_at")]
    public string CourseStart { get; set; }

}
