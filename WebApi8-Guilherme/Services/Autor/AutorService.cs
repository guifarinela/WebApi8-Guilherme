using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi8_Guilherme.Data;
using WebApi8_Guilherme.Dto.Autor;
using WebApi8_Guilherme.Models;

namespace WebApi8_Guilherme.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context) 
        {
            _context = context;
        }


        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {

                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor Localizado";
                return resposta;
                
            }catch (Exception ex)
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

                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor localizado";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {

                var autor = new AutorModel()
                {
                    Name = autorCriacaoDto.Name,
                    LastName = autorCriacaoDto.LastName
                };

                await _context.AddAsync(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Criado autor com sucesso";
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(x => x.Id == autorEdicaoDto.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor encontrado!";
                    return resposta;
                }

                autor.Name = autorEdicaoDto.Name;
                autor.LastName = autorEdicaoDto.LastName;
                _context.Autor.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Autor atualizado com sucesso!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(x => x.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor foi encontrado";
                    return resposta;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autor.ToListAsync();
                return resposta;
            }
            catch(Exception ex)
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

                var autores = await _context.Autor.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram coletados";

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
