using GastosRegisterO.IRepository;
using GastosRegisterO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GastosRegisterO.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContainer _container;

        public HomeController(IContainer container)
        {
            _container = container;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.total = _container.gastosRepository.Total();
            HomeVM VM = new HomeVM()
            {
                gastos = _container.gastosRepository.GetAll()
            };
            return View(VM);
        }

      public IActionResult AllGastos()
        {
            
            var all=_container.gastosRepository.GetAll();
            return View(all);

            
        }
        [HttpGet]
        public IActionResult InsertGasto()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertGasto(Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                _container.gastosRepository.Add(gastos);
                _container.Save();
                return RedirectToAction("AllGastos");

            }
           
            

                return View(gastos);
            

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();

            }
            var gastos = _container.gastosRepository.Get(id);
            return View(gastos);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                _container.gastosRepository.Update(gastos);
                _container.Save();
                return RedirectToAction(nameof(AllGastos));


            }
            return View(gastos);
        }
        #region
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _container.gastosRepository.Get(id);
                if (obj == null)
            {
                return Json(new { success = false ,message="Error on delete 👎" });
            }

            _container.gastosRepository.Remove(obj);
            _container.Save();
            return Json(new { success = true, message="Exito ✔" });

        }
        [HttpGet]
        public IActionResult GetAll() {

            return Json(new { Data = _container.gastosRepository.GetAll() });
        
        }


        #endregion
    }
}
