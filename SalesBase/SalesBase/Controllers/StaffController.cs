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
    public class StaffController : BaseController
    {
        private readonly IStaffRepository _userRepository = new StaffRepository();
        private const int NumberRecord = 5;

        // GET: Staff
        public ActionResult Index()
        {
            int totalRecord = 0;
            var model = new StaffVM
            {
                search = new StaffModel(),
                LstStaff = _userRepository.GetLst(new staff(), 1, NumberRecord, out totalRecord),
                PageNumber = 1,
                PageCount = NumberRecord
            };
            model.ToTalPage = (totalRecord % NumberRecord == 0) ? totalRecord / NumberRecord : totalRecord / NumberRecord + 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult GetLstUser(StaffVM modelSearch, int? page)
        {
            int totalRecord = 0;
            var model = _userRepository.GetLst(modelSearch.search.GetEntity(), page, NumberRecord, out totalRecord);

            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", model)
            });

            //return PartialView(model);
        }

        private string ValidateModel(staff model)
        {
            if (string.IsNullOrEmpty(model.user_cd))
            {
                return string.Format(Constant.MsgRequired, "Mã nhân viên");
            }
            if (string.IsNullOrEmpty(model.user_name))
            {
                return string.Format(Constant.MsgRequired, "Tên đăng nhập");
            }
            if (string.IsNullOrEmpty(model.pass_word))
            {
                return string.Format(Constant.MsgRequired, "Mật khẩu");
            }
            if (!Utils.IsNumber(model.mobile))
            {
                return string.Format(Constant.Msg010, "Điện thoại");
            }
            return string.Empty;
        }

        [HttpPost]
        public ActionResult Add(StaffVM model)
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
                    var model = _userRepository.GetLst(new staff(), 1, NumberRecord, out totalRecord);
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
                var model = new StaffModel(_userRepository.GetStaff(new staff { user_cd = id }));
                return Json(new { err = true, view = RenderRazorViewToString(ControllerContext, "Update", model) });

            }
            catch (Exception ex)
            {
                // chuyển sang page ERR
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(StaffModel model)
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