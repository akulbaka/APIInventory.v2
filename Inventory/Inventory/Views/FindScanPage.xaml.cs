using Inventory.Helpers;
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
    public partial class FindScanPage : ContentPage
    {
        public FindScanPage()
        {
            InitializeComponent();
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            Settings.TempString = CodeEntry.Text;                     // Do poprawy
            CodeEntry.Text = "";
        }
    }
}