using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Models
{
    public class CheckOutModel
    {
        public bool isBillingAddressSameAsDeliveryAddress { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string paymentType { get; set; }
        public string nameOnCard { get; set; }
        public string cardNumber { get; set; }
        public DateTime expiryDate { get; set; }
        public int cvv { get; set; }
        public bool saveCard { get; set; }

    }
}
