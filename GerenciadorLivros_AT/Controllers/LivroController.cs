using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Service;

namespace GerenciadorLivros_AT.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        // GET: LivroController
        public ActionResult Index()
        {
            var listaDeLivros = _livroService.GetAll();
            return View(listaDeLivros);
        }

        // GET: LivroController/Details/5
        public ActionResult DetalhesLivro(int id)
        {
            var listaDeLivros = _livroService.GetAll();
            var livroToView = listaDeLivros.Where(l => l.Id == id).First();
            return View(livroToView);
        }

        // GET: LivroController/Create
        public ActionResult NovoLivro()
        {
            return View();
        }

        // POST: LivroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoLivro(IFormCollection LivroCollection)
        {
            try
            {
                var novoLivro = new Livro();
                novoLivro.Titulo = LivroCollection["Titulo"];
                novoLivro.ISBN = LivroCollection["ISBN"];
                novoLivro.Ano = DateTime.Parse(LivroCollection["Ano"]);
                _livroService.AdicionarLivro(novoLivro);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LivroController/Edit/5
        public ActionResult EditarLivro(int id)
        {
            var listaDeLivros = _livroService.GetAll();
            var livroToEdit = listaDeLivros.Where(l => l.Id == id).First();
            return View(livroToEdit);
        }

        // POST: LivroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarLivro(IFormCollection LivroCollection)
        {
            try
            {
                var novoLivro = new Livro();

                novoLivro.Titulo = LivroCollection["Titulo"];
                novoLivro.ISBN = LivroCollection["ISBN"];
                novoLivro.Ano = DateTime.Parse(LivroCollection["Ano"]);
                
                _livroService.EditarLivro(novoLivro);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LivroController/Delete/5
        public ActionResult Delete(int id)
        {
            _livroService.ExcluirLivro(id);
            return RedirectToAction("Index");
        }

        // POST: LivroController/Delete/5
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
