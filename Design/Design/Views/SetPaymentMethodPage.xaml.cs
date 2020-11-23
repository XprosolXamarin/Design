﻿using Design.ViewModels;
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
    public partial class SetPaymentMethodPage : ContentPage
    {
        public SetPaymentMethodPage()
        {
            InitializeComponent();
            BindingContext = new OrderDetailVM();
        }
    }
}