using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Components.Authorization;

using Client.Models;

namespace Client.Services
{
    public class CustomAuthStateProvider: AuthenticationStateProvider
    {

        private IMemoryCache _cache;

        public CustomAuthStateProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {   
            var cachedClaims = _cache.Get<UserModel>("claims");

            if(cachedClaims != null)
            {

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, cachedClaims.userName.ToString()),
                    new Claim(ClaimTypes.Role, cachedClaims.role)
                }, "apiauth_type");
                var User = new ClaimsPrincipal(identity);

                return await Task.FromResult(new AuthenticationState(User));
            }

            else
            {
                var identity = new ClaimsIdentity();
                var User = new ClaimsPrincipal(identity);
                return await Task.FromResult(new AuthenticationState(User));
            }
            
        }

        public void MarkUserAsAuthenticated(UserModel user)
        {

            _cache.Set("claims", user, DateTimeOffset.Now.AddMinutes(30));

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.userName.ToString()),
                new Claim(ClaimTypes.Role, user.role)
            }, "apiauth_type");

            var User = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(User)));
        }

        public void LogUserOutAsync()
        {
            _cache.Remove("claims");
            _cache.Remove("token");
            // _cache.Dispose();

            var identity = new ClaimsIdentity();
            var User = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(User)));
        }
    }
}