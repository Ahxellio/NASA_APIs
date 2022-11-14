using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NASA_APIs
{
    public class NASA_APIsClient
    {
        private readonly HttpClient _Client;
        public NASA_APIsClient(HttpClient Client)=> _Client = Client;

        public async Task<APOD[]> GetAPOD(int count)
        {
            return await _Client.GetFromJsonAsync<APOD[]>($"https://api.nasa.gov/planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&count={count}");
        }

    }
    public class APOD
    {
        DateTime date { get; set; }
        DateTime start_date { get; set; }
        DateTime end_date { get; set; }
        int count { get; set; }
        bool thumbs { get; set; }

    }
}
