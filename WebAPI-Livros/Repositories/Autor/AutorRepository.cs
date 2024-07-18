using Microsoft.EntityFrameworkCore;
using WebAPI_Livros.Data;
using WebAPI_Livros.models;

namespace WebAPI_Livros.Repositories.Autor
{
    public class AutorRepository : IAutorRepository
    {
        private readonly AppDbContext _context;

        public AutorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAutor(AutorModel autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AutorModel>> GetAllAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<AutorModel> GetAutorById(int idAutor)
        {
            return await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == idAutor);
        }

        public async Task<AutorModel> GetAutorByLivroId(int idLivro)
        {
            var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
            return livro.Autor;
        }

        public async Task RemoveAutor(AutorModel autor)
        {
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAutor(AutorModel autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }
    }
}
