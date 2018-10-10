using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Model
{
    public class CompanyModel
    {
        public string company_cd { get; set; }
        public string company_name { get; set; }
        public string company_short_name { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string fax { get; set; }
        public string phone { get; set; }
        public bool del_flg { get; set; }
        public DateTime? creat_date { get; set; }

        public DateTime? update_date { get; set; }
        public string creat_user { get; set; }
        public string creat_update { get; set; }

    }
}
