using Maslo.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Maslo.UI.Controllers
{
    public class Home : Controller
    {
        // GET: Home

        //public class ListDemo
        //{
        //    public int Id { get; set; }
        //    public string? Name { get; set; }
        //}

        List<ListDemo> items = new List<ListDemo>
        {
            new ListDemo { Id=1, Name="Item 1"},
            new ListDemo { Id=2, Name="Item 2"},
            new ListDemo { Id=3, Name="Item 3"}
        };

        public ActionResult Index()
        {

            ViewData["LabStr"] = "Лабораторная работа";
            ViewData["Items"] = new SelectList(items, "Id", "Name");
            return View();
        }
        

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
