using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Bussiness.DbContext;

namespace SalesBase.Models
{
    public class StaffModel
    {
        public string MsgError { get; set; }

        [Display(Name = "ID:")]
        public string user_cd { get; set; }

        [Display(Name = "Tên:")]
        [StringLength(255)]
        public string name { get; set; }

        [Display(Name = "Tên đăng nhập:")]
        [Required]
        [StringLength(8)]
        public string user_name { get; set; }

        [Display(Name = "Mật khẩu:")]
        [Required]
        [StringLength(255)]
        public string pass_word { get; set; }

        [Display(Name = "Điện thoại:")]
        [StringLength(255)]
        public string mobile { get; set; }

        [Display(Name = "Email:")]
        [StringLength(255)]
        public string email { get; set; }

        [Display(Name = "Địa chỉ:")]
        [StringLength(255)]
        public string adress { get; set; }

        [Display(Name = "Giới tính:")]
        public bool? sex { get; set; }

        public bool? del_flg { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(8)]
        public string create_user { get; set; }

        public DateTime? update_date { get; set; }

        [StringLength(8)]
        public string update_user { get; set; }


        public StaffModel()
        {
        }

        public StaffModel(staff entity, bool encodeHtml = false)
        {
            if (entity != null)
            {
                Mapper.CreateMap<staff, StaffModel>();
                Mapper.Map(entity, this);
            }
        }

        public staff GetEntity()
        {
            Mapper.CreateMap<StaffModel, staff>();
            staff entity = Mapper.Map<StaffModel, staff>(this);

            return entity;
        }
    }
}