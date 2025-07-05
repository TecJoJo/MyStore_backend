using Microsoft.AspNetCore.Identity;

namespace MyStore_backend.Repository.Auth
{
    public interface ITokenRepository
    {
        public string createJwtToken(IdentityUser user);
    }
}
