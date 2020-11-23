using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Design.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen2 : ContentPage
    {
        public SplashScreen2()
        {
            InitializeComponent();
            _ = LongRunningOperationAsync();
        }
        public async Task<int> LongRunningOperationAsync()
        {
            await Task.Delay(3000); // 3 second delay
            Application.Current.MainPage = new NavigationPage(new LoginPage());

            return 1;
        }
    }
}