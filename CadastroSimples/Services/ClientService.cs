using CadastroSimples.Domain.Entities;
using CadastroSimples.Domain.Interfaces.Repository;
using CadastroSimples.Domain.Interfaces.Service;

namespace CadastroSimples.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Client Delete(int id)
    {
        return _clientRepository.Delete(id);
    }

    public Client Get(int id)
    {
        var client = _clientRepository.Get(id);
        if (client == null) return null;
        return client;
    }

    public IEnumerable<Client> GetAll()
    {
        var list = _clientRepository.GetAll();
        if (list.Count() == 0) return null;
        return list;
    }

    public Client Insert(Client client)
    {
        return _clientRepository.Insert(client);
    }

    public Client Update(Client client)
    {
        return _clientRepository.Update(client);
    }
}
