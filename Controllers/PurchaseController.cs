using Microsoft.AspNetCore.Mvc;
using PurchaseManagementSys.Models;

namespace PurchaseManagementSys.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ConnectionStringClass connectionStringClass;
        public PurchaseController(ConnectionStringClass cc)
        {
            this.connectionStringClass = cc;
        }
        public IActionResult Display()
        {
            IList<Purchase> purchases =connectionStringClass.purchases.OrderByDescending(x=>x.pur_id).ToList();
            return View(purchases);
        }
        [HttpGet]
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Purchase purchase)
        {
            if(purchase != null) {
                connectionStringClass.purchases.Add(purchase);
                connectionStringClass.SaveChanges();
                RedirectToAction("Display");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Purchase purchase = connectionStringClass.purchases.Where(x => x.pur_id == id).SingleOrDefault();
            return View(purchase);
        }
        [HttpPost]
        public IActionResult Edit(Purchase purchase)
        {
            Purchase purchase1 = connectionStringClass.purchases.Where(x => x.pur_id == purchase.pur_id).SingleOrDefault();
            purchase1.pur_item = purchase.pur_item;
            purchase1.pur_date = purchase.pur_date;
            purchase1.pur_qty = purchase.pur_qty;
            purchase1.pur_vendor = purchase.pur_vendor;
            connectionStringClass.SaveChanges();
            return RedirectToAction("Display");
        }

    }
}
