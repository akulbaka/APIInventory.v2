using Inventory.Helpers;
using Inventory.Models;
using Inventory.Services;
using Inventory.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inventory.ViewModels
{
    class AddSearchScanViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<ScanModels> _scans;
        public string Code { get; set; }
        public List<ScanModels> Scans
        {
            get { return _scans; }
            set
            {
                _scans = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddSearchScanCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        Scans = await _apiServices.SearchScansAsync(Settings.AccessToken, Code);
                        if (Scans.Count == 0)
                        {
                            await App.Current.MainPage.Navigation.PushModalAsync(new AddScanPage(Settings.TempString));
                        }
                        else
                        {
                            await App.Current.MainPage.Navigation.PushModalAsync(new SearchScanPage(Settings.TempString));
                        }

                    }
                    catch(Exception ex)
                    {
                       await App.Current.MainPage.DisplayAlert("Bład", ex.ToString(), "Ok");
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
