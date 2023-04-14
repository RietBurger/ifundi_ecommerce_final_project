using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace mvc_ecommerce_tutorial.Models
{
    public class CheckoutModel
    {
        public string userID {get; set;}
        public string orderID {get; set;}
        public string Total {get; set;}
        public Int32 lineItemCount {get; set;}
        public string PaymentID {get; set;}
        public bool PaymentSuccessInd {get; set;}
        public string orderDate {get; set;} // or should this just be set in DB?
    }
}