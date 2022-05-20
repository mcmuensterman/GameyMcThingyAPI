using GameyMcThingy.Models.Token;
using System.Threading.Tasks;

namespace GameyMcThingy.Services.Token
{
    public interface ITokenService
    {
         Task<TokenResponse> GetTokenAsync(TokenRequest model);
    }
}