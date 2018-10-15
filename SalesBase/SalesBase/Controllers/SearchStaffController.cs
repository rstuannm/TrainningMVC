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
    public class SearchStaffController : BaseController
    {
        private readonly IStaffRepository _userRepository = new StaffRepository();
        private const int NumberRecord = int.MaxValue;

        // GET: SearchStaff
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
    }
}