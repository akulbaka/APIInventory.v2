using Inventory.Services;
using System.Windows.Input;
using Xamarin.Forms;
using Inventory.Helpers;
using Inventory.Views;
using System.Diagnostics;

namespace Inventory.ViewModels
{
    class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private async void Login()
        {
            Debug.WriteLine("login = " + Username + " / haslo = " + Password);
            var accesstoken = await _apiServices.LoginAsync(Username, Password);
            Settings.AccessToken = accesstoken;

            if (Settings.AccessToken.Equals("Login lub hasło jest błędne")) await App.Current.MainPage.DisplayAlert("Error", Settings.AccessToken, "OK");
            else await App.Current.MainPage.Navigation.PushModalAsync(new ScansPage());
        }
    }
}
