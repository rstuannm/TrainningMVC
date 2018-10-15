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
    public class SearchProductController : BaseController
    {
        private readonly IProductsRepository _userRepository = new ProductsRepository();
        private readonly ICatalogRepository _catalogRepository = new CatalogRepository();
        private const int NumberRecord = int.MaxValue;
        // GET: SearchProduct
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
            var lstCatalog = _catalogRepository.GetLst(new catalog(), 1, int.MaxValue, out totalRecord);
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
    }
}