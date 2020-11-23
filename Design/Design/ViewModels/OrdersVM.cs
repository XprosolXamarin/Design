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
    public class OrdersVM : INotifyPropertyChanged
    {
        public List<OrdersModel> ordersList { get; set; }
        public OrdersModel _order { get; set; }
        public OrdersVM()
        {
            ordersList = new List<OrdersModel>();

            string[] statuses = { "Active", "Pending", "Completed" };

            for (int i = 0; i < 4; i++)
            {
               

                OrdersModel order = new OrdersModel();

                order.orderNum = 123456789;
                order.status = statuses[i % 3];
               
                order.orderDate = DateTime.Now.Date;
                order.orderTime = DateTime.Now;
                order.orderedItems = 3;

                ordersList.Add(order);
            }

            _order = new OrdersModel();

            _order.orderNum = 123456;
            _order.status = "Shipped";
            _order.orderSigned = new OrderMilestoneStatus { isCompleted = true, isCompleting = false };
            _order.orderSignedDate = DateTime.Now;
            _order.orderSignedPlace = "Melbourne Store";
            _order.orderProcessed = new OrderMilestoneStatus { isCompleted = true, isCompleting = false };
            _order.orderProcessedDate = DateTime.Now;
            _order.orderProcessedPlace = "Melbourne Store";
            _order.orderShipped = new OrderMilestoneStatus { isCompleted = false, isCompleting = true };
            _order.orderShippedDate = DateTime.Now;
            _order.orderShippedPlace = "Melbourne Store";
            _order.orderOutForDelivery = new OrderMilestoneStatus { isCompleted = false, isCompleting = false };
            _order.orderOutForDeliveryDate = DateTime.Now;
            _order.orderOutForDeliveryPlace = "Sydney, AU";
            _order.orderDelivered = new OrderMilestoneStatus { isCompleted = false, isCompleting = false };
            _order.orderDeliveredDate = DateTime.Now;
            _order.orderDeliveredPlace = "NSW, Sydney, AU";
            _order.orderedItems = 3;

        }
        #region Commands

        public Command<OrdersModel> ViewOrderDetailsCommand
        {
            get
            {
                return new Command<OrdersModel>((OrdersModel _order) =>
                {
                    // Navigate to order detail page
                    Application.Current.MainPage.Navigation.PushAsync(new OrderDetailPage(_order));
                });
            }
        }

        public Command<string> NavigationCommand
        {
            get
            {
                return new Command<string>((string pageNo) =>
                {
                    if (pageNo.Equals("popToRootAndPushTrackOrder"))
                    {
                        Application.Current.MainPage.Navigation.PopToRootAsync();
                        Application.Current.MainPage.Navigation.PushAsync(new UserTrackOrderPage());
                    }
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
