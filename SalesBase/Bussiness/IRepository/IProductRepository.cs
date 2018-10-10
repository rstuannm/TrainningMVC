using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;

namespace Bussiness.IRepository
{
    public interface IProductRepository
    {
        product GetProductById(int id);
    }
}
