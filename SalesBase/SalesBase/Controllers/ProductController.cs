using Bussiness.DbContext;
using Bussiness.IRepository;
using Bussiness.Repository;
using SalesBase.Common;
using SalesBase.Models;
using SalesBase.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesBase.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductsRepository _userRepository = new ProductsRepository();
        private readonly ICatalogRepository _catalogRepository = new CatalogRepository();
        private const int NumberRecord = 5;
        // GET: Product
        public ActionResult Index()
        {
            int totalRecord = 0;
            var model = new ProductVM
            {
                search = new ProductModel(),
                Lst = _userRepository.GetLst(new product(), 1, NumberRecord, out totalRecord),
                PageNumber = 1,
                PageCount = NumberRecord,
            };
            //lstCbb = new List<SelectListItem> { }
            model.search.lstCbb = LoadListCatalog();
            ViewBag.lstCbb = model.search.lstCbb;
            model.ToTalPage = (totalRecord % NumberRecord == 0) ? totalRecord / NumberRecord : totalRecord / NumberRecord + 1;
            return View(model);
        }

        private List<SelectListItem> LoadListCatalog()
        {
            var lst = new List<SelectListItem>();
            int totalRecord = 0;
            var lstCatalog = _catalogRepository.GetLst(new catalog(),1,int.MaxValue,out totalRecord);
            foreach (var item in lstCatalog)
            {
                lst.Add(new SelectListItem
                {
                    Value = item.id.ToString(),
                    Text = item.name
                });
            }
            return lst;
        }
        [HttpPost]
        public ActionResult GetLstUser(ProductVM modelSearch, int? page)
        {
            int totalRecord = 0;
            var model = _userRepository.GetLst(modelSearch.search.GetEntity(), page, NumberRecord, out totalRecord);
            ViewBag.lstCbb = LoadListCatalog();
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", model)
            });

            //return PartialView(model);
        }

        private string ValidateModel(product model)
        {
            if (model.catalog_id == null)
            {
                return string.Format(Constant.Msg000, "Nhóm sản phẩm");
            }

            if (string.IsNullOrEmpty(model.name))
            {
                return string.Format(Constant.MsgRequired, "Tên sản phẩm");
            }
            if (model.amount == null)
            {
                return string.Format(Constant.MsgRequired, "Số lượng sản phẩm");
            }
            if (!Utils.IsNumber(model.amount.Value.ToString()))
            {
                return string.Format(Constant.Msg010, "Số lượng");
            }
            if (model.price == null)
            {
                return string.Format(Constant.MsgRequired, "Giá bán");
            }
            if (!Utils.IsNumber(model.price.Value.ToString()))
            {
                return string.Format(Constant.Msg010, "Giá bán");
            }
            if (model.price_buy == null)
            {
                return string.Format(Constant.MsgRequired, "Giá nhập");
            }
            if (!Utils.IsNumber(model.price_buy.Value.ToString()))
            {
                return string.Format(Constant.Msg010, "Giá nhập");
            }

            return string.Empty;
        }

        [HttpPost]
        public ActionResult Add(ProductVM model)
        {
            try
            {
                var modelAdd = model.search.GetEntity();
                var msgValid = ValidateModel(modelAdd);
                if (string.IsNullOrEmpty(msgValid))
                {
                    var obj = _userRepository.Add(modelAdd);
                    if (obj)
                        return Json(new { status = true });
                    else
                        return Json(new { status = false, msg = "Thêm thất bại" });
                }
                else
                {
                    return Json(new { status = false, msg = msgValid });
                }
            }
            catch (Exception ex)
            {
                // chuyển sang page ERR
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                int totalRecord = 0;
                var obj = _userRepository.Delete(id);
                if (obj)
                {
                    var model = _userRepository.GetLst(new product(), 1, NumberRecord, out totalRecord);
                    return Json(new { err = true, view = RenderRazorViewToString(ControllerContext, "LstView", model) });
                }
                else
                    return Json(new { err = false, msg = "Dữ liệu không tồn tại!" });
            }
            catch (Exception ex)
            {
                return Json(new { err = false, msg = ex.ToString() });
            }
        }

        [HttpPost]
        public ActionResult UpdateGet(int id)
        {
            try
            {
                var model = new ProductModel(_userRepository.GetProduct(new product { id = id }));
                model.lstCbb = LoadListCatalog();
                return Json(new { err = true, view = RenderRazorViewToString(ControllerContext, "Update", model) });

            }
            catch (Exception ex)
            {
                // chuyển sang page ERR
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(ProductModel model)
        {
            try
            {
                var modelUpdate = model.GetEntity();
                modelUpdate.update_date = DateTime.Now;
                var msgValid = ValidateModel(modelUpdate);

                if (string.IsNullOrEmpty(msgValid))
                {
                    var obj = _userRepository.Update(modelUpdate);
                    if (obj)
                        return Json(new { status = true });
                    else
                        return Json(new { status = false, msg = "Dữ liệu không tồn tại" });
                }
                else
                {
                    return Json(new { status = false, msg = msgValid });
                }
            }
            catch (Exception ex)
            {
                // chuyển sang page ERR
                return RedirectToAction("Index", "Error");
            }
        }
    }
}