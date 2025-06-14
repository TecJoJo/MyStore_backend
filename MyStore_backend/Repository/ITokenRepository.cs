using Microsoft.AspNetCore.Identity;

namespace MyStore_backend.Repository
{
    public interface ITokenRepository
    {
        public string createJwtToken(IdentityUser user);
    }
}
