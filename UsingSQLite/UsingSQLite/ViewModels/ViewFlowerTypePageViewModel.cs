using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UsingSQLite.Models;

namespace UsingSQLite.ViewModels
{
    public class ViewFlowerTypePageViewModel : ViewModelBase
    {
        public static ViewFlowerTypePageViewModel Instance { get; private set; }

        public ViewFlowerTypePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            InsertCommand = new DelegateCommand(InsertCommandExecute);
            UpdateCommand = new DelegateCommand(UpdateCommandExecute);
            ListFlowerType = new ObservableCollection<FlowerType>(App.Database.GetFlowerType());
            Instance = this;
        }

        #region Properties

        private string _flowerTypeName;

        public string FlowerTypeName
        {
            get => _flowerTypeName;
            set => SetProperty(ref _flowerTypeName, value);
        }

        private int _flowerID;

        private ObservableCollection<FlowerType> _listFlowerType;

        public ObservableCollection<FlowerType> ListFlowerType
        {
            get => _listFlowerType;
            set => SetProperty(ref _listFlowerType , value);
        }

        #endregion

        #region ItemTaped

        public void ItemTaped(FlowerType flowerType)
        {
            FlowerTypeName = flowerType.FlowerTypeName;
            _flowerID = flowerType.FlowerTypeID;
        }

        #endregion

        #region InsertCommand

        public ICommand InsertCommand { get; }

        private void InsertCommandExecute()
        {
            var flowerType = new FlowerType()
            {
                FlowerTypeName = FlowerTypeName
            };

            App.Database.InsertFlowerType(flowerType);

            GetListFlowerType();
        }

        #endregion

        #region UpDateCommand

        public ICommand UpdateCommand { get; set; }

        private void UpdateCommandExecute()
        {
            var flowerType = new FlowerType()
            {
                FlowerTypeName = FlowerTypeName,
                FlowerTypeID = _flowerID
            };

            App.Database.UpdateFlowerType(flowerType);

            GetListFlowerType();
        }

        #endregion

        #region GetListFlowerType

        private async void GetListFlowerType()
        {
            await Task.Run(() =>
            {
                ListFlowerType = new ObservableCollection<FlowerType>(App.Database.GetFlowerType());
            });
        }

        #endregion
    }
}
