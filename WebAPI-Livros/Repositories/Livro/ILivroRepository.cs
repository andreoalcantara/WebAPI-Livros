using WebAPI_Livros.models;

namespace WebAPI_Livros.Repositories.Livro
{
    public interface ILivroRepository
    {
        Task<LivroModel> GetLivroById(int idLivro);
        Task<List<LivroModel>> GetAllLivros();
        Task<List<LivroModel>> GetLivrosByAutorId(int idAutor);
        Task AddLivro(LivroModel livro);
        Task UpdateLivro(LivroModel livro);
        Task RemoveLivro(LivroModel livro);
    }
}
