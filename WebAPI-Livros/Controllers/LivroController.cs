using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Livros.DTO.Livro;
using WebAPI_Livros.models;
using WebAPI_Livros.Models;
using WebAPI_Livros.Services.Livro;

namespace WebAPI_Livros.Controllers
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

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var resposta = await _livroInterface.ListarLivros();
            return Ok(resposta);
        }

        [HttpGet("BuscarLivroPorID")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorID(int idLivro)
        {
            var resposta = await _livroInterface.BuscarLivroPorID(idLivro);
            return Ok(resposta);
        }

        [HttpGet("BuscarLivrosPorIdAutor")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarLivrosPorIdAutor(int idAutor)
        {
            var resposta = await _livroInterface.BuscarLivrosPorIdAutor(idAutor);
            return Ok(resposta);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroDto livro)
        {
            var resposta = await _livroInterface.CriarLivro(livro);
            return Ok(resposta);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(int idLivro, LivroDto livro)
        {
            var resposta = await _livroInterface.EditarLivro(idLivro, livro);
            return Ok(resposta);
        }

        [HttpDelete("RemoverLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> RemoverLivro(int idLivro)
        {
            var resposta = await _livroInterface.RemoverLivro(idLivro);
            return Ok(resposta);
        }
    }
}
