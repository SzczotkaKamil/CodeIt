using CommunityToolkit.Mvvm.ComponentModel;

namespace CodeIt.Models
{
    public partial class Course : ObservableObject
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        public double Amount => CartQuantity * Price;

        public Course Clone() => MemberwiseClone() as Course;
    }
}
