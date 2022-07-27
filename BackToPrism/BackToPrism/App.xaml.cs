using System;
using Xamarin.Forms;
using Prism;
using Xamarin.Forms.Xaml;
using Prism.Unity;

using Prism.Ioc;
using BackToPrism.Views;
using BackToPrism.ViewModels;

namespace BackToPrism
{
    public partial class App : PrismApplication
    {

        public static string DatabasePath;
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }

        public App(string databasePath, IPlatformInitializer initializer = null) : base(initializer)
        {
            DatabasePath = databasePath;
            //prism version of establishing new app
            NavigationService.NavigateAsync("NavigationPage/ArtistsPage");
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
          
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ArtistsPage, ArtistsVM>();
            containerRegistry.RegisterForNavigation<NewArtistsPage, NewArtistsVM>();
            containerRegistry.RegisterForNavigation<ArtistsDetailsPage, ArtistsDetailsVM>();
        }
    }
}