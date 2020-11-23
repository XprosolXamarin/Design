using Design.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Design.ViewModels
{
   public class SettingsViewModel
    {
        public Command<string> NavigationCommand
        {
            get
            {
                return new Command<string>((string param) =>
                {
                    if (param.Equals("pushEditProfile"))
                    { }
                    else if (param.Equals("pushShippingAddress"))
                    { }
                    else if (param.Equals("pushWishList"))
                    { }
                    else if (param.Equals("pushOrderHistory"))
                    { }
                    else if (param.Equals("pushUserTrackOrder"))
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new UserTrackOrderPage());
                    }
                    else if (param.Equals("pushCards"))
                    { }
                    else if (param.Equals("pushNotifications"))
                    { }
                    else if (param.Equals("pushNotifications"))
                    { }
                });
            }
        }
    }
}
