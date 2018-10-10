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
    public class CompanyController : BaseController
    {
        private readonly ICompanyRepository _userRepository = new CompanyRepository();
        private const int NumberRecord = 5;
        // GET: Company
        public ActionResult Index()
        {
            int totalRecord = 0;
            var model = new CompanyVM
            {
                search = new CompanyModel(),
                Lst = _userRepository.GetLst(new company(), 1, NumberRecord, out totalRecord),
                PageNumber = 1,
                PageCount = NumberRecord
            };
            model.ToTalPage = (totalRecord % NumberRecord == 0) ? totalRecord / NumberRecord : totalRecord / NumberRecord + 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult GetLstUser(CompanyVM modelSearch, int? page)
        {
            int totalRecord = 0;
            var model = _userRepository.GetLst(modelSearch.search.GetEntity(), page, NumberRecord, out totalRecord);

            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", model)
            });

            //return PartialView(model);
        }

        private string ValidateModel(company model)
        {
            if (string.IsNullOrEmpty(model.company_cd))
            {
                return string.Format(Constant.MsgRequired, "Mã công ty");
            }
            if (string.IsNullOrEmpty(model.company_name))
            {
                return string.Format(Constant.MsgRequired, "Tên công ty");
            }
            if (string.IsNullOrEmpty(model.company_short_name))
            {
                return string.Format(Constant.MsgRequired, "Tên rút gọn");
            }
            if (string.IsNullOrEmpty(model.address))
            {
                return string.Format(Constant.MsgRequired, "Địa chỉ");
            }
            if (!Utils.IsNumber(model.tel))
            {
                return string.Format(Constant.Msg010, "Điện thoại bàn");
            }
            if (!Utils.IsNumber(model.fax))
            {
                return string.Format(Constant.Msg010, "Số fax");
            }
            if (!Utils.IsNumber(model.phone))
            {
                return string.Format(Constant.Msg010, "Số di động");
            }
            return string.Empty;
        }

        [HttpPost]
        public ActionResult Add(CompanyVM model)
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
        public ActionResult Delete(string id)
        {
            try
            {
                int totalRecord = 0;
                var obj = _userRepository.Delete(id);
                if (obj)
                {
                    var model = _userRepository.GetLst(new company(), 1, NumberRecord, out totalRecord);
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
        public ActionResult UpdateGet(string id)
        {
            try
            {
                var model = new CompanyModel(_userRepository.GetCompany(new company { company_cd = id }));
                return Json(new { err = true, view = RenderRazorViewToString(ControllerContext, "Update", model) });

            }
            catch (Exception ex)
            {
                // chuyển sang page ERR
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(CompanyModel model)
        {
            try
            {
                var modelUpdate = model.GetEntity();
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