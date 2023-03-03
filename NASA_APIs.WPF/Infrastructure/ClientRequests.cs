using NASA_APIs.DAL.Entities;
using NASA_APIs.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NASA_APIs.WPF.Infrastructure
{
    public class ClientRequests
    {
        private readonly HttpClient _Client;
        public ClientRequests(HttpClient Client) => _Client = Client;

        public async Task<ApodValue[]> GetAPOD(int count, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<ApodValue[]>($"planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&count={count}",
                Cancel).ConfigureAwait(false);
        }
        public async Task<ApodValue[]> GetAPOD(string date,
             IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            var year = date.Split('.')[2];
            var month = date.Split('.')[1];
            var day = date.Split('.')[0];
            return await _Client.GetFromJsonAsync<ApodValue[]>($"planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&start_date=" +
                $"{year}-{month}-{day}&end_date={year}-{month}-{day}",
                Cancel).ConfigureAwait(false);
        }
        public async Task<ApodValue[]> GetAPOD(string start_date, string end_date, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            var start_year = start_date.Split('.')[2];
            var start_month = start_date.Split('.')[1];
            var start_day = start_date.Split('.')[0];

            var end_year = end_date.Split('.')[2];
            var end_month = end_date.Split('.')[1];
            var end_day = end_date.Split('.')[0];
            return await _Client.GetFromJsonAsync<ApodValue[]>($"planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&start_date=" +
                $"{start_year}-{start_month}-{start_day}&end_date={end_year}-{end_month}-{end_day}",
                Cancel).ConfigureAwait(false);
        }
        public async Task<NeoWsValue> GetNeoWs(int id, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<NeoWsValue>($"neo/rest/v1/neo/{id}?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa",
                Cancel).ConfigureAwait(false);
        }
        public async Task<NeoWsValue> GetNeoWs(IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<NeoWsValue>($"neo/rest/v1/neo/browse?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa",
                Cancel).ConfigureAwait(false);
        }
        public async Task<NeoWsValue> GetNeoWsPage(int page, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<NeoWsValue>($"neo/rest/v1/neo/browse?page={page}&size=20&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa",
                Cancel).ConfigureAwait(false);
        }
        public async Task<MarsValue> GetMarsPhotos(int sol, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<MarsValue>($"mars-photos/api/v1/rovers/curiosity/photos?" +
                  $"sol={sol}&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }
        public async Task<MarsValue> GetMarsPhotos(int sol, string camera, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<MarsValue>($"mars-photos/api/v1/rovers/curiosity/photos?" +
                $"sol={sol}&camera={camera}&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }
        public async Task<MarsValue> GetMarsPhotos(int sol, int page, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<MarsValue>($"mars-photos/api/v1/rovers/curiosity/photos?" +
                $"sol={sol}&page={page}&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }
        public async Task<TechTransferModel> GetTechTransfers(string soft, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<TechTransferModel>($"techtransfer/patent/?{soft}" +
                $"&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }
        public async Task<TechPortModel> GetTechPort(int id, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<TechPortModel>($"techport/api/projects/{id}?" +
                $"api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }
        public async Task<TechPortProjectsModel> GetTechPort(IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<TechPortProjectsModel>($"techport/api/projects?" +
                $"api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }
        public async Task<TechPortProjectsModel> GetTechPort(DateTime date, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<TechPortProjectsModel>($"techport/api/projects?updatedSince={date.Year}-{date.Month}-{date.Day}" +
                $"&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }


    }
}


