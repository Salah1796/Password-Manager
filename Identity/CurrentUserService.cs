using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor = null)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? GetCurrentUserId()
        {
            var context = _httpContextAccessor.HttpContext;
            var identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                Guid userId;
                var userIdClaim = identity.Claims?.FirstOrDefault(c => c.Type == "UserId")?.Value;
                if (!string.IsNullOrEmpty(userIdClaim))
                {
                    if(Guid.TryParse(userIdClaim, out userId))
                    {
                        return userId;  
                    }
                }
            }
            return null;
        }
    }
}
