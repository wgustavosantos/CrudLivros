using CrudLivros.Dto;
using CrudLivros.Model;
using CrudLivros.Services.Autor;
using Microsoft.AspNetCore.Mvc;

namespace CrudLivros.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorInterface _autorInterface;

    public AutorController(IAutorInterface autorInterface)
    {
        _autorInterface = autorInterface;
    }

    [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
    {
        var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
        return Ok(autor); 
    }
    
    [HttpGet("BuscarAutorPorId/{idAutor}")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
    {
        var autor = await _autorInterface.BuscarAutorPorId(idAutor);
        return Ok(autor);
    }

    [HttpGet("ListarAutores")]
    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
    {
        var autores = await _autorInterface.ListarAutores();
        return Ok(autores);
    }

    [HttpPost("InserirAutor")]
    public async Task<IActionResult> Post([FromBody] AutorInputDto autor)
    {
        var autorCriado = await _autorInterface.CriarAutor(autor);
        return Ok(autorCriado);
    }

    [HttpPut("AtualizarAutor/{idAutor}")]
    public async Task<IActionResult> Put(int idAutor, [FromBody] AutorInputDto autor)
    {
        var atualizarAutor = await _autorInterface.AtualizarAutor(idAutor, autor);
        return Ok(atualizarAutor);
    }

    [HttpDelete("DeletarAutor/{idAutor}")]
    public async Task<IActionResult> Delete(int idAutor)
    {
        var deletarAutor = await _autorInterface.DeletarAutor(idAutor);
        return Ok(deletarAutor);
    }
}