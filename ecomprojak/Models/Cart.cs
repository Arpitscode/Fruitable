using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomprojak.Models
{
    public class Cart
    {
        public Tbl_Product product {  get; set; }
        public int quantity { get; set; }         
    }
}