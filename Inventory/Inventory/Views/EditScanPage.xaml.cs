using Inventory.Models;
using Inventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditScanPage : ContentPage
    {
        public EditScanPage(ScanModels scan)
        {
            var editScanViewModel = new EditScanViewModel();
            editScanViewModel.Scan = scan;

            BindingContext = editScanViewModel;

            InitializeComponent();        
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}