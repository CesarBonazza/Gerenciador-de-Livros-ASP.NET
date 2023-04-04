using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros_AT.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }
    
        // GET: AutorController
        public ActionResult Index()
        {
            var listaAutores = _autorService.GetAll();
            return View(listaAutores);
        }

        // GET: AutorController/Details/5
        public ActionResult DetalhesAutor(int id)
        {
			var listaDeAutores = _autorService.GetAll();
			var autorToView = listaDeAutores.Where(a => a.Id == id).First();
			return View(autorToView);
        }

        // GET: AutorController/NovoAutor
        public ActionResult NovoAutor()
        {
            return View();
        }

        // POST: AutorController/NovoAutor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoAutor(IFormCollection AutorCollection)
        {
            try
            {
               var novoAutor = new Autor();
                novoAutor.Nome = AutorCollection["Nome"];
                novoAutor.Sobrenome = AutorCollection["Sobrenome"];
                novoAutor.Email = AutorCollection["Email"];
                novoAutor.DataNiver = DateTime.Parse(AutorCollection["DataNiver"]);
                _autorService.AdicionarAutor(novoAutor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Edit/5
        public ActionResult EditarAutor(int id)
        {
            var listaDeAutores = _autorService.GetAll();
            var autorToEdit = listaDeAutores.Where(a => a.Id == id).First();
            return View(autorToEdit);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAutor(IFormCollection AutorColletion)
        {
            try
            {
                var novoAutor = new Autor();
                novoAutor.Nome = AutorColletion["Nome"];
                novoAutor.Sobrenome = AutorColletion["Sobrenome"];
                novoAutor.Email = AutorColletion["Email"];
                novoAutor.DataNiver = DateTime.Parse(AutorColletion["DataNiver"]);
                _autorService.EditarAutor(novoAutor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Delete/5
        public ActionResult Delete(int id)
        {
            _autorService.ExcluirAutor(id);
            return RedirectToAction("Index");
        }

        // POST: AutorController/Delete/5
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
