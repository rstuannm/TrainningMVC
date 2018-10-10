using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Bussiness.DbContext;

namespace SalesBase.Models
{
    public class CustomerModel
    {
        public string MsgError { get; set; }

        [Display(Name = "Mã khách hàng:")]
        public string user_cd { get; set; }

        [Display(Name = "Tên khách hàng:")]
        public string name { get; set; }

        [Display(Name = "Tên đăng nhập:")]
        public string user_name { get; set; }

        [Display(Name = "Mật khẩu:")]
        public string pass_word { get; set; }

        [Display(Name = "Điện thoại:")]
        public string mobile { get; set; }

        [Display(Name = "Email:")]
        public string email { get; set; }

        [Display(Name = "Địa chỉ:")]
        public string adress { get; set; }

        [Display(Name = "Giới tính:")]
        public bool? sex { get; set; }

        [Display(Name = "Xóa")]
        public bool del_flg { get; set; }

        [Display(Name = "Người tạo:")]
        public string create_user { get; set; }

        [Display(Name = "Ngày tạo:")]
        public DateTime? create_date { get; set; }

        [Display(Name = "Người cập nhật:")]
        public string update_user { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? update_date { get; set; }

        public CustomerModel()
        {
        }

        public CustomerModel(customer entity, bool encodeHtml = false)
        {
            if (entity != null)
            {
                Mapper.CreateMap<customer, CustomerModel>();
                Mapper.Map(entity, this);
            }
        }

        public customer GetEntity()
        {
            Mapper.CreateMap<CustomerModel, customer>();
            customer entity = Mapper.Map<CustomerModel, customer>(this);

            return entity;
        }
    }
}