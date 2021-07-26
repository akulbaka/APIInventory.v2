using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddScanPage : ContentPage
    {
        public AddScanPage([Optional]string Code)
        {
            InitializeComponent();
            CodeEntry.Text = Code;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}