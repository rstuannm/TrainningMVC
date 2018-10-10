using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.IRepository;

namespace Bussiness.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _db = new ProductContext();

        public product GetProductById(int id)
        {
            var a = (from u in _db.products
                     where u.id.Equals(id)
                            && u.del_flg.Equals(false)
                     select u).FirstOrDefault();
            return a;
        }
    }
}
