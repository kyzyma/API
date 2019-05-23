using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using netapi.Interfaces;
using Newtonsoft.Json;

namespace netapi.Services
{   
    public class UsersService:IUsersService
    {
        private HttpClient _client;

        public UsersService(){
            _client = new HttpClient();
        }
        public async Task<List<User>> GetUsers()
        {
            var users = await _client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            return JsonConvert.DeserializeObject<List<User>>(users);
        }
        
         public async Task<User> GetUser(int id)
        {
            var users = await _client.GetStringAsync($"https://jsonplaceholder.typicode.com/users/{id}");
            return JsonConvert.DeserializeObject<User>(users);
        }        
    }

    public class User
        {
            [JsonProperty("id")]
            public int Id {get; set;}
            [JsonProperty("username")]
            public string Username {get; set;}
            [JsonProperty("email")]
            public string Email {get; set;}
            [JsonProperty("website")]
            public string Website {get; set;}
        }
}