namespace CrudLivros.Model;

public class AutorModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public ICollection<LivroModel> Livros { get; set; } = new List<LivroModel>();

    public AutorModel(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }
}