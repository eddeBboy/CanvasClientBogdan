using CanvasClientBogdan;

namespace CanvasClientBogdan.Services;

public interface ICourseService
{
    Task<List<Course>> GetCourses();
    Task<Course> GetCourse(int id);

}
