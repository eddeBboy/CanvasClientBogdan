
using System.Net.Http.Headers;
using CanvasClientBogdan.Services;
using Microsoft.Extensions.Configuration;
IConfigurationRoot configuration = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.Build();
var canvasApiToken = configuration["AppSettings:ApiKey"];
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", canvasApiToken);
await GetCourses(client);
static async Task GetCourses(HttpClient httpClient)
{
var json = await httpClient.GetStringAsync(
"https://canvas.education.lu.se/api/v1/courses/2417");
Console.WriteLine(json);

ICourseService courseService = new CourseService();
var courses = await courseService.GetCourses();
foreach (var course in courses)
{
DateTime startDate;
if (course.CourseStart != null)
{
startDate = DateTime.Parse(course.CourseStart);
}
else
{
startDate = DateTime.MinValue;
}
Console.WriteLine($"Course Code: {course.CourseCode}, Name: {course.CourseName}, Start Date: {startDate}");
}


}