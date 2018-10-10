using System.Collections.Generic;
using Bussiness.DbContext;
using SalesBase.Models;

namespace SalesBase.ModelView
{
    public class CustomerVM
    {
        public CustomerVM()
        {
            Lst = new List<customer>();
        }

        public CustomerModel search { get; set; }
        public List<customer> Lst { get; set; }
        public int? PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int? ToTalPage { get; set; }
    }
}