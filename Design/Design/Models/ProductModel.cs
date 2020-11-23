using Design.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Models
{
    public class ProductModel : BaseViewModel
    {
        public string imageLink { get; set; }
        public string itemTitle { get; set; }
        public string itemCategory { get; set; }
        public int oldPrice { get; set; }
        public int itemPrice { get; set; }
        public int discountPercent { get; set; }
        public string sellerName { get; set; }
        public int _purchasedQty { get; set; }
        public int purchasedQty
        {
            get { return _purchasedQty; }
            set { if (value > 0) _purchasedQty = value; else _purchasedQty = 1; base.OnPropertyChanged(); }
        }
        public int purchaseTotal => itemPrice * purchasedQty;
        public string itemDescription { get; set; }
        public string itemSize { get; set; }
        public string itemColor { get; set; }
       // public List<ItemSpecificationModel> itemSpecifications { get; set; }
      //  public List<ReviewModel> Reviews { get; set; }
    }
}
