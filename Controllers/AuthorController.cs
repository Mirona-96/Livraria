using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorServices autorServices;
        

        public AutorController(IAutorServices autorServices)
        {
            this.autorServices = autorServices;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Autor model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = autorServices.Add(model);
            if (result)
            {
                TempData["msg"] = "Adicionado Autor com sucesso";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Erro ocorrido no servidor";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = autorServices.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Autor model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = autorServices.Update(model);
            if (result)
            {
                TempData["msg"] = " Autor actualizado com sucesso";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Erro de actualizacao ocorrido no servidor";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = autorServices.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(int id)
        {
            var data = autorServices.GetAll();
            return View(data);
        }
    }
}
