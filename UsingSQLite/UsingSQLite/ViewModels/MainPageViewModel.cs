using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UsingSQLite.Utilities;

namespace UsingSQLite.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ViewFlowerCommand = new DelegateCommand(ViewFlowerCommandExecute);
            ViewFlowerTypeCommand = new DelegateCommand(ViewFlowerTypeCommandExecute);
        }

        #region ViewFlowerType

        public ICommand ViewFlowerTypeCommand { get; }

        private void ViewFlowerTypeCommandExecute()
        {
            NavigationService.NavigateAsync(PageManager.ViewFlowerTypePage);
        }

        #endregion

        #region ViewFlower

        public ICommand ViewFlowerCommand { get; }

        private void ViewFlowerCommandExecute()
        {
            NavigationService.NavigateAsync(PageManager.ViewFlowerPage);
        }

        #endregion
    }
}
