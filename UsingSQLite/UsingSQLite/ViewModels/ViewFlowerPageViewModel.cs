using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using UsingSQLite.Models;

namespace UsingSQLite.ViewModels
{
    public class ViewFlowerPageViewModel : ViewModelBase
    {
        public static ViewFlowerPageViewModel Instance { get; private set; }
        public ViewFlowerPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Instance = this;
            ListFlowerType = new ObservableCollection<FlowerType>(App.Database.GetFlowerType());
        }

        #region Properties

        private string _FlowerName;

        public string FlowerName
        {
            get => _FlowerName;
            set => SetProperty(ref _FlowerName, value);
        }

        private string _Description;

        public string Description
        {
            get => _Description;
            set => SetProperty(ref _Description, value);
        }

        private int _Price;

        public int Price
        {
            get => _Price;
            set => SetProperty(ref _Price, value);
        }

        private int _flowerID;

        private ObservableCollection<Flower> _listFlower;

        public ObservableCollection<Flower> ListFlower
        {
            get => _listFlower;
            set => SetProperty(ref _listFlower, value);
        }

        private ObservableCollection<FlowerType> _listFlowerType;

        public ObservableCollection<FlowerType> ListFlowerType
        {
            get => _listFlowerType;
            set => SetProperty(ref _listFlowerType, value);
        }

        private FlowerType _flowerType;

        public FlowerType FlowerType
        {
            get => _flowerType;
            set => SetProperty(ref _flowerType, value);
        }

        private int _flowerTypeID;

        #endregion

        #region ItemTaped

        public void ItemTaped(Flower Flower)
        {
            FlowerName = Flower.FlowerName;
            Description = Flower.Description;
            Price = Flower.Price;
            FlowerType = App.Database.GetFlowerTypeByID(Flower.FlowerTypeID);
            _flowerTypeID = Flower.FlowerTypeID;
            _flowerID = Flower.FlowerID;
        }

        #endregion

        #region InsertCommand

        public ICommand InsertCommand { get; }

        private void InsertCommandExecute()
        {
            var Flower = new Flower()
            {
                FlowerName = FlowerName,
                Description = Description,
                FlowerTypeID = FlowerType.FlowerTypeID,
                Price = Price,
            };

            App.Database.InsertFlower(Flower);

            GetListFlower();
        }

        #endregion

        #region UpDateCommand

        public ICommand UpdateCommand { get; set; }

        private void UpdateCommandExecute()
        {
            var Flower = new Flower()
            {
                FlowerName = FlowerName,
                Description = Description,
                FlowerTypeID = FlowerType.FlowerTypeID,
                Price = Price,
            };

            App.Database.UpdateFlower(Flower);

            GetListFlower();
        }

        #endregion

        #region GetListFlower

        private async void GetListFlower()
        {
            await Task.Run(() =>
            {
                ListFlower = new ObservableCollection<Flower>(App.Database.GetFlower());
            });
        }

        #endregion
    }
}
