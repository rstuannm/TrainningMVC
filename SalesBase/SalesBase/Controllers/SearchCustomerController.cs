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
    public class SearchCustomerController : BaseController
    {
        private readonly ICustomerRepository _userRepository = new CustomerRespository();
        private const int NumberRecord = 5;

        // GET: SearchCustomer
        public ActionResult Index()
        {
            int totalRecord = 0;
            var model = new CustomerVM
            {
                search = new CustomerModel(),
                Lst = _userRepository.GetLst(new customer(), 1, NumberRecord, out totalRecord),
                PageNumber = 1,
                PageCount = NumberRecord
            };
            model.ToTalPage = (totalRecord % NumberRecord == 0) ? totalRecord / NumberRecord : totalRecord / NumberRecord + 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult GetLstUser(CustomerVM modelSearch, int? page)
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