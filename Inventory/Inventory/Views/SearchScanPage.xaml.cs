using Inventory.Models;
using System;
using System.Runtime.InteropServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchScanPage : ContentPage
    {
        public SearchScanPage([Optional]string passCode)
        {
            InitializeComponent();
            SearchField.Text = passCode;
            SearchButton.Command?.Execute(Button.CommandParameterProperty);
            
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var scan = e.Item as ScanModels;
            await Navigation.PushModalAsync(new EditScanPage(scan));
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}