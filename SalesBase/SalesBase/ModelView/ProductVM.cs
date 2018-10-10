using System.Collections.Generic;
using Bussiness.DbContext;
using SalesBase.Models;

namespace SalesBase.ModelView
{
    public class ProductVM
    {
        public ProductVM()
        {
            Lst = new List<product>();
        }

        public ProductModel search { get; set; }
        public List<product> Lst { get; set; }
        public int? PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int? ToTalPage { get; set; }
    }
}