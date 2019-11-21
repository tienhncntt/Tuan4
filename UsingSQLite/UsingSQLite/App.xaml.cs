using Prism;
using Prism.Ioc;
using System;
using System.IO;
using UsingSQLite.Helpers;
using UsingSQLite.Utilities;
using UsingSQLite.ViewModels;
using UsingSQLite.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UsingSQLite
{
    public partial class App
    {
        static SQLiteService _database;
        public static SQLiteService Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SQLiteService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db3"));
                }
                return _database;
            }
        }
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{PageManager.NavigationPage}/{PageManager.MainPage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>(PageManager.MainPage);
            containerRegistry.RegisterForNavigation<ViewFlowerTypePage>(PageManager.ViewFlowerTypePage);
            containerRegistry.RegisterForNavigation<ViewFlowerPage>(PageManager.ViewFlowerPage);
        }
    }
}
