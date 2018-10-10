using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.IRepository;

namespace Bussiness.Repository
{
    public class BillPaymentOutRepository : IBillPaymentOutRepository
    {
        private readonly ProductContext _db = new ProductContext();
        public bool Add(bill_payment_out model,List<details_bill_payment_out> detailsBill)
        {
            using (var dbContextTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.bill_payment_out.Add(model);
                    _db.SaveChanges();

                    foreach (var item in detailsBill)
                    {
                        item.bill_id = model.id;
                        //_db.details_bill_payment_out.AddRange(detailsBill);
                    }

                    _db.details_bill_payment_out.AddRange(detailsBill);
                    _db.SaveChanges();


                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }
    }
}
