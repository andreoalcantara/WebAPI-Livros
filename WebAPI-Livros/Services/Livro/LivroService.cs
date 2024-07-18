using WebAPI_Livros.DTO.Livro;
using WebAPI_Livros.models;
using WebAPI_Livros.Models;
using WebAPI_Livros.Repositories.Autor;
using WebAPI_Livros.Repositories.Livro;

namespace WebAPI_Livros.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;

        public LivroService(ILivroRepository livroRepository, IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorID(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _livroRepository.BuscarLivroPorID(idLivro);
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
                var livros = await _livroRepository.BuscarLivrosPorIdAutor(idAutor);
                resposta.Dados = livros.Dados;
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
                var autor = await _autorRepository.GetAutorById(livro.AutorId);
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

                await _livroRepository.AddLivro(novoLivro);

                resposta.Dados = await _livroRepository.GetAllLivros();
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
                var livro = await _livroRepository.BuscarLivroPorID(idLivro);
                if(livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }
                var autor = await _autorRepository.GetAutorById(livroDto.AutorId);
                if(autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }
                livro.Titulo = livroDto.Titulo;
                livro.Autor = autor;

                await _livroRepository.UpdateLivro(livro);

                resposta.Dados = await _livroRepository.GetAllLivros();
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
                resposta.Dados = await _livroRepository.GetAllLivros();
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
                var livro =  await _livroRepository.GetLivroById(idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }
                await _livroRepository.RemoveLivro(livro);

                resposta.Dados = await _livroRepository.GetAllLivros();
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
