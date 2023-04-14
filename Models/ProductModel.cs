using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace mvc_ecommerce_tutorial.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Price {get; set; }
        public string Qty {get; set; }
        public int QtySelected {get; set;}
        public string ImgSource {get; set; }
        public string ProdID {get; set; }
        public string CatID {get; set; }
        public string CategoryName {get; set; }
        public string FileName { get; set; }
        public IFormFile file {get; set;}
    }
}