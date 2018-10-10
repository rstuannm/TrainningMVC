using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Bussiness.DbContext;

namespace SalesBase.Models
{
    public class CompanyModel
    {
        public string MsgError { get; set; }

        [Display(Name = "Mã công ty:")]
        public string company_cd { get; set; }

        [Display(Name = "Tên công ty:")]
        public string company_name { get; set; }

        [Display(Name = "Tên rút gọn:")]
        public string company_short_name { get; set; }

        [Display(Name = "Tel:")]
        public string tel { get; set; }

        [Display(Name = "Địa chỉ:")]
        public string address { get; set; }

        [Display(Name = "Fax")]
        public string fax { get; set; }

        [Display(Name = "Điện thoại:")]
        public string phone { get; set; }

        public bool del_flg { get; set; }

        [Display(Name = "Ngày tạo:")]
        public DateTime? create_date { get; set; }

        [Display(Name = "Người tạo:")]
        public string create_user { get; set; }

        [Display(Name = "Ngày cập nhật:")]
        public DateTime? update_date { get; set; }

        [Display(Name = "Người cập nhật:")]
        public string update_user { get; set; }


        public CompanyModel()
        {
        }

        public CompanyModel(company entity, bool encodeHtml = false)
        {
            if (entity != null)
            {
                Mapper.CreateMap<company, CompanyModel>();
                Mapper.Map(entity, this);
            }
        }

        public company GetEntity()
        {
            Mapper.CreateMap<CompanyModel, company>();
            company entity = Mapper.Map<CompanyModel, company>(this);

            return entity;
        }
    }
}