using ClienteApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClienteApi.Services { 
public class ClienteServices
{
    private readonly IMongoCollection<Cliente> _contextoCollection;





    //Conexao do meu Banco de dados
    public ClienteServices(IOptions<ContextoMongoDb> clienteServices)
    {
        var mongoClient = new MongoClient(clienteServices.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(clienteServices.Value.DatabaseName);

            //A ligação da tabela acontece aqui
            _contextoCollection = mongoDatabase.GetCollection<Cliente>
            (clienteServices.Value.ContextoCollectionName);
    }

    //Metodos de serviço para se usar na API

    // lista todos os clientes 
    public async Task<List<Cliente>> GetAsync() =>
        await _contextoCollection.Find(x => true).ToListAsync();

    // pesquisa um cliente especifico 
    public async Task<Cliente?> GetAsync(string id) =>
        await _contextoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    // criar cliente
    public async Task CreateAsync(Cliente novoCliente)
    {
        var dbCliente = await _contextoCollection
            .Find(f => f.Cpf == novoCliente.Cpf || f.Email == novoCliente.Email)
            .FirstOrDefaultAsync();

        if (dbCliente != null)
        {
            throw new Exception("Já existe esse usuário");
        }


        await _contextoCollection.InsertOneAsync(novoCliente);

    }



    //atualiza cliente com referencia Id
    public async Task UpdateAsync(string id, Cliente atualizarCliente) =>
        await _contextoCollection.ReplaceOneAsync(x => x.Id == id, atualizarCliente);



    //Delete
    public async Task RemoveAsync(string id) =>
        await _contextoCollection.DeleteOneAsync(x => x.Id == id);



    }
}