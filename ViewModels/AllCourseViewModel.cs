using CodeIt.Models;
using CodeIt.Services;
using CodeIt.Views;
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
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllCourseViewModel : ObservableObject
    {
        private readonly CourseService _courseService;
        public AllCourseViewModel(CourseService courseService)
        {
            _courseService = courseService;
            Courses = new(_courseService.GetAllCourses());
        }
        public ObservableCollection<Course> Courses { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchCourses(string searchTerm)
        {
            Courses.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach (var course in _courseService.SearchCourses(searchTerm))
            {
                Courses.Add(course);
            }
            Searching = false;
        }


        [RelayCommand]
        private async Task GoToDetailsPage(Course course)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Course)] = course
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}

