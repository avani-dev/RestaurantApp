using RestaurantApplication.Models;
using RestaurantApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApplication.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDBEntities objRestaurantDBEntities;

        public RestaurantController()
        {
            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            CustomerRespository objcustomerRespository = new CustomerRespository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
            (objcustomerRespository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());

            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestaurantDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice,JsonRequestBehavior.AllowGet);
        }
    }
}