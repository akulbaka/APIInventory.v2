using Inventory.Models;
using Inventory.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using Inventory.Helpers;

namespace Inventory.ViewModels
{
    class ScansViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<ScanModels> _scans;

        public List<ScanModels> Scans
        {
            get { return _scans; }
            set
            {
                _scans = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetScansCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var accessToken = Settings.AccessToken;
                        Scans = await _apiServices.GetScansAsync(accessToken);
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine("ERROR: " + ex);
                    }
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
