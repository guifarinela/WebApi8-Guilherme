using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi8_Guilherme.Data;
using WebApi8_Guilherme.Models;

namespace WebApi8_Guilherme.Services.Livro
{
    public class LivroService : ILivroInterface
    {


        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {

                var livro = await _context.Livros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro encontrado!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.Include(x => x.Autor).Where(x => x.Autor.Id == idAutor).ToListAsync();

                if (livros == null)
                {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }
                resposta.Dados = livros;
                resposta.Mensagem = "Livro encontrado!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<LivroModel>>> ListaLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.Include(x => x.Autor).ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Não existem livros Cadastrados!";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livros encontrados!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        Task<ResponseModel<LivroModel>> ILivroInterface.BuscarLivroPorIdAutor(int idLivro)
        {
            throw new NotImplementedException();
        }
    }
}
