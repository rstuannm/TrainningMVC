using Bussiness.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.IRepository
{
    public interface IBillPaymentInRepository
    {
        bool Add(bill_payment_in model, List<details_bill_payment_in> detailsBill);

        //bool Update(bill_payment_in model, List<details_bill_payment_in> detailsBill);
        //void Delete(int producId); //List<details_bill_payment_in> detailsBill// );

        //bill_payment_in GetBillIn(bill_payment_in model);
        //List<bill_payment_in> GetLst(bill_payment_in model);
    }
}
