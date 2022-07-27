using BackToPrism.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BackToPrism.ViewModels
{

    public class ArtistsVM:IPageLifecycleAware
    {
        public ICommand ArtistsDetailCommand { get; set; }
        public ICommand NewArtistCommand { get; set; }
        public ObservableCollection<Artist> SavedArtists { get; set; }

        INavigationService _navigationService;
        public ArtistsVM(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NewArtistCommand = new DelegateCommand(NewArtistAction);
            SavedArtists = new ObservableCollection<Artist>();
            ArtistsDetailCommand = new DelegateCommand<object>(GoToDetail, CanGoToDetails);
            ViewSavedArtist();
        }
        private async void GoToDetail(object obj)
        {
            var selectedArtist = (obj as ListView).SelectedItem as Artist;
            var parameter = new NavigationParameters();
            parameter.Add("selected_artist", selectedArtist);
            await _navigationService.NavigateAsync("ArtistsDetailsPage", parameter);
        }

        private bool CanGoToDetails(object arg)
        {
            return arg != null;
        }

        private void ViewSavedArtist()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Artist>();
                    var artists = conn.Table<Artist>().ToList();

                    SavedArtists.Clear();
                    foreach (var artist in artists)
                    {
                        SavedArtists.Add(artist);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        private async void NewArtistAction()
        {
            await _navigationService.NavigateAsync("NewArtistsPage");
        }

        public void OnAppearing()
        {
            ViewSavedArtist();
        }
        public void OnDisappearing()
        {

        }
     }
}
