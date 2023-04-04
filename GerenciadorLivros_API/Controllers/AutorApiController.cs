using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivros_API.Controllers
{
    public class AutorApiController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorApiController(IAutorService autorService)
        {
            _autorService = autorService;
        }
        [HttpGet]
        [Route("/Autores")]
        public IActionResult Index()
        {
            return Ok( _autorService.GetAll() );
        }

        [HttpGet]
        [Route("/Autor")]
        public IActionResult AutorEspec(int Id) 
        {
            return Ok( _autorService.GetAutor(Id) );
        }

        [HttpPost]
        [Route("/Autores/NovoAutor")]
        public IActionResult AdicionarAutor(Autor autor) 
        {
            _autorService.AdicionarAutor(autor);
            return Ok();
        }
        [HttpDelete]
        [Route("/Autores/{id}")]
        public IActionResult ExcluirAutor(int id) 
        {
            _autorService.ExcluirAutor(id);
            return Ok();
        }
        [HttpPut]
        [Route("/Autores")]
        public IActionResult AtualizarAutor(Autor autor) 
        {
            _autorService.EditarAutor(autor);
            return Ok();
        }
    }
}
