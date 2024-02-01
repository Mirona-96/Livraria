using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;
using Livraria.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class EditoraController : Controller
    {
        private readonly IEditoraServices editoraServices;

        public EditoraController(IEditoraServices editoraServices)
        {
            this.editoraServices = editoraServices;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Editora model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = editoraServices.Add(model);
            if (result)
            {
                TempData["msg"] = "Adicionada Editora com sucesso";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Erro ocorrido no servidor";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = editoraServices.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Editora model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = editoraServices.Update(model);
            if (result)
            {
                TempData["msg"] = " Editora actualizada com sucesso";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Erro de actualizacao ocorrido no servidor";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = editoraServices.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(int id)
        {
            var data = editoraServices.GetAll();
            return View(data);
        }


    }
}
