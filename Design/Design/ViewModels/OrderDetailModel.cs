using Design.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design.ViewModels
{
    public class OrderDetailModel : BaseViewModel
    {
        public List<ProductModel> orderedProducts { get; set; }
        public string customerInstruction { get; set; }
        public int subTotal { get; set; }
        public int shipping { get; set; }
        public string deliveryNotes { get; set; }
        public int total => subTotal + shipping;
    }
}
