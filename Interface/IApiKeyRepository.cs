using Transacoes.Models;
using System.Threading.Tasks;

namespace Transacoes.Interface
{
    public interface IApiKeyRepository
    {
        Task<ApiKey?> GetByKeyAsync(string apiKey);
    }
}