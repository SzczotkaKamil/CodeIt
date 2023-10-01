#if IOS
using CodeIt.ViewModels;
using UIKit;

#endif
using CodeIt.Models;
using Microsoft.Maui.Controls;
using CodeIt.Services;
using CodeIt.Models;
using CodeIt.ViewModels;
namespace CodeIt.Views;

public partial class DetailPage : ContentPage
{
    private readonly DetailsViewModel _detailsViewModel;
    public DetailPage(DetailsViewModel detailsViewModel)
    {
        _detailsViewModel = detailsViewModel;
        InitializeComponent();
        BindingContext = _detailsViewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if IOS
        var bottom = UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;

        bottomBox.Margin = new Thickness(-1, 0, -1, (bottom + 1) * -1);
#endif
    }

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("..", animate: true);
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
        Behaviors.Add(new CommunityToolkit.Maui.Behaviors.StatusBarBehavior
        {
            StatusBarColor = Colors.DarkGoldenrod,
            StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent
        });
    }
}
