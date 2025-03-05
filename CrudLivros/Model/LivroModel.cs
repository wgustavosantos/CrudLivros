namespace CrudLivros.Model;

public class LivroModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public AutorModel Autor { get; set; }
}