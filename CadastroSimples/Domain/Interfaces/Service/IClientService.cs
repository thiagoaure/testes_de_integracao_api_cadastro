using CadastroSimples.Domain.Entities;

namespace CadastroSimples.Domain.Interfaces.Service;

public interface IClientService
{
    IEnumerable<Client> GetAll();
    Client Get(int id);
    Client Insert(Client client);
    Client Update(Client client);
    Client Delete(int id);

}
