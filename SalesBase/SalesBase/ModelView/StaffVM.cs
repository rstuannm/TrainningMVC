using System.Collections.Generic;
using Bussiness.DbContext;
using SalesBase.Models;

namespace SalesBase.ModelView
{
    public class StaffVM
    {
        public StaffVM()
        {
            LstStaff = new List<staff>();
        }

        public StaffModel search { get; set; }
        public List<staff> LstStaff { get; set; }
        public int? PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int? ToTalPage { get; set; }
    }
}