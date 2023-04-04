using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros_API.Controllers
{
    public class LivroApiController : ControllerBase
    {
        private readonly ILivroService _livroService;
        public LivroApiController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        [Route("/Livros")]
        public IActionResult Index()
        {

            return Ok( _livroService.GetAll() );
        }
        [HttpGet]
        [Route("/Livro")]
        public IActionResult LivroEspec(int Id) 
        {
            return Ok( _livroService.GetLivro(Id) );
        }
        [HttpPost]
        [Route("/Livros/NovoLivro")]
        public IActionResult AdicionarLivro(Livro livro) 
        {
            _livroService.AdicionarLivro(livro);
            return Ok();
        }
        [HttpDelete]
        [Route("/Livros/{id}")]
        public IActionResult Delete(int id) 
        {
            _livroService.ExcluirLivro(id);
            return Ok();
        }
        [HttpPut]
        [Route("/Livros")]
        public IActionResult AtualizarLivro(Livro livro) 
        {
            _livroService.EditarLivro(livro);
            return Ok();
        }
    }
}
