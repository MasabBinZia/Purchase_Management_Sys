using Microsoft.AspNetCore.Mvc;
using PurchaseManagementSys.Models;

namespace PurchaseManagementSys.Controllers
{
    public class ItemController : Controller
    {
        public readonly ConnectionStringClass connectionStringClass;
        public ItemController(ConnectionStringClass cs)
        {
            this.connectionStringClass = cs;
        }
        public IActionResult Display()
        {
            IList<Item> list = connectionStringClass.items.OrderByDescending(x=>x.item_id).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if(item != null)
            {
                connectionStringClass.items.Add(item);
                connectionStringClass.SaveChanges();
                return RedirectToAction("Display");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id )
        {
            Item item = connectionStringClass.items.Where(x => x.item_id == id).SingleOrDefault();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Item item) {
            Item item1 = connectionStringClass.items.Where(x => x.item_id == item.item_id).SingleOrDefault();
            item1.item_name = item.item_name;
            item1.item_status = item.item_status;
            connectionStringClass.SaveChanges();
            return View("Display");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Item item = connectionStringClass.items.Where(x => x.item_id == id).SingleOrDefault();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Item item)
        { 
            Item item1 = connectionStringClass.items.Where(x => x.item_id == item.item_id).SingleOrDefault();
            connectionStringClass.items.Remove(item1);
            connectionStringClass.SaveChanges();
            return View("Display");
        }
        [HttpGet]
        public IActionResult Details (int id)
        {
            Item item = connectionStringClass.items.Where(x => x.item_id == id).SingleOrDefault();
            return View(item);
        }
    }
}
