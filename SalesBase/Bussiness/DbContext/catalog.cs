namespace Bussiness.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("catalog")]
    public partial class catalog
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public bool? del_flg { get; set; }

        [StringLength(8)]
        public string create_user { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(8)]
        public string update_user { get; set; }

        public DateTime? update_date { get; set; }
    }
}
