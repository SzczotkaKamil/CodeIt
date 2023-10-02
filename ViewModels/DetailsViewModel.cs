using CodeIt.Models;
using CodeIt.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeIt.ViewModels
{
    [QueryProperty(nameof(Course), nameof(Course))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;

            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }

        private void OnCartCleared(object? _, EventArgs e) => Course.CartQuantity = 0;

        private void OnCartItemRemoved(object? _, Course p) =>
            OnCartItemChanged(p, 0);

        private void OnCartItemUpdated(object? _, Course p) =>
            OnCartItemChanged(p, p.CartQuantity);

        private void OnCartItemChanged(Course p, int quantity)
        {
            if (p.Name == Course.Name)
            {
                Course.CartQuantity = quantity;
            }
        }

        [ObservableProperty]
        private Course _course;

        [RelayCommand]
        private void AddToCart()
        {
            Course.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Course);
        }

        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Course.CartQuantity > 0)
            {
                Course.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Course);
            }
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if (Course.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Please select the quantity using the plus (+) button", ToastDuration.Short)
                    .Show();
            }
        }

        public void Dispose()
        {
            _cartViewModel.CartCleared -= OnCartCleared;
            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
        }
    }
}
