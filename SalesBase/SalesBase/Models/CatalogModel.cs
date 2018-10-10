using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Bussiness.DbContext;

namespace SalesBase.Models
{
    public class CatalogModel
    {
        public string MsgError { get; set; }

        [Display(Name = "Mã loại sản phẩm:")]
        public int id { get; set; }

        [Display(Name = "Tên loại sản phẩm:")]
        public string name { get; set; }

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

        public CatalogModel()
        {
        }

        public CatalogModel(catalog entity, bool encodeHtml = false)
        {
            if (entity != null)
            {
                Mapper.CreateMap<catalog, CatalogModel>();
                Mapper.Map(entity, this);
            }
        }

        public catalog GetEntity()
        {
            Mapper.CreateMap<CatalogModel, catalog>();
            catalog entity = Mapper.Map<CatalogModel, catalog>(this);

            return entity;
        }
    }
}