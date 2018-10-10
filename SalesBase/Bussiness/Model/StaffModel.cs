using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Model
{
    public class StaffModel
    {
        public string user_cd { get; set; }

        public string name { get; set; }

        public string user_name { get; set; }

        public string pass_word { get; set; }

        public string mobile { get; set; }

        public string email { get; set; }

        public string adress { get; set; }

        public bool? sex { get; set; }

        public string gioitinh
        {
            get
            {
                if (sex.HasValue)
                {
                    return sex.Value ? "Nam" : "Nữ";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public bool del_flg { get; set; }

        public string create_user { get; set; }

        public DateTime? create_date { get; set; }

        public string update_user { get; set; }

        public DateTime? update_date { get; set; }
    }
}
