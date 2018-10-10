using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.DbContext;
using Bussiness.Model;

namespace Bussiness.IRepository
{
    public interface ICustomerRepository
    {
        customer GetCustomerById(string id);
        customer GetCustomer(customer model);

        List<customer> GetLst(customer model, int? page, int numberRecord, out int totalRecord);

        bool Delete(string userCd);

        bool Add(customer model);
        bool Update(customer model);
        //object GetCustomer(customer model);
    }
}
