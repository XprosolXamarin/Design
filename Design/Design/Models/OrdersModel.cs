using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Models
{
    public class OrdersModel
    {
        public int orderNum { get; set; }
        public string status { get; set; }
        public OrderMilestoneStatus orderSigned { get; set; }
        public string orderSignedPlace { get; set; }
        public DateTime orderSignedDate { get; set; }
        public OrderMilestoneStatus orderProcessed { get; set; }
        public string orderProcessedPlace { get; set; }
        public DateTime orderProcessedDate { get; set; }
        public OrderMilestoneStatus orderShipped { get; set; }
        public string orderShippedPlace { get; set; }
        public DateTime orderShippedDate { get; set; }
        public OrderMilestoneStatus orderOutForDelivery { get; set; }
        public string orderOutForDeliveryPlace { get; set; }
        public DateTime orderOutForDeliveryDate { get; set; }
        public OrderMilestoneStatus orderDelivered { get; set; }
        public string orderDeliveredPlace { get; set; }
        public DateTime orderDeliveredDate { get; set; }
        public string imageLink { get; set; }
       
        public List<ProductModel> products { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime orderTime { get; set; }
        public int orderedItems { get; set; }
    }

    public class OrderMilestoneStatus
    {
        public bool isCompleting { get; set; }
        public bool isCompleted { get; set; }
        public bool visibility => (isCompleting || isCompleted);
    }
}
