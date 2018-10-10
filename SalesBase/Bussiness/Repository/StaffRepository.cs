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
    public class StaffRepository : IStaffRepository
    {
        ProductContext _db = new ProductContext();
        public staff GetStaff(staff model)
        {
            var a = (from u in _db.staffs
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

        public List<staff> GetLst(staff model, int? page, int numberRecord, out int totalRecord)
        {
            var a = (from u in _db.staffs
                     where (string.IsNullOrEmpty(model.user_cd) || u.user_cd.Equals(model.user_cd))
                         && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
                         && (string.IsNullOrEmpty(model.user_name) || u.user_name.Equals(model.user_name))
                         && (string.IsNullOrEmpty(model.pass_word) || u.pass_word.Equals(model.pass_word))
                         && (string.IsNullOrEmpty(model.mobile) || u.mobile.Equals(model.mobile))
                         && (string.IsNullOrEmpty(model.adress) || u.adress.Equals(model.adress))
                         && (model.sex == null || u.sex == model.sex)
                         && u.del_flg.Equals(false)
                     select u);
            totalRecord = a.Count();

            return a.ToList().Skip((page.GetValueOrDefault() - 1) * numberRecord).Take(numberRecord).ToList();
        }

        public bool Delete(string userCd)
        {
            var a = (from u in _db.staffs
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

        public bool Add(staff model)
        {
            try
            {
                _db.staffs.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(staff model)
        {
            try
            {
                var a = (from u in _db.staffs
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

        //public List<StaffModel> GetLstStaff()
        //{
        //    var a = (from u in _db.staffs
        //             select new StaffModel
        //             {
        //                 user_cd = u.user_cd,
        //                 name = u.name,
        //                 user_name = u.user_name,
        //                 pass_word = u.pass_word,
        //                 mobile = u.mobile,
        //                 email = u.email,
        //                 adress = u.adress,
        //                 sex = u.sex,
        //                 del_flg = u.del_flg,
        //                 create_user = u.create_user,
        //                 create_date = u.create_date,
        //                 update_user = u.update_user,
        //                 update_date = u.update_date
        //             }).ToList();
        //    return a;
        //}

    }
}
