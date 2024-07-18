using Microsoft.EntityFrameworkCore;
using WebAPI_Livros.Data;
using WebAPI_Livros.models;
using WebAPI_Livros.Services.Livro;

namespace WebAPI_Livros.Repositories.Livro
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddLivro(LivroModel livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LivroModel>> GetAllLivros()
        {
            return await _context.Livros.Include(a => a.Autor).ToListAsync();
        }

        public async Task<LivroModel> GetLivroById(int idLivro)
        {
            return await _context.Livros.FirstOrDefaultAsync(livro => livro.Id == idLivro);
        }

        public async Task<List<LivroModel>> GetLivrosByAutorId(int idAutor)
        {
            var livros = await _context.Livros.Include(a => a.Autor).Where(livroBanco => livroBanco.Autor.Id == idAutor).ToListAsync();
            return livros;
        }

        public async Task RemoveLivro(LivroModel livro)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLivro(LivroModel livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }
    }
}
