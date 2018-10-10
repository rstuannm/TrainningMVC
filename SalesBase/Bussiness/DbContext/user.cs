namespace Bussiness.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        public int id { get; set; }

        [Required]
        [StringLength(8)]
        public string user_cd { get; set; }

        [Required]
        [StringLength(255)]
        public string pass_word { get; set; }

        [StringLength(255)]
        public string user_name { get; set; }

        [StringLength(255)]
        public string mobile { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string adress { get; set; }

        public bool? sex { get; set; }

        public bool del_flg { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(8)]
        public string create_user { get; set; }

        public DateTime? update_date { get; set; }

        [StringLength(8)]
        public string update_user { get; set; }
    }
}
