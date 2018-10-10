using Bussiness.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IRepository
{
    public interface IBillPaymentOutRepository
    {
        bool Add(bill_payment_out model, List<details_bill_payment_out> detailsBill);
        //bool Update(bill_payment_out model, List<details_bill_payment_out> detailsBill);
        //void Delete(int productId);
    }
}
