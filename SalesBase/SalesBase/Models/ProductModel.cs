using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoMapper;
using Bussiness.DbContext;

namespace SalesBase.Models
{
    public class ProductModel
    {
        public string MsgError { get; set; }
        public List<SelectListItem> lstCbb { get; set; }

        [Display(Name = "Mã sản phẩm:")]
        public int id { get; set; }

        [Display(Name = "Mã loại sản phẩm")]
        public int? catalog_id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string name { get; set; }

        [Display(Name = "Số lượng:")]
        public long? amount { get; set; }

        [Display(Name = "Giá bán:")]
        public double? price { get; set; }

        [Display(Name = "Giá nhập:")]
        public double? price_buy { get; set; }

        public bool del_flg { get; set; }

        [Display(Name = "Người tạo:")]
        public string create_user { get; set; }

        [Display(Name = "Ngày tạo:")]
        public DateTime? create_date { get; set; }

        [Display(Name = "Người cập nhật:")]
        public string update_user { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? update_date { get; set; }

        public ProductModel()
        {
            lstCbb = new List<SelectListItem>();
        }

        public ProductModel(product entity, bool encodeHtml = false)
        {
            if (entity != null)
            {
                Mapper.CreateMap<product, ProductModel>();
                Mapper.Map(entity, this);
            }
        }

        public product GetEntity()
        {
            Mapper.CreateMap<ProductModel, product>();
            product entity = Mapper.Map<ProductModel, product>(this);

            return entity;
        }
    }
}