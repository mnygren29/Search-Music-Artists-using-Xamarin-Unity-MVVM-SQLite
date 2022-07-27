using BackToPrism.Models;
using Prism.Commands;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace BackToPrism.ViewModels
{
    public class ArtistsDetailsVM : INavigatedAware,INotifyPropertyChanged
    {
        Artist selectedArtist;       

        public ArtistsDetailsVM()
        {
           
        }       

        private string artistName;
        public string ArtistName
        {
            get { return artistName; }
            set
            {
                artistName = value;
                OnPropertyChanged("artistName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            selectedArtist = parameters["selected_artist"] as Artist;

            ArtistName = selectedArtist.name;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
