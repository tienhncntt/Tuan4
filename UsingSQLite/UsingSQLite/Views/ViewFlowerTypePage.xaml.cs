using UsingSQLite.Models;
using UsingSQLite.ViewModels;
using Xamarin.Forms;

namespace UsingSQLite.Views
{
    public partial class ViewFlowerTypePage : ContentPage
    {
        public ViewFlowerTypePage()
        {
            InitializeComponent();
        }

        private void ListFlowerType_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelected = ((ListView)sender).SelectedItem as FlowerType;
            ViewFlowerTypePageViewModel.Instance.ItemTaped(itemSelected);
        }
    }
}
