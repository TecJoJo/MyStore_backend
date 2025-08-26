using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MyStore_backend.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static Guid GetCurrentUserId(this ControllerBase controller)
        {
            var userIdClaim = controller.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                throw new UnauthorizedAccessException("User identity claim (NameIdentifier) not found. Ensure the user is properly authenticated.");
            }

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                throw new UnauthorizedAccessException($"Invalid user ID format in claims: '{userIdClaim}'. Expected a valid GUID.");
            }

            return userId;
        }
    }
}
