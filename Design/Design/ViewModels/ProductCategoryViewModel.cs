using Design.Models;
using Design.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Design.ViewModels
{
  
   public class ProductCategoryViewModel : INotifyPropertyChanged
    {
        public INavigation navigation { get; set; }
        public List<ProductCategoryModel> categoryList { get; set; }

        public ProductCategoryModel _category;
        public ProductCategoryModel category
        {
            get
            {
                return _category;
            }
            set
            {
                if (value != null)
                {
                    _category = value;
                    //navigation.PushASync(new page(_category));
                    _category = null;
                    OnPropertyChanged();
                }
            }
        }

        public ProductCategoryViewModel()
        {
            categoryList = new List<ProductCategoryModel>();

            categoryList.Add(new ProductCategoryModel
            {
                imageLink = "FacebookLogo.png",
                noOfItems = 150,
                title = "Collections"
            });

            categoryList.Add(new ProductCategoryModel
            {
                imageLink = "FacebookLogo.png",
                noOfItems = 150,
                title = "Coats"
            });

            categoryList.Add(new ProductCategoryModel
            {
                imageLink = "FacebookLogo.png",
                noOfItems = 150,
                title = "Dresses"
            });
        }

        #region Commands

        public Command SearchCommand
        {
            get
            {
                return new Command(() =>
                {
                    navigation.PushAsync(new SearchPage());
                });
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
