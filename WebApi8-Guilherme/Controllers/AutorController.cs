using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Guilherme.Dto.Autor;
using WebApi8_Guilherme.Models;
using WebApi8_Guilherme.Services.Autor;

namespace WebApi8_Guilherme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

        [HttpPost("CriaAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriaAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autor = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autor);
        }

        [HttpDelete("RemoveAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> RemoveAutor(int idAutor)
        {
            var autor = await _autorInterface.ExcluirAutor(idAutor);
            return Ok(autor);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autor = await _autorInterface.EditarAutor(autorEdicaoDto);
            return Ok(autor);
        }
    }
}
