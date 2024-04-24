using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Guilherme.Models;
using WebApi8_Guilherme.Services.Autor;
using WebApi8_Guilherme.Services.Livro;

namespace WebApi8_Guilherme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListaLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListaLivros()
        {
            var livros = await _livroInterface.ListaLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livros = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livros);
        }
    }
}
