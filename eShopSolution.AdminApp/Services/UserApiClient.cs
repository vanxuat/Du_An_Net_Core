using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public UserApiClient(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5001");

           var response =  await client.PostAsync("/api/Users/authenticate", httpContent);
            var token =  await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await response.Content.ReadAsStringAsync());
        }

        public Task<ApiResult<bool>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<UserVm>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
