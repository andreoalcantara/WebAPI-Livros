using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Livros.DTO.Autor;
using WebAPI_Livros.models;
using WebAPI_Livros.Models;
using WebAPI_Livros.Services.Autor;

namespace WebAPI_Livros.Controllers
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
            var resposta = await _autorInterface.ListarAutores();
            return Ok(resposta);
        }

        [HttpGet("BuscarAutorPorID")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorID(int idAutor)
        {
            var resposta = await _autorInterface.BuscarAutorPorID(idAutor);
            return Ok(resposta);
        }

        [HttpGet("BuscarAutorPorIdLivro")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var resposta = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(resposta);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(int idAutor, AutorDto autorCriacaoDto)
        {
            var autores = await _autorInterface.EditarAutor(idAutor, autorCriacaoDto);
            return Ok(autores);
        }

        [HttpDelete("RemoverAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> RemoverAutor(int idAutor)
        {
            var autores = await _autorInterface.RemoverAutor(idAutor);
            return Ok(autores);
        }
    }
}
