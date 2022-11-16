using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using NASA_APIs.Models;
using NASA_APIs.Converters;
using System.Threading.Tasks;

namespace NASA_APIs
{
    public class NASA_APIsClient
    {
        private readonly HttpClient _Client;
        public NASA_APIsClient(HttpClient Client)=> _Client = Client;

        public async Task<APODModel[]> GetAPODwithCount(int count, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<APODModel[]>($"https://api.nasa.gov/planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&count={count}",
                Cancel).ConfigureAwait(false);
        }
        public async Task<APODModel[]> GetAPODwithDate((string Year, string Month, string Day) start_date, 
            (string Year, string Month, string Day) end_date = default, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            end_date = start_date;
            return await _Client.GetFromJsonAsync<APODModel[]>($"https://api.nasa.gov/planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&start_date=" +
                $"{start_date.Year}-{start_date.Month}-{start_date.Day}&end_date={end_date.Year}-{end_date.Month}-{end_date.Day}",
                Cancel).ConfigureAwait(false);
        }
        public async Task<APODModel[]> GetAPODwithPeriod((string Year, string Month, string Day) start_date, (string Year, string Month, string Day) end_date, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<APODModel[]>($"https://api.nasa.gov/planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&start_date={start_date.Year}-{start_date.Month}-{start_date.Day}&end_date={end_date.Year}-{end_date.Month}-{end_date.Day}",
                Cancel).ConfigureAwait(false);
        }
    }
   
    
}
