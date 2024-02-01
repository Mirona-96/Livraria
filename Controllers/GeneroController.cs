using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroServices generoServices;

        public GeneroController(IGeneroServices generoServices)
        {
            this.generoServices = generoServices;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genero model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = generoServices.Add(model);
            if (result)
            {
                TempData["msg"] = "Adicionado com sucesso";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Erro ocorrido no servidor";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = generoServices.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Genero model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = generoServices.Update(model);
            if (result)
            {
                TempData["msg"] = "Actualizado com sucesso";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Erro de actualizacao ocorrido no servidor";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = generoServices.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(int id)
        {
            var data = generoServices.GetAll();
            return View(data);
        }
    }
}
