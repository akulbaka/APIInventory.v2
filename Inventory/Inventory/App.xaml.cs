using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using Inventory.Views;
using Inventory.Helpers;

namespace Inventory
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        private void SetMainPage()
        {
        } 

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
