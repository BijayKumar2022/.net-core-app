using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using custumcore.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace custumcore.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        EmployeeDbContext _context = new EmployeeDbContext;
        // GET: TodoController
        //Here retrive all data from Inmemory Database
        public ActionResult getall()
        {

            return View(_context.Employees.ToList());
        }

        // GET: TodoController/Details/5
        //Get single data from Inmemory Database
        public ActionResult get(int id)
        {
            return View(_context.Employees.SingleOrDefault(e => e.Id == id);
        }

        // GET: TodoController/Create
        //Create new item
        public ActionResult Create(Employee ob)
        {
            _context.Employees.Add(ob);
            _context.SaveChanges();
            return View("getall");
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(getall));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Edit/5
        //Update single item
        public ActionResult put(Employee ob)
        {
            //var a=_context.Employees.SingleOrDefault(e => e.Id == id);
            
            if (ModelState.IsValid)
            {
                //.Added.CompareTo(EntityState.Modified);
                _context.Employees.Add(ob);
                _context.SaveChanges();
            }
            
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult put(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(getall));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp=_context.Employees.SingleOrDefault(x=>x.Id==id);
            if (emp == null)
            {
                return NotFound("Employee id not found");
            }
            else
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                return View();

            }
            
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(getall));
            }
            catch
            {
                return View();
            }
        }
    }
}
