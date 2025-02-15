using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTtokenMVC.ServiceImplemention
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secret;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _secret = configuration["JwtSettings:Secret"];
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Cookies["AuthToken"];
            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_secret);
                    var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    }, out _);

                    context.User = claimsPrincipal;
                }
                catch
                {
                    // Token is invalid or expired
                }
            }

            await _next(context);
        }
    }
}
