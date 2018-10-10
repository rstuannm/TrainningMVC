namespace Bussiness.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class details_bill_payment_in
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bill_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_id { get; set; }

        public long? amount { get; set; }

        [StringLength(10)]
        public string price { get; set; }

        public bool del_flg { get; set; }

        [StringLength(8)]
        public string create_user { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(8)]
        public string update_user { get; set; }

        public DateTime? update_date { get; set; }
    }
}
