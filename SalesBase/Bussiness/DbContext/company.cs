namespace Bussiness.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("company")]
    public partial class company
    {
        [Key]
        [StringLength(8)]
        public string company_cd { get; set; }

        [StringLength(255)]
        public string company_name { get; set; }

        [StringLength(40)]
        public string company_short_name { get; set; }

        [StringLength(255)]
        public string tel { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string fax { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        public bool del_flg { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(8)]
        public string create_user { get; set; }

        public DateTime? update_date { get; set; }

        [StringLength(8)]
        public string update_user { get; set; }
    }
}
