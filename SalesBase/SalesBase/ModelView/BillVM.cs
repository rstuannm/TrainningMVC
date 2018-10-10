using System.Collections.Generic;
using Bussiness.DbContext;
using SalesBase.Models;

namespace SalesBase.ModelView
{
    public class BillVM
    {
        public BillVM()
        {
            Lst = new List<product>();
            cutomer = new CustomerModel();
            product = new ProductModel();
        }
        public CustomerModel cutomer { get; set; }
        public ProductModel product { get; set; }
        public List<product> Lst { get; set; }
        public int? PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int? ToTalPage { get; set; }
    }
}