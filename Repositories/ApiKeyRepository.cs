using Microsoft.EntityFrameworkCore;
using Transacoes.Context;
using Transacoes.Interface;
using Transacoes.Models;
using System.Threading.Tasks;

namespace Transacoes.Repositories
{
    public class ApiKeyRepository : IApiKeyRepository
    {
        private readonly AppDbContext _context;

        public ApiKeyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiKey?> GetByKeyAsync(string apiKey)
        {
            return await _context.ApiKeys.FirstOrDefaultAsync(a => a.ApiKeys == apiKey);
        }
    }
}