using System.Net.Http.Headers;
using System.Text.Json;
using CanvasClientBogdan;
using Microsoft.Extensions.Configuration;

namespace CanvasClientBogdan.Services;

public class CourseService : ICourseService
{
private readonly HttpClient _httpClient;
private readonly string _baseUrl;
private readonly string _endpoint = "courses";
private readonly string _apiKey;
public CourseService()
{
_httpClient = new HttpClient();
IConfigurationRoot configuration = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.Build();
_baseUrl = configuration["AppSettings:BaseUrl"];
_apiKey = configuration["AppSettings:ApiKey"];
_httpClient.DefaultRequestHeaders.Accept.Clear();
_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
}
public async Task<List<Course>> GetCourses()
{

    
var responseStream = await _httpClient.GetStreamAsync(_baseUrl + _endpoint);
var courses = await JsonSerializer.DeserializeAsync<List<Course>>(responseStream) ?? new List<Course>();
return courses;
}
public async Task<Course> GetCourse(int id)
{
var responseStream = await _httpClient.GetStreamAsync(_baseUrl + _endpoint + "/" + id);
var course = await JsonSerializer.DeserializeAsync<Course>(responseStream);
return course;
}
}


