using CodeIt.Models;
using CodeIt.Services;
using CodeIt.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

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

        [RelayCommand]
        private async Task GoToAllCoursesPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllCourseViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllCoursesPage), animate: true, parameters);
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
