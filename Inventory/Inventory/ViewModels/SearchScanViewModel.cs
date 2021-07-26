using Inventory.Helpers;
using Inventory.Models;
using Inventory.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inventory.ViewModels
{
    class SearchScanViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<ScanModels> _scans;
        public string Keyword { get; set; }
        public List<ScanModels> Scans
        {
            get { return _scans; }
            set
            {
                _scans = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchScanCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Scans = await _apiServices.SearchScansAsync(Settings.AccessToken, Keyword);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
