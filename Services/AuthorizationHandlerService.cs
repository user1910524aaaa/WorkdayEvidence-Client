using Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Services
{
    public class AuthorizationHandlerService : IAuthorizationHandlerService
    {
        private NavigationManager _navManager;
        private AuthenticationStateProvider _authStateProvider;

        public AuthorizationHandlerService(NavigationManager navManager, AuthenticationStateProvider authStateProvider)
        {
            _navManager = navManager;
            _authStateProvider = authStateProvider;
        }

        public async Task Redirect()
        {
            var state = await ((CustomAuthStateProvider)_authStateProvider).GetAuthenticationStateAsync();

            if (!state.User.Identity.IsAuthenticated)
            {
                _navManager.NavigateTo("/login", true);
            }
        }
    }
}
