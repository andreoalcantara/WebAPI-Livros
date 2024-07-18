using Microsoft.EntityFrameworkCore;
using WebAPI_Livros.Data;
using WebAPI_Livros.DTO.Autor;
using WebAPI_Livros.models;
using WebAPI_Livros.Models;
using WebAPI_Livros.Repositories.Autor;

namespace WebAPI_Livros.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorID(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _autorRepository.GetAutorById(idAutor);
                resposta.Dados =  autor;
                if(resposta.Dados == null)
                {
                    resposta.Mensagem = "Nenhum autor encontrado!";
                    return resposta;
                }
                resposta.Mensagem = "Autor encontrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try 
            {
                var autor = await _autorRepository.GetAutorByLivroId(idLivro);

                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum autor encontrado!";
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor encontrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _autorRepository.GetAllAutores();

                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores listados com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                await _autorRepository.AddAutor(autor);
                
                resposta.Dados = await _autorRepository.GetAllAutores();
                resposta.Mensagem = "Autor criado com sucesso!";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(int idAutor, AutorDto autor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autorBanco = await _autorRepository.GetAutorById(idAutor);
                if(autorBanco == null)
                {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }

                autorBanco.Nome = autor.Nome;
                autorBanco.Sobrenome = autor.Sobrenome;

                await _autorRepository.UpdateAutor(autorBanco);

                resposta.Dados = await _autorRepository.GetAllAutores();
                resposta.Mensagem = "Autor editado com sucesso!";
                return resposta;

            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> RemoverAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _autorRepository.GetAutorById(idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }

                await _autorRepository.RemoveAutor(autor);

                resposta.Dados = await _autorRepository.GetAllAutores();
                resposta.Mensagem = "Autor removido com sucesso!";
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
