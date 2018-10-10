using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;

namespace Bussiness.IRepository
{
    public interface IProductsRepository
    {
        product GetProduct(product model);
        product GetProductById(int id);
        //product GetCatalog(product model);
        List<product> GetLst(product model, int? page, int numberRecord, out int totalRecord);
        bool Delete(int productId);
        bool Add(product model);
        bool Update(product model);
    }
}
