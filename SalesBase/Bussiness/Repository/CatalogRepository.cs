﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.IRepository;
using Bussiness.Model;

namespace Bussiness.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        
        ProductContext _db = new ProductContext();
        public bool Add(catalog model)
        {
            try
            {
                _db.catalogs.Add(model);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public void Delete(int catalogId)
        {
            var a = (from u in _db.catalogs
                     where u.id.Equals(catalogId)
                     && u.del_flg == false
                     select u).FirstOrDefault();
            if (a != null)
            {
                a.del_flg = true;
                _db.SaveChanges();
            }
        }

        //public catalog GetCatalog(catalog model)
        //{
        //    throw new NotImplementedException();
        //}

        public catalog GetCatalog(catalog model)
        {

            var a = (from u in _db.catalogs
                     where (model.id == 0 || u.id == model.id)
                     && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
                     select u).FirstOrDefault();
            return a;                     

        }

        public List<catalog> GetLst(catalog model)
        {
            var a = (from u in _db.catalogs
                     where (model.id == 0 || u.id == model.id)
                     && (string.IsNullOrEmpty(model.name) || u.name.Contains(model.name))
                     && u.del_flg == false
                     select u).ToList();
            return a;

        }

        public bool Update(catalog model)
        {
            try
            {
                var a = (from u in _db.catalogs
                         where u.id == model.id
                         && u.del_flg == false
                         select u).FirstOrDefault();
                if (a == null)
                {
                    return false;
                }
                else
                {
                    a.name = model.name;
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