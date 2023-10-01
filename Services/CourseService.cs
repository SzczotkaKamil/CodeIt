using CodeIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIt.Services
{
    public class CourseService
    {
        private readonly static IEnumerable<Course> _courses = new List<Course>
        {
            new Course
            {
                Name = "Angular",
                Image = "angular",
                Price = 49.99
            },
            new Course
            {
                Name = "Java",
                Image = "java",
                Price = 79.99
            },
            new Course
            {
                Name = "JavaScript",
                Image = "javascript",
                Price = 49.99
            },
            new Course
            {
                Name = "TypeScript",
                Image = "typescript",
                Price = 64.99
            },
            new Course
            {
                Name = "Visual Studio",
                Image = "visualstudio",
                Price = 49.99
            }
        };

        public IEnumerable<Course> GetAllCourses() => _courses;

        public IEnumerable<Course> GetPopularCourses(int count = 6) =>
            _courses.OrderBy(p => Guid.NewGuid())
            .Take(count);

        public IEnumerable<Course> SearchCourses(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _courses
            : _courses.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
