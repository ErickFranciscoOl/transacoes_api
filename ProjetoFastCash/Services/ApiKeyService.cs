using Microsoft.EntityFrameworkCore;
using ProjetoFastCash.Context;
using ProjetoFastCash.Interface;
using ProjetoFastCash.Models;

namespace ProjetoFastCash.Services
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