using Microsoft.AspNetCore.Mvc;
using PurchaseManagementSys.Models;

namespace PurchaseManagementSys.Controllers
{
    public class IssuanceController : Controller
    {
        public readonly ConnectionStringClass connectionStringClass;
        public IssuanceController(ConnectionStringClass cs)
        {
            connectionStringClass = cs;
        }

        public IActionResult Display()
        {
            IList<Issuance> list = connectionStringClass.issuances.OrderByDescending(x=>x.issuance_id).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Issuance issuance)
        {
            if (issuance !=null)
            {
                connectionStringClass.issuances.Add(issuance);
                connectionStringClass.SaveChanges();
                return RedirectToAction("Display");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Issuance issuance = connectionStringClass.issuances.Where(x => x.issuance_id == id).SingleOrDefault();
            return View(issuance);
        }
        [HttpPost]
        public IActionResult Edit(Issuance issuance)
        {
            Issuance issuance1 =   connectionStringClass.issuances.Where(x=>x.issuance_id==issuance.issuance_id).SingleOrDefault();
            issuance1.iss_date = issuance.iss_date;
            issuance1.qnty = issuance.qnty;
            issuance1.emp_name = issuance.emp_name;
            connectionStringClass.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}
