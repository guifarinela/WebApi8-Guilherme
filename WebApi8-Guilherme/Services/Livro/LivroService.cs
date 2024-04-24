using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi8_Guilherme.Data;
using WebApi8_Guilherme.Dto.Livro;
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

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {

                if(livroCriacaoDto == null)
                {
                    resposta.Mensagem = "Não foi possivel criar um livro, favor verifique as informações";
                    return resposta;
                }

                var livro = await _context.Livros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == livroCriacaoDto.Id);
                var autor = await _context.Autor.FirstOrDefaultAsync(x => x.Id == livroCriacaoDto.Autor.Id);

                if(livro == null)
                {
                    resposta.Mensagem = "Não foi possivel criar um livro, favor verifique as informações";
                    return resposta;
                }

                if(autor == null)
                {
                    resposta.Mensagem = "Não foi possivel criar um livro, favor verifique as informações";
                    return resposta;
                }

                livro.Titulo = livroCriacaoDto.Titulo;
                livro.Autor = autor;

                await _context.AddAsync(livro);
                _context.SaveChanges();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Criado livro com sucesso!";
                return resposta;


            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == livroEdicaoDto.Id);

                var autor = await _context.Autor.FirstOrDefaultAsync(x => x.Id == livroEdicaoDto.Autor.Id);

                if (autor == null) 
                {
                    resposta.Mensagem = "Livro não encontrado";
                    return resposta;
                }

                if (livro == null) 
                {
                    resposta.Mensagem = "Livro não encontrado";
                    return resposta;
                }

                livro.Autor = autor;
                livro.Titulo = livroEdicaoDto.Titulo;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Edição realziada com sucesso!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem=ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(X => X.Id==idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado";
                    return resposta;
                }

                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro deletado conforme solicitado!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem=ex.Message;
                resposta.Status = false;
                return resposta;
            }
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

    }
}
