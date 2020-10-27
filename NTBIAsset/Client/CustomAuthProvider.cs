using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTBIAsset.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using MatBlazor;

namespace NTBIAsset.Client
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public CustomAuthProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            UserAccount currentUser = await _httpClient.GetJsonAsync<UserAccount>("api/UserAccounts/getcurrentuser");

            if(currentUser != null && currentUser.Username != null)
            {
                var claim = new Claim(ClaimTypes.Name, currentUser.Username);

                var claimId = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(currentUser.Id));

                //create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(new[] { claim, claimId }, "serverAuth");
                //create claimPrinciple
                var claimPrinciple = new ClaimsPrincipal(claimsIdentity);
                var state = new AuthenticationState(claimPrinciple);

                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }
         
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
          
        }
    }
}
