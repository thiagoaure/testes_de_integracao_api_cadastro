using CadastroSimples.Domain.Entities;

namespace CadastroSimples.Domain.Interfaces.Repository;

public interface IClientRepository
{
    IEnumerable<Client> GetAll();
    Client Get(int id);
    Client Insert(Client client);
    Client Update(Client client);
    Client Delete(int id);
}
