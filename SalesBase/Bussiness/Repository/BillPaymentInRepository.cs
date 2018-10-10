using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.IRepository;


namespace Bussiness.Repository
{
    public class BillPaymentInRepository : IBillPaymentInRepository
    {
        private readonly ProductContext _db = new ProductContext();
        public bool Add(bill_payment_in model, List<details_bill_payment_in> detailsBill)
        {
            using (var dbContextTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.bill_payment_in.Add(model);
                    _db.SaveChanges();

                    foreach (var item in detailsBill)
                    {
                        item.bill_id = model.id;
                    }

                    _db.details_bill_payment_in.AddRange(detailsBill);
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

    //    public void Delete(int producId)//, List<details_bill_payment_in> detailsBill)
    //    {
    //        //using (var dbContextTransaction = _db.Database.BeginTransaction())
    //        //{
    //            var a = (from u in _db.bill_payment_in
    //                     where u.id.Equals(producId)
    //                     && u.del_flg == false
    //                     select u).FirstOrDefault();
    //            if (a != null)
    //            {
    //                a.del_flg = true;
    //                _db.SaveChanges();

    //                //foreach (var item in detailsBill)
    //                //{
    //                //    item.bill_id = 

    //                //}
    //            }
    //        //}

    //    }

    //    public bill_payment_in GetBillIn(bill_payment_in model)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<bill_payment_in> GetLst(bill_payment_in model)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Update(bill_payment_in model, List<details_bill_payment_in> detailsBill)
    //    {
    //        throw new NotImplementedException();
    //    }
    }

}
