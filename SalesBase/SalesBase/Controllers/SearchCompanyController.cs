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
    public class SearchCompanyController : BaseController
    {
        private readonly ICompanyRepository _userRepository = new CompanyRepository();
        private const int NumberRecord = int.MaxValue;

        // GET: SearchCompany
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
    }
}