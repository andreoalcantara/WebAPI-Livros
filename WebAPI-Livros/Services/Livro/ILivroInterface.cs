using WebAPI_Livros.DTO.Autor;
using WebAPI_Livros.DTO.Livro;
using WebAPI_Livros.models;
using WebAPI_Livros.Models;

namespace WebAPI_Livros.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorID(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivrosPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDto livro);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(int idLivro, LivroDto livro);
        Task<ResponseModel<List<LivroModel>>> RemoverLivro(int idLivro);
    }
}
