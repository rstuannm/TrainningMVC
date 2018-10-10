using System.Collections.Generic;
using Bussiness.DbContext;
using SalesBase.Models;

namespace SalesBase.ModelView
{
    public class CompanyVM
    {
        public CompanyVM()
        {
            Lst = new List<company>();
        }

        public CompanyModel search { get; set; }
        public List<company> Lst { get; set; }
        public int? PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int? ToTalPage { get; set; }
    }
}