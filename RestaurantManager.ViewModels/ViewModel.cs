using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Models;


namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }
        protected ViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
