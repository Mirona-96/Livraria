using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;
using Livraria.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Livraria.Controllers
{
    public class LivroController : Controller
    {
        private readonly IBookServices livroServices;
        private readonly IAutorServices autorServices;
        private readonly IGeneroServices generoServices;
        private readonly IEditoraServices editoraServices;

        public LivroController(IBookServices livroServices, IAutorServices autorServices, IGeneroServices generoServices, IEditoraServices editoraServices)
        {
            this.livroServices = livroServices;
            this.autorServices = autorServices;
            this.generoServices = generoServices;
            this.editoraServices = editoraServices;
        }

        public IActionResult Add()
        {
            var model = new Livro();
            model.ListaAutores = autorServices.GetAll().Select(a => new SelectListItem { Text = a.AutorNome, Value = a.Id.ToString() }).ToList();
            model.ListaEditores = editoraServices.GetAll().Select(a => new SelectListItem { Text = a.EditoraNome, Value = a.Id.ToString() }).ToList();
            model.ListaGeneros = generoServices.GetAll().Select(a => new SelectListItem { Text = a.Nome, Value = a.Id.ToString() }).ToList();   
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Livro model)
        {
            double preco = model.PrecoLivro;
            model.ListaAutores = autorServices.GetAll().Select(a => new SelectListItem { Text = a.AutorNome, Value = a.Id.ToString(), Selected = a.Id == model.AutorId }).ToList();
            model.ListaEditores = editoraServices.GetAll().Select(a => new SelectListItem { Text = a.EditoraNome, Value = a.Id.ToString(),Selected = a.Id==model.EditoraId }).ToList();
            model.ListaGeneros = generoServices.GetAll().Select(a => new SelectListItem { Text = a.Nome, Value = a.Id.ToString(),Selected = a.Id == model.GeneroId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = livroServices.Add(model);
            if (result)
            {
                TempData["msg"] = "livro adicionado com sucesso";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Erro ocorrido no servidor";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var model = livroServices.FindById(id);
            model.ListaAutores = autorServices.GetAll().Select(a => new SelectListItem { Text = a.AutorNome, Value = a.Id.ToString(), Selected = a.Id == model.AutorId }).ToList();
            model.ListaEditores = editoraServices.GetAll().Select(a => new SelectListItem { Text = a.EditoraNome, Value = a.Id.ToString(), Selected = a.Id == model.EditoraId }).ToList();
            model.ListaGeneros = generoServices.GetAll().Select(a => new SelectListItem { Text = a.Nome, Value = a.Id.ToString(), Selected = a.Id == model.GeneroId }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Livro model)
        {
            double preco = model.PrecoLivro;
            model.ListaAutores = autorServices.GetAll().Select(a => new SelectListItem { Text = a.AutorNome, Value = a.Id.ToString(), Selected = a.Id == model.AutorId }).ToList();
            model.ListaEditores = editoraServices.GetAll().Select(a => new SelectListItem { Text = a.EditoraNome, Value = a.Id.ToString(), Selected = a.Id == model.EditoraId }).ToList();
            model.ListaGeneros = generoServices.GetAll().Select(a => new SelectListItem { Text = a.Nome, Value = a.Id.ToString(), Selected = a.Id == model.GeneroId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = livroServices.Update(model);
            if (result)
            {
                TempData["msg"] = "Livro actualizado com sucesso";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Erro de actualizacao ocorrido no servidor";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = livroServices.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(int id)
        {
            var data = livroServices.GetAll();
            return View(data);
        }
    }
}
