namespace CadastroSimples.Domain.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }  = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
}
