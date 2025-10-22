using System.Web.Mvc;
using EmployeeManagement.DAL;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository repo = new EmployeeRepository();

        // GET: Employee
        public ActionResult Index()
        {
            var employees = repo.GetAllEmployees();
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var emp = repo.GetEmployeeById(id);
            if (emp == null) return HttpNotFound();
            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                repo.Create(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = repo.GetEmployeeById(id);
            if (emp == null) return HttpNotFound();
            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                repo.Update(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400, "Bad Request");

            var emp = repo.GetEmployeeById(id.Value);
            if (emp == null)
                return HttpNotFound();

            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
