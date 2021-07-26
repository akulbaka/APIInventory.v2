using Inventory.Helpers;
using Inventory.Models;
using Inventory.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inventory.ViewModels
{
    public class AddScanViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICommand AddCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var scan = new ScanModels
                    {
                        Code = Code,
                        Name = Name,
                        Description = Description,
                        TrainId = Settings.SetTrainId,
                        LineId = Settings.SetLineId
                    };
                    var response = await _apiServices.PostScanAsync(scan, Settings.AccessToken);
                    Debug.WriteLine("RESPONSE = " + response);
                    if(response.Equals("Created"))
                    {
                        await App.Current.MainPage.DisplayAlert("OK", "Dodano pomyślnie", "OK");
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Coś poszło nie tak", "OK");
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                });
            }
        }
    }
}
