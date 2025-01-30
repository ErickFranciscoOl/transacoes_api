using Transacoes.Models;

namespace Transacoes.Interface;

public interface IApiKeyService
{
    bool IsApiKeyValid(string apiKey);
    Task<ApiKey?> GetByKeyAsync(string apiKey);
}