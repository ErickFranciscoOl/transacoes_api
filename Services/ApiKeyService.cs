using Microsoft.EntityFrameworkCore;
using Transacoes.Context;
using Transacoes.Interface;
using Transacoes.Models;

namespace Transacoes.Services
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly AppDbContext _context;

        public ApiKeyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiKey?> GetByKeyAsync(string apiKey)
        {
            return await _context.ApiKeys.FirstOrDefaultAsync(a => a.ApiKeys == apiKey);
        }

        public bool IsApiKeyValid(string apiKey)
        {
            return _context.ApiKeys.Any(a => a.ApiKeys == apiKey);
        }
    }
}