using Design.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Design
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _ = LongRunningOperationAsync();
        }

        public async Task<int> LongRunningOperationAsync()
        {
            await Task.Delay(3000); // 3 second delay
            Application.Current.MainPage = new NavigationPage(new SplashScreen2());

            return 1;
        }
    }
}
