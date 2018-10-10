using System.Collections.Generic;
using Bussiness.DbContext;
using SalesBase.Models;

namespace SalesBase.ModelView
{
    public class CatalogVM
    {
        public CatalogVM()
        {
            Lst = new List<catalog>();
        }

        public CatalogModel search { get; set; }
        public List<catalog> Lst { get; set; }
        public int? PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int? ToTalPage { get; set; }
    }
}