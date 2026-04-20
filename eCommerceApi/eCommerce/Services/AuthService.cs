using eCommerce.Data;
using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _context;
        private readonly ITokenService _tokens;

        public AuthService(DatabaseContext context, ITokenService tokens)
        {
            _context = context;
            _tokens = tokens;
        }

        public async Task<bool> RegisterAsync(AuthRegisterDTO input)
        {
            if (EmailExists(input.Email)) return false;

            User user = input.Adapt<User>();
            user.Email = user.Email.ToLower();
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AuthResponseDTO?> LoginAsync(AuthLoginDTO input, HttpResponse response)
        {
            input.Email = input.Email.ToLower();
            User? user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Email == input.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(input.Password, user.Password))
                return null;

            return await IssueTokens(user, response);
        }

        public async Task<AuthResponseDTO?> RefreshAsync(string refreshToken, HttpResponse response)
        {
            User? user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(r => r.Token == refreshToken && !r.IsRevoked));

            if (user == null) return null;

            RefreshToken token = user.RefreshTokens.First(r => r.Token == refreshToken);
            if (token.ExpiryDate < DateTime.UtcNow || token.IsRevoked)
                return null;

            token.IsRevoked = true;
            return await IssueTokens(user, response);
        }

        private async Task<AuthResponseDTO> IssueTokens(User user,  HttpResponse response)
        {
            string accessToken = _tokens.GenerateAccessToken(user);
            string refreshToken = _tokens.GenerateRefreshToken();

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            });
            await _context.SaveChangesAsync();

            response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });

            AuthResponseDTO authResponse = new()
            {
                AccessToken = accessToken
            };
            return authResponse;
        }

        public async Task LogoutAsync(string refreshToken)
        {
            RefreshToken? token = await _context.RefreshTokens
                .FirstOrDefaultAsync(r => r.Token == refreshToken);
            if (token == null) return;

            token.IsRevoked = true;
            await _context.SaveChangesAsync();
        }

        private bool EmailExists(string email)
        {
            return (_context.Users?.Any(u => u.Email == email)).GetValueOrDefault();
        }
    }
}
