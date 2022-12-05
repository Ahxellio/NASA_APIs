using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using NASA_APIs.Models;
using NASA_APIs.Converters;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace NASA_APIs
{
    public class NASA_APIsClient
    {
        private readonly HttpClient _Client;
        public NASA_APIsClient(HttpClient Client)=> _Client = Client;

        public async Task<APODModel[]> GetAPOD(int count, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<APODModel[]>($"planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&count={count}",
                Cancel).ConfigureAwait(false);
        }
        public async Task<APODModel[]> GetAPOD(DateTime start_date, 
             IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            DateTime end_date = start_date;
            return await _Client.GetFromJsonAsync<APODModel[]>($"planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&start_date=" +
                $"{start_date.Year}-{start_date.Month}-{start_date.Day}&end_date={end_date.Year}-{end_date.Month}-{end_date.Day}",
                Cancel).ConfigureAwait(false);
        }
        public async Task<APODModel[]> GetAPOD(DateTime start_date, DateTime end_date, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<APODModel[]>($"planetary/apod?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa&start_date=" +
                $"{start_date.Year}-{start_date.Month}-{start_date.Day}&end_date={end_date.Year}-{end_date.Month}-{end_date.Day}",
                Cancel).ConfigureAwait(false);
        }
        public async Task<NeoWsModel> GetNeoWs(int id,IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<NeoWsModel>($"neo/rest/v1/neo/{id}?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa",
                Cancel).ConfigureAwait(false);
        }
        public async Task<NeoWsModel> GetNeoWs(IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<NeoWsModel>($"neo/rest/v1/neo/browse?api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa",
                Cancel).ConfigureAwait(false);
        }
        public async Task<MarsRoversModel> GetMarsPhotos(int sol, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
              return await _Client.GetFromJsonAsync<MarsRoversModel>($"mars-photos/api/v1/rovers/curiosity/photos?" +
                    $"sol={sol}&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }
        public async Task<MarsRoversModel> GetMarsPhotos(int sol, string camera, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
                return await _Client.GetFromJsonAsync<MarsRoversModel>($"mars-photos/api/v1/rovers/curiosity/photos?" +
                    $"sol={sol}&camera={camera}&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }
        public async Task<MarsRoversModel> GetMarsPhotos(int sol, int page, IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<MarsRoversModel>($"mars-photos/api/v1/rovers/curiosity/photos?" +
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
        public async Task<TechPortProjectsModel> GetTechPort(DateTime date,IProgress<double> Progress = default, CancellationToken Cancel = default)
        {
            return await _Client.GetFromJsonAsync<TechPortProjectsModel>($"techport/api/projects?updatedSince={date.Year}-{date.Month}-{date.Day}" +
                $"&api_key=Q7ybo1n8FBtVagagquxxfZMX74TMiQcOTtxqIzSa", Cancel).ConfigureAwait(false);
        }


    }
   
    
}
