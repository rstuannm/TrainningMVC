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
    public interface IStaffRepository
    {
        staff GetStaff(staff model);
        List<staff> GetLst(staff model, int? page, int numberRecord,out int totalRecord);
        bool Delete(string userCd);
        bool Add(staff model);
        bool Update(staff model);
    }
}
