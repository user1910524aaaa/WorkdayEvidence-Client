//using System;
//using System.Threading.Tasks;
//using System.Security.Claims;
//using Microsoft.Extensions.Caching.Memory;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Components.Authorization;
//using Newtonsoft.Json;

//using Client.Models;

//namespace Client.Services
//{
//    public class UserService: AuthenticationStateProvider
//    {

//        private IMemoryCache _cache;
//        private IHttpContextAccessor httpContextAccessor;

//        public UserService(IMemoryCache protectedSessionStore, IHttpContextAccessor httpContextAccessor) =>
//            (this._cache, this.httpContextAccessor) = (protectedSessionStore, httpContextAccessor);

//        public string role => httpContextAccessor?.HttpContext?.User?.ToString() ?? string.Empty;

//        private String Token {get; set; }
        
//        private UserModel User { get; set; }

//        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//        {
//            // read a possible user session object from the storage.
//            Token = await GetCashedToken();

//            if (Token != null)
//            {
//                return await GenerateAuthenticationState(User);
//            }
                
//            return await GenerateEmptyAuthenticationState();
//        }

//        public async Task<AuthenticationState> LoginAsync(String token)
//        {
//            // store the session information in the client's storage.
//            await SetCache(token);

//            // notify the authentication state provider.
//            NotifyAuthenticationStateChanged(GenerateAuthenticationState(User));
//            return null;
//        }

//        public async Task<AuthenticationState> LogoutAsync()
//        {
//            // delete the user's session object.
//            await SetCache(null);

//            // notify the authentication state provider.
//            NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
//            return null;
//        }

//        public async Task<String> GetCashedToken()
//        {

//            string token = _cache.Get<string>("token").ToString();

//            // no active user session found!
//            if (String.IsNullOrEmpty(token))
//                return null;

//            try
//            {
//                return RefreshUserSession(JsonConvert.DeserializeObject<String>(token));
//            }
//            catch
//            {
//                await LogoutAsync();
//                return null;
//            }
            
//        }

//        private Task<String> SetCache(String token)
//        {

//            RefreshUserSession(token);

//            _cache.Set<string>(JsonConvert.SerializeObject(token), "token");
//            return null;
//        }

//        private String RefreshUserSession(String token) => Token = token;

//        private Task<AuthenticationState> GenerateAuthenticationState(UserModel user)
//        {
//            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
//            {
//                new Claim(ClaimTypes.Sid, user.id.ToString()),
//                new Claim(ClaimTypes.Email, user.userName.ToString()),
//                new Claim(ClaimTypes.Role, user.role.ToString())
//            }, "apiauth_type");

//            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//            return Task.FromResult(new AuthenticationState(claimsPrincipal));
//        }

//        private Task<AuthenticationState> GenerateEmptyAuthenticationState() => Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
//    }

    
//}