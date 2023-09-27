using CadastroSimples.Data.Common;
using CadastroSimples.Domain.Entities;
using CadastroSimples.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace CadastroSimples.Data.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public Client Delete(int id)
    {
        var client = Get(id);
        _context.Set<Client>().Remove(client);
        _context.SaveChanges();
        return client;
    }

    public Client Get(int id)
    {
        var keyValues = new object[] { id };
        return _context.Set<Client>().Find(keyValues);
    }

    public IEnumerable<Client> GetAll()
    {
        return _context.Set<Client>().ToList();
    }

    public Client Insert(Client client)
    {
        _context.Set<Client>().AddAsync(client);
        _context.SaveChanges();
        return client;
    }

    public Client Update(Client client)
    {
        _context.Entry(client).State = EntityState.Modified;
        _context.SaveChanges();
        return client;
    }
}
