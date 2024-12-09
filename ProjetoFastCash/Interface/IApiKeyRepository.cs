using ProjetoFastCash.Models;
using System.Threading.Tasks;

namespace ProjetoFastCash.Interface
{
    public interface IApiKeyRepository
    {
        Task<ApiKey?> GetByKeyAsync(string apiKey);
    }
}
