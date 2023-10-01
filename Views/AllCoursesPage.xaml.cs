using CodeIt.ViewModels;

namespace CodeIt.Views;

public partial class AllCoursesPage : ContentPage
{
    private readonly AllCourseViewModel _allCourseViewModel;
    public AllCoursesPage(AllCourseViewModel allCourseViewModel)
    {
        InitializeComponent();
        _allCourseViewModel = allCourseViewModel;
        BindingContext = _allCourseViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_allCourseViewModel.FromSearch)
        {
            await Task.Delay(100);
            searchBar.Focus();
        }
    }

    void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.OldTextValue)
            && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _allCourseViewModel.SearchCoursesCommand.Execute(null);
        }
    }
}
