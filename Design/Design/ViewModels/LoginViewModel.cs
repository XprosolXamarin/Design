using Design.Models;
using Design.Services;
using Design.Utlities;
using Design.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Design.ViewModels
{
    public class LoginViewModel :BaseViewModel
    {
        private INavigation navigation1;
        public LoginViewModel(INavigation navigation)
        {
            this.navigation1 = navigation;
        }
        private readonly LoginApi _LoginapiServices = new LoginApi();

        private bool _Isbusy;

        public bool Isbusy
        {
            get
            {
                return _Isbusy;
            }
            set
            {
                _Isbusy = value;
                if (_Isbusy)
                {
                   // Application.Current.MainPage.Navigation.PushPopupAsync(new IndicatorActity());

                }
                else
                {
                  //  Application.Current.MainPage.Navigation.PopPopupAsync();

                }

                OnPropertyChanged();
            }
        }
        public clsResponse response1 = new clsResponse();
       
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {


                    Isbusy = true;
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        response1 = await _LoginapiServices.LoginUserAsync(Username, Password);
                        Isbusy = false;
                          await Application.Current.MainPage.DisplayAlert("Alert", response1.Message, "ok");
                        if (response1.Status)
                        {
                            try
                            {

                                await Utilty.SetSecureStorageValue(Utilty.UserName, Username);
                                await Utilty.SetSecureStorageValue(Utilty.Password, Password);
                            }
                            catch (Exception ex)
                            {
                                // Possible that device doesn't support secure storage on device.
                            }

                            //Isbusy = false;
                           // Application.Current.MainPage = new NavigationPage(new orderApp.Views.BarcodePage());
                            //await Application.Current.MainPage.DisplayAlert("Alert", jObject.GetValue("message").ToString(), "OK");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Alert", response1.Message, "ok");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Please Connect with Internet.", "ok");
                        Isbusy = false;

                    }


                    // await Application.Current.MainPage.Navigation.PushPopupAsync(new IndicatorActity());
                    // await RegisterUserAsync(Username, Password);


                });
            }
        }
        public ICommand NavigateToSignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    navigation1.PushAsync(new Register());

                });
            }
        }
    }
}
