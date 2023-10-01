using CodeIt.Models;
using CodeIt.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIt.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly CourseService _courseService;
        public HomeViewModel(CourseService courseService)
        {
            _courseService = courseService;
            Courses = new(_courseService.GetPopularCourses());
        }

        public ObservableCollection<Course> Courses { get; set; }

    }
}
