using CrudLivros.Dto;
using CrudLivros.Model;

namespace CrudLivros.Services.Autor;

public interface IAutorInterface
{
    Task<ResponseModel<List<AutorModel>>> ListarAutores();
    Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
    Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
    Task<ResponseModel<AutorModel>> CriarAutor(AutorInputDto autor);
}