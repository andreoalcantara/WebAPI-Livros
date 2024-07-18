using WebAPI_Livros.models;

namespace WebAPI_Livros.Repositories.Autor
{
    public interface IAutorRepository
    {
        Task<AutorModel> GetAutorById(int idAutor);
        Task<AutorModel> GetAutorByLivroId(int idLivro);
        Task<List<AutorModel>> GetAllAutores();
        Task AddAutor(AutorModel autor);
        Task UpdateAutor(AutorModel autor);
        Task RemoveAutor(AutorModel autor);
    }
}
