using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Movie_Night_website
{
    public static class ExtensionMethods
    {
        public static string? GetClaimValue(this HttpContext context, string claimName)
        {
            if(context?.User == null)
            {
                return null;
            }
            return context.User.FindFirst(claimName)?.Value;
        }
    }
}
