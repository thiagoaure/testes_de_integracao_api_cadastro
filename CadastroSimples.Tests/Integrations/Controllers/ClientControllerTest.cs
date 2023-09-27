using AutoBogus;
using CadastroSimples.Domain.Entities;
using CadastroSimples.Tests.Configurations;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit.Abstractions;

namespace CadastroSimples.Tests.Integrations.Controllers;

public class ClientControllerTest : IClassFixture<WebApplicationFactory<Program>>, IAsyncLifetime
{
    private readonly WebApplicationFactory<Program> _factory;
    protected readonly ITestLoggerFactory _output;
    protected readonly HttpClient _httpClient;
    protected Client client;

    public ClientControllerTest(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _factory = factory;
        _output = new TestLoggerFactory(output);
        _httpClient = _factory.CreateClient();
    }

    [Fact]
    public async Task Cadastrar_InformandoCliente_DeveRetornarClienteESucesso()
    {
        //Arrange
        client = new AutoFaker<Client>(AutoBogusConfig.LOCATE)
            .RuleFor(p => p.Email, faker => faker.Person.Email)
            .RuleFor(x => x.Sex, (f, u) => f.Random.AlphaNumeric(2));

        StringContent content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
        
        // Act
        var httpClientRequest = await _httpClient.PostAsync("api/Client", content);

        // Assert
        _output.WriteLine($"{nameof(ClientControllerTest)}_{nameof(Cadastrar_InformandoCliente_DeveRetornarClienteESucesso)} = {await httpClientRequest.Content.ReadAsStringAsync()}");
        Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
    }

    [Fact]
    public async Task ObterTodosClientes_PeloGetAll_DeveRetornarClientesESucesso()
    {
        // Arrange
        //await InitializeAsync();

        //Act
        var httpClientRequest = await _httpClient.GetAsync("api/Client");

        //Assert
        _output.WriteLine($"{nameof(ClientControllerTest)}_{nameof(ObterTodosClientes_PeloGetAll_DeveRetornarClientesESucesso)} = {await httpClientRequest.Content.ReadAsStringAsync()}");
        var clients = JsonConvert.DeserializeObject<IList<Client>>(await httpClientRequest.Content.ReadAsStringAsync());
        Assert.NotNull(clients);
        Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);

    }

    [Fact]
    public async Task ObterCliente_InformandoId_DeveRetornarClienteESucesso()
    {
        // Arrange
        //await InitializeAsync();

        //Act
        var httpClientRequest = await _httpClient.GetAsync($"api/Client/{client.Id}");

        //Assert
        _output.WriteLine($"{nameof(ClientControllerTest)}_{nameof(EditarCliente_InformandoId_DeveRetornarClienteESucesso)} = {await httpClientRequest.Content.ReadAsStringAsync()}");
        var getClient = JsonConvert.DeserializeObject<Client>(await httpClientRequest.Content.ReadAsStringAsync());
        Assert.NotNull(getClient);
        Assert.Equal(client.Email, getClient.Email);
        Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);

    }

    [Fact]
    public async Task EditarCliente_InformandoId_DeveRetornarClienteESucesso()
    {
        // Arrange
        //await InitializeAsync();

        Client newClient = new AutoFaker<Client>(AutoBogusConfig.LOCATE)
            .RuleFor(p => p.Email, faker => faker.Person.Email)
            .RuleFor(x => x.Sex, (f, u) => f.Random.AlphaNumeric(2))
            .RuleFor(x => x.Id, client.Id);

        StringContent content = new StringContent(JsonConvert.SerializeObject(newClient), Encoding.UTF8, "application/json");

        //Act
        var httpClientRequest = await _httpClient.PutAsync($"api/Client/{client.Id}", content);

        //Assert
        _output.WriteLine($"{nameof(ClientControllerTest)}_{nameof(EditarCliente_InformandoId_DeveRetornarClienteESucesso)} = {await httpClientRequest.Content.ReadAsStringAsync()}");
        var getClient = JsonConvert.DeserializeObject<Client>(await httpClientRequest.Content.ReadAsStringAsync());
        Assert.NotNull(getClient);
        Assert.Equal(client.Id, getClient.Id);
        Assert.NotEqual(client.Name, getClient.Name);
        Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);

    }

    [Fact]
    public async Task DeletarCliente_InformandoId_DeveRetornarClienteDeletadoESucesso()
    {
        //Arrange
        //await InitializeAsync();

        //Act
        var httpClientRequest = await _httpClient.DeleteAsync($"api/Client/{client.Id}");

        //Assert
        _output.WriteLine($"{nameof(ClientControllerTest)}_{nameof(DeletarCliente_InformandoId_DeveRetornarClienteDeletadoESucesso)} = {await httpClientRequest.Content.ReadAsStringAsync()}");
        var getClient = JsonConvert.DeserializeObject<Client>(await httpClientRequest.Content.ReadAsStringAsync());
        Assert.NotNull(getClient);
        Assert.Equal(client.Id, getClient.Id);
        Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
    }


    public async Task InitializeAsync()
    {
        await Cadastrar_InformandoCliente_DeveRetornarClienteESucesso();
    }

    public async Task DisposeAsync()
    {
        _httpClient.Dispose();
    }
}
