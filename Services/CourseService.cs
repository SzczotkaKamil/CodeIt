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
                Price = 49.99,
                Description = "This course is for beginners who want to learn Angular from scratch. No prior knowledge of Angular is required, however it would be good to have basic understanding of TypeScript."
            },
            new Course
            {
                Name = "Java",
                Image = "java",
                Price = 79.99,
                Description = "This course is for beginners who want to learn Java from scratch. No prior knowledge of Java is required, however it would be good to have basic understanding of object oriented programming."
            },
            new Course
            {
                Name = "JavaScript",
                Image = "javascript",
                Price = 49.99,
                Description="This course is for beginners who want to learn JavaScript from scratch. No prior knowledge of JavaScript is required, however it would be good to have basic understanding of HTML and CSS."
            },
            new Course
            {
                Name = "TypeScript",
                Image = "typescript",
                Price = 64.99,
                Description="This course is for beginners who want to learn TypeScript from scratch. No prior knowledge of TypeScript is required, however it would be good to have basic understanding of JavaScript."
            },
            new Course
            {
                Name = "Visual Studio",
                Image = "visualstudio",
                Price = 49.99,
                Description="This course is for beginners who want to learn Visual Studio from scratch. No prior knowledge of Visual Studio is required."
            }
        };

        public IEnumerable<Course> GetAllCourses() => _courses;

        public IEnumerable<Course> GetPopularCourses(int count = 5) =>
            _courses.OrderBy(p => Guid.NewGuid())
            .Take(count);

        public IEnumerable<Course> SearchCourses(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _courses
            : _courses.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
