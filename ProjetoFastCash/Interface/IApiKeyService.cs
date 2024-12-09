using ProjetoFastCash.Models;

namespace ProjetoFastCash.Interface;

public interface IApiKeyService
{
    bool IsApiKeyValid(string apiKey);
    Task<ApiKey?> GetByKeyAsync(string apiKey);
}
