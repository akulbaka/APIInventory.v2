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
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        public void Login_Clicked()
        {
            if (Settings.AccessToken.Equals("The user name or password is incorrect.")) DisplayAlert("Error",Settings.AccessToken,"OK");
            else Navigation.PushModalAsync(new ScansPage());
        }
    }
}