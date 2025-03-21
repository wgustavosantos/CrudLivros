using CrudLivros.Data;
using CrudLivros.Dto;
using CrudLivros.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudLivros.Services.Autor;

public class AutorService : IAutorInterface
{
    private readonly AppDbContext _context;

    public AutorService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
    {
        var resposta = new ResponseModel<List<AutorModel>>();
        
        try
        {
            var autores = await _context.Autor.ToListAsync();
            resposta.Dados = autores;
            resposta.Mensagem = "Todos os autores foram coletados!";
            return resposta;
        }
        catch (Exception e)
        {
           resposta.Mensagem = e.Message;
           resposta.Status = false;
           return resposta;
        }
    }

    public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
    {
        var resposta = new ResponseModel<AutorModel>();
        
        try
        {
            var autor = await _context.Autor.FirstOrDefaultAsync(a => a.Id == idAutor);

            if (autor is null)
            {
                resposta.Status = false;
                resposta.Mensagem = "Nenhum autor foi encontrado!";
                return resposta;
            }
            resposta.Dados = autor;
            resposta.Mensagem = "Autor foi encontrado!";
            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
    {
        var resposta = new ResponseModel<AutorModel>();
        
        try
        {
            var livro = await _context.Livro
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(livro => livro.Id == idLivro);

            if (livro is null)
            {
                resposta.Status = false;
                resposta.Mensagem = "Nenhum autor foi encontrado!";
                return resposta;
            }
            resposta.Dados = livro.Autor;
            resposta.Mensagem = "Autor foi encontrado!";
            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<AutorModel>> CriarAutor(AutorInputDto autorInputDto)
    {
        var resposta = new ResponseModel<AutorModel>();

        try
        {
            var autor = new AutorModel(autorInputDto.Nome, autorInputDto.Sobrenome);
             _context.Autor.Add(autor);
            await _context.SaveChangesAsync();
            resposta.Dados = autor;
            resposta.Mensagem = "Autor criado com sucesso!";
            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<AutorModel>> AtualizarAutor(int idAutor, AutorInputDto autor)
    {
       var resposta = new ResponseModel<AutorModel>();

       try
       {
           var autorDb = await _context.Autor.FirstOrDefaultAsync(a => a.Id == idAutor);

           if (autorDb is null)
           {
               resposta.Status = false;
               resposta.Mensagem = "Autor não foi encontrado!";
               return resposta;
           }
           
           autorDb.Nome = autor.Nome;
           autorDb.Sobrenome = autor.Sobrenome;
           _context.Autor.Update(autorDb);
           await _context.SaveChangesAsync();
           
           resposta.Dados = autorDb;
           resposta.Mensagem = "Autor atualizado!";
           return resposta;
       }
       catch (Exception e)
       {
           resposta.Mensagem = e.Message;
           resposta.Status = false;
           return resposta;
       }
    }

    public async Task<ResponseModel<AutorModel>> DeletarAutor(int idAutor)
    {
        var resposta = new ResponseModel<AutorModel>();

        try
        {
            var autorDb = await _context.Autor.FirstOrDefaultAsync(a => a.Id == idAutor);

            if (autorDb is null)
            {
                resposta.Status = false;
                resposta.Mensagem = "Nenhum autor cadastrado!";
                return resposta;
            }
            _context.Autor.Remove(autorDb);
            await _context.SaveChangesAsync();
            resposta.Mensagem = "Autor deletado!";
            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}