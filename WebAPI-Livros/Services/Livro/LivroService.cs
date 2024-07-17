using Microsoft.EntityFrameworkCore;
using WebAPI_Livros.Data;
using WebAPI_Livros.DTO.Livro;
using WebAPI_Livros.models;
using WebAPI_Livros.Models;

namespace WebAPI_Livros.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorID(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                resposta.Dados = livro;
                if(resposta.Dados == null)
                {
                    resposta.Mensagem = "Nenhum livro encontrado!";
                    return resposta;
                }
                resposta.Mensagem = "Livro encontrado com sucesso!";
                return resposta;

            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivrosPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();
                resposta.Dados = livros;
                if(resposta.Dados == null)
                {
                    resposta.Mensagem = "Nenhum livro encontrado!";
                    return resposta;
                }
                resposta.Mensagem = "Livro(s) encontrados com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDto livro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livro.AutorId);
                if(autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }
                var novoLivro = new LivroModel
                {
                    Titulo = livro.Titulo,
                    Autor = autor
                };

                _context.Livros.Add(novoLivro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "Livro criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(int idLivro, LivroDto livroDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if(livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroDto.AutorId);
                if(autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }
                livro.Titulo = livroDto.Titulo;
                livro.Autor = autor;

                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "Livro editado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "Livros listados com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> RemoverLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro =  await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }
                _context.Livros.Remove(livro);
                _context.SaveChanges();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "Livro removido com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
