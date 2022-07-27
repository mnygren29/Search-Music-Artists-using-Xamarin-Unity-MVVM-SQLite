using BackToPrism.Models;
using Newtonsoft.Json;
using Prism.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace BackToPrism.ViewModels
{  
    public class NewArtistsVM
    {
        // ICommand SearchCommand { get; set; }
        public ObservableCollection<Artist> SearchResults { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public NewArtistsVM()
        {
            SearchResults = new ObservableCollection<Artist>();
            SearchCommand = new DelegateCommand<string>(GetSearchResults);
            SaveCommand = new DelegateCommand<Artist>(SaveArtist, CanSaveArtist);
        }

        private async void GetSearchResults(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync($"https://musicbrainz.org/ws/2/artist/?query={query}&fmt=json");
                var data = JsonConvert.DeserializeObject<Root>(result);
                SearchResults.Clear();
                foreach(var artist in data.artists)
                {
                    SearchResults.Add(artist);
                }
            }
        }

        private void SaveArtist(Artist artist)
        {
            

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Artist>();
                int recordsInserted = conn.Insert(artist);
                if (recordsInserted >= 1)
                {
                    App.Current.MainPage.DisplayAlert("Success", "Artist saved", "Ok");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Failure", "An error ocurred while saving the artist, please try again.", "Ok");
                }
            }
        }

        private bool CanSaveArtist(Artist artist)
        {
            return artist != null;
        }
    }
}
