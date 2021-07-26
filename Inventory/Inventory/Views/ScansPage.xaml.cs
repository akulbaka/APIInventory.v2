using Inventory.Helpers;
using Inventory.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScansPage : ContentPage
    {
        public ScansPage()
        {
            InitializeComponent();
        }

        private async void AddScan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FindScanPage());
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var scan = e.Item as ScanModels;
            await Navigation.PushModalAsync(new EditScanPage(scan));
        }

        private async void SearchScan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SearchScanPage());
        }

        private void SetTrainId(object sender, EventArgs e)
        {
            Settings.SetTrainId = Trainpicker.SelectedItem.ToString();
        }

        private void SetLineId(object sender, EventArgs e)
        {
            Settings.SetLineId = Linepicker.SelectedItem.ToString();
        }
    }
}