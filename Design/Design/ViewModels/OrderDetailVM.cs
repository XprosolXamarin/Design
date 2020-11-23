using Design.Models;
using Design.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Design.ViewModels
{
    public class OrderDetailVM : BaseViewModel
    {
        public OrderDetailModel orderDetails { get; set; }
        List<ProductModel> productsList = new List<ProductModel>();

        public CheckOutModel checkoutDetails { get; set; }

        public int _height { get; set; }
        public int height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                base.OnPropertyChanged();
            }
        }

        public OrderDetailVM()
        {
            orderDetails = new OrderDetailModel();

            for (int i = 0; i < 4; i++)
            {
                ProductModel product = new ProductModel();

                product.imageLink = "female.png";
                product.itemTitle = "White Dress";
                product.itemCategory = "Women>Dress";
                product.itemPrice = 15;
                product.purchasedQty = 1;

                productsList.Add(product);
            }

            //productsList = orderDetails.orderedProducts;
            orderDetails.orderedProducts = productsList;

            orderDetails.customerInstruction = "Order instructions from client would be there.";
            orderDetails.subTotal = 125;
            orderDetails.shipping = 0;
            orderDetails.deliveryNotes = "Delivery instructions from client would be there.";

            height = (110 * orderDetails.orderedProducts.Count);
        }

        #region Commands

        public Command<ProductModel> IncreaseQtyCommand
        {
            get
            {
                return new Command<ProductModel>((ProductModel product) =>
                {
                    product.purchasedQty += 1;
                });
            }
        }

        public Command<ProductModel> DecreaseQtyCommand
        {
            get
            {
                return new Command<ProductModel>((ProductModel product) =>
                {
                    product.purchasedQty -= 1;
                });
            }
        }

        public Command<ProductModel> RemoveItemFromCartCommand
        {
            get
            {
                return new Command<ProductModel>((ProductModel product) =>
                {
                    if (orderDetails.orderedProducts.Count > 1)
                    {
                        height -= 110;
                        orderDetails.orderedProducts.Remove(product);
                    }
                });
            }
        }

        public Command<string> CheckoutCommand
        {
            get
            {
                return new Command<string>((string pageNo) =>
                {
                    if (pageNo.Equals("pop"))
                    {
                        Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else if (pageNo.Equals("pushCheckout"))
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new CheckoutPage());
                    }
                    else if (pageNo.Equals("pushPayment"))
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new SetPaymentMethodPage());
                    }
                    else if (pageNo.Equals("pushSummary"))
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new SummaryPage());
                    }
                    else if (pageNo.Equals("pushOrderAccepted"))
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new OrderAcceptedPage());
                    }
                });
            }
        }

        #endregion
    }
}
