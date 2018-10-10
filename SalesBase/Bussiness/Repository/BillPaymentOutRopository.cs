using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.IRepository;

namespace Bussiness.Repository
{
    public class BillPaymentOutRopository : IBillPaymentOutRepository
    {
        private readonly ProductContext _db = new ProductContext();
        public bool Add(bill_payment_out model, List<details_bill_payment_out> detailsBill)
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

        //public void Delete(int productId)
        //{
        //    var a = (from u in _db.bill_payment_in
        //             where u.id.Equals(productId)
        //             && u.del_flg == false
        //             select u).FirstOrDefault();
        //    if (a != null)
        //    {
        //        a.del_flg = true;
        //        _db.SaveChanges();
        //    }
        //}

        //public bool Update(bill_payment_out model, List<details_bill_payment_out> detailsBill)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
