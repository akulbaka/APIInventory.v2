using Inventory.Helpers;
using Inventory.Models;
using Inventory.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inventory.ViewModels
{
    public class EditScanViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public ScanModels Scan { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.PutScanAsync(Scan, Settings.AccessToken);
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.DeleteScanAsync(Scan.Id, Settings.AccessToken);
                });
            }
        }
    }
}
