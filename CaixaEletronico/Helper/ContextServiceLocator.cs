using caixaEletronico.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace CaixaEletronico.Helper
{
    public class ContextServiceLocator
    {
        public IContaRepository ContaRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IContaRepository>();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
