namespace Bussiness.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        public int id { get; set; }

        public int? catalog_id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public long? amount { get; set; }

        public double? price { get; set; }

        public double? price_buy { get; set; }

        public bool del_flg { get; set; }

        [StringLength(8)]
        public string create_user { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(8)]
        public string update_user { get; set; }

        public DateTime? update_date { get; set; }
    }
}
