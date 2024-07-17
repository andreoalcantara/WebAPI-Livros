using WebAPI_Livros.Data;
using WebAPI_Livros.DTO.Autor;
using WebAPI_Livros.models;
using WebAPI_Livros.Models;

namespace WebAPI_Livros.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorID(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDto autor);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(int idAutor, AutorDto autor);
        Task<ResponseModel<List<AutorModel>>> RemoverAutor(int idAutor);
    }
}
