using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.IRepository;
using Bussiness.Model;

namespace Bussiness.Repository
{
    public class CustomerRespository : ICustomerRepository
    {
        
        //ProductContext _db = new ProductContext();
        private readonly ProductContext _db = new ProductContext();



        public bool Add(customer model)
        {
            try
            {
                _db.customers.Add(model);
                _db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Delete(string userCd)
        {
            var a = (from u in _db.customers
                     where u.user_cd.Equals(userCd)
                     && u.del_flg.Equals(false)
                     select u).FirstOrDefault();

            if (a != null)
            {
                a.del_flg = true;
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public customer GetCustomer(customer model)
        {
            var a = (from u in _db.customers
                     where (string.IsNullOrEmpty(model.user_cd) || u.user_cd.Equals(model.user_cd))
                     && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
                     && (string.IsNullOrEmpty(model.user_name) || u.user_name.Equals(model.user_name))
                     && (string.IsNullOrEmpty(model.pass_word) || u.pass_word.Equals(model.pass_word))
                     && (string.IsNullOrEmpty(model.mobile) || u.mobile.Equals(model.mobile))
                     && (string.IsNullOrEmpty(model.adress) || u.adress.Equals(model.adress))
                     && (model.sex == null || u.sex == model.sex)
                     select u).FirstOrDefault();

            return a;
        }

        public customer GetCustomerById(string id)
        {
            var a = (from u in _db.customers
                     where u.user_cd.Equals(id)
                     && u.del_flg.Equals(false)
                     select u).FirstOrDefault();

            return a;
        }

        public List<customer> GetLst(customer model, int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.customers
                     where (string.IsNullOrEmpty(model.user_cd) || u.user_cd.Equals(model.user_cd))
                         && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
                         && (string.IsNullOrEmpty(model.user_name) || u.user_name.Equals(model.user_name))
                         && (string.IsNullOrEmpty(model.pass_word) || u.pass_word.Equals(model.pass_word))
                         && (string.IsNullOrEmpty(model.mobile) || u.mobile.Equals(model.mobile))
                         && (string.IsNullOrEmpty(model.adress) || u.adress.Equals(model.adress))
                         && (model.sex == null || u.sex.Equals(model.sex))
                         && u.del_flg.Equals(false)
                         select u);
            totalRecord = a.Count();

            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }

        public bool Update(customer model)
        {
            try
            {
                var a = (from u in _db.customers
                         where u.user_cd.Equals(model.user_cd)
                         && u.del_flg.Equals(false)
                         select u).FirstOrDefault();
                if (a == null)
                {
                    return false;
                }
                else
                {
                    a.name = model.name;
                    a.pass_word = model.pass_word;
                    a.mobile = model.mobile;
                    a.email = model.email;
                    a.adress = model.adress;
                    a.sex = model.sex;
                    a.update_date = model.update_date;
                    a.update_user = model.update_user;
                    _db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
