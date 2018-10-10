using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.Model;

namespace Bussiness.IRepository
{
    public interface ICompanyRepository
    {
        company GetCompanyById(string id);
        company GetCompany(company model);
        List<company> GetLst(company model, int? page, int numberRecord, out int totalRecord);

        bool Delete(string companyCd);
        bool Add(company model);
        bool Update(company model);

    }
}
