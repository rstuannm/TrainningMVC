using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.Model;

namespace Bussiness.IRepository
{
    public interface ICatalogRepository
    {
        catalog GetCatalog(catalog model);
        List<catalog> GetLst(catalog model, int? page, int numberRecord, out int totalRecord);
        bool Delete(int catalogId);
        bool Add(catalog model);
        bool Update(catalog model);
    }
}