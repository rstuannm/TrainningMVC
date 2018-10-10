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
    public class BillController : BaseController
    {
        private readonly IProductsRepository _productRepository = new ProductsRepository();
        private readonly ICustomerRepository _customerRepository = new CustomerRespository();

        // GET: Bill
        public ActionResult Index()
        {
            var model = new BillVM();
            Session["LstProduct"] = new List<product>();
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchCustomer(string id)
        {
            try
            {
                var obj = _customerRepository.GetCustomerById(id);
                if (obj != null)
                {
                    return Json(new { status = true, name = obj.name });
                }
                else
                    return Json(new { status = false, msg = "Dữ liệu không tồn tại!" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, msg = ex.ToString() });
            }
        }

        [HttpPost]
        public ActionResult SearchProduct(int? id)
        {
            try
            {
                var obj = _productRepository.GetProductById(id == null ? 0 : id.Value);
                if (obj != null)
                {
                    return Json(new { status = true, name = obj.name, price = obj.price });
                }
                else
                    return Json(new { status = false, msg = "Dữ liệu không tồn tại!" });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, msg = ex.ToString() });
            }
        }

        [HttpPost]
        public ActionResult AddProduct(BillVM modelProduct)
        {
            var model = Session["LstProduct"] as List<product>;
            var item = model.FirstOrDefault(x => x.id == modelProduct.product.id);
            if(item != null)
            {
                item.name = modelProduct.product.name;
                item.amount = modelProduct.product.amount;
                item.price = modelProduct.product.price;
            }
            else
            {
                model.Add(modelProduct.product.GetEntity());
            }
            return Json(new
            {
                view = RenderRazorViewToString(ControllerContext, "LstView", model)
            });

            //return PartialView(model);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = Session["LstProduct"] as List<product>;
                var item = model.FirstOrDefault(x => x.id == id);
                if(item!=null)
                {
                    model.Remove(item);
                    return Json(new { err = true, view = RenderRazorViewToString(ControllerContext, "LstView", model) });
                }
                else
                {
                    return Json(new { err = false, msg = "Dữ liệu không tồn tại!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { err = false, msg = ex.ToString() });
            }
        }

        [HttpPost]
        public ActionResult AddBill(BillVM modelInput)
        {
            try
            {
                var model = Session["LstProduct"] as List<product>;
                if (model == null || model.Count == 0)
                {
                    return Json(new { status = false, msg = "Hóa đơn chưa tạo sản phẩm!" });
                }

                var data = _customerRepository.GetCustomerById(modelInput.cutomer.user_cd);
                if (data == null)
                {
                    return Json(new { status = false, msg = "Chưa lựa chọn khách hàng" });
                }

                var billPaymentOut = new bill_payment_out
                {
                    customer_id = modelInput.cutomer.user_cd,
                    customer_name = modelInput.cutomer.name,
                    price = model.Sum(x => x.price * x.amount),
                    create_date = DateTime.Now,
                    create_user = ""

                };

                var lstdetails = new List<details_bill_payment_out>();
                foreach (var item in model)
                {
                    var details = new details_bill_payment_out
                    {
                        product_id = item.id,
                        amount = item.amount,
                        price = item.price.ToString(),
                        create_date = DateTime.Now,
                        create_user = ""

                    };
                    lstdetails.Add(details);
                }

                IBillPaymentOutRepository repository = new BillPaymentOutRopository();
                var res = repository.Add(billPaymentOut, lstdetails);
                if (res)
                {
                    return Json(new { status = true });
                }
                else
                {
                    return Json(new { status = false, msg = Constant.Msg007 });
                }
            }
            catch(Exception ex)
            {
                return Json(new { status = false, msg = ex.Message });
            }
        }

    }
}