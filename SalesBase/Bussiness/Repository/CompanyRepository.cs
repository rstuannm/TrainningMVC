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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ProductContext _db = new ProductContext();
        //ProductContext _db = new ProductContext();
        public bool Add(company model)
        {
            try
            {
                _db.companies.Add(model);
                _db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Delete(string companyCd)
        {
            var a = (from u in _db.companies
                     where u.company_cd.Equals(companyCd)
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

        public company GetCompany(company model)
        {
            var a = (from u in _db.companies
                     where (string.IsNullOrEmpty(model.company_cd) || u.company_cd.Equals(model.company_cd))
                         && (string.IsNullOrEmpty(model.company_name) || u.company_name.Equals(model.company_name))
                         && (string.IsNullOrEmpty(model.company_short_name) || u.company_short_name.Equals(model.company_short_name))
                         && (string.IsNullOrEmpty(model.address) || u.address.Equals(model.address))
                         && (string.IsNullOrEmpty(model.tel) || u.tel.Equals(model.tel))
                         && (string.IsNullOrEmpty(model.fax) || u.fax.Equals(model.fax))
                         && (string.IsNullOrEmpty(model.phone) || u.phone.Equals(model.phone))
                     select u).FirstOrDefault();
            return a;

        }

        public company GetCompanyById(string id)
        {
            var a = (from u in _db.companies
                     where u.company_cd.Equals(id)
                     && u.del_flg.Equals(false)
                     select u).FirstOrDefault();
            return a;
        }

        public List<company> GetLst(company model, int? page, int numberRecord, out int totalRecord)
        {
            //throw new NotImplementedException();
            var a = (from u in _db.companies
                     where (string.IsNullOrEmpty(model.company_cd) || u.company_cd.Equals(model.company_cd))
                         && (string.IsNullOrEmpty(model.company_name) || u.company_name.Contains(model.company_name))
                         && (string.IsNullOrEmpty(model.company_short_name) || u.company_name.Equals(model.company_name))
                         && (string.IsNullOrEmpty(model.address) || u.address.Equals(model.address))
                         && (string.IsNullOrEmpty(model.tel) || u.tel.Equals(model.tel))
                         && (string.IsNullOrEmpty(model.fax) || u.fax.Equals(model.fax))
                         && (string.IsNullOrEmpty(model.phone) || u.phone.Equals(model.phone))
                         && u.del_flg.Equals(false)
                     select u);
            totalRecord = a.Count();

            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }

        public bool Update(company model)
        {
            try
            {
                var a = (from u in _db.companies
                         where u.company_cd.Equals(model.company_cd)
                         && u.del_flg.Equals(false)
                         select u).FirstOrDefault();
                if (a == null)
                {
                    return false;
                }
                else
                {
                    a.company_name = model.company_name;
                    a.company_short_name = model.company_short_name;
                    a.address = model.address;
                    a.tel = model.tel;
                    a.fax = model.fax;
                    a.phone = model.phone;
                    a.update_user = model.update_user;
                    a.update_date = model.update_date;
                    _db.SaveChanges();
                    return true;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
