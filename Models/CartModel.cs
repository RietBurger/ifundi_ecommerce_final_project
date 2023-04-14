using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace mvc_ecommerce_tutorial.Models
{
    public class CartModel
    {
        public string cartID {get; set;}
        public string orderID {get; set;}
        public string userID {get; set;}
        public string prodID {get; set;}
        public string qtySelected {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        public string price {get; set;} // perhaps this should be float...
        public string imgSrc {get; set;}
        public string categoryName {get; set;}
        public int Total {get; set;} // to be calculated...
        public string grandTotal {get; set;}
    }
}