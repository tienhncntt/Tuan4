using UsingSQLite.Models;
using UsingSQLite.ViewModels;
using Xamarin.Forms;

namespace UsingSQLite.Views
{
    public partial class ViewFlowerPage : ContentPage
    {
        public ViewFlowerPage()
        {
            InitializeComponent();
        }

        private void ListFlower_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelected = ((ListView)sender).SelectedItem as Flower;
           // ViewFlowerPageViewModel.Instance.ItemTaped(itemSelected);
        }
    }
}
