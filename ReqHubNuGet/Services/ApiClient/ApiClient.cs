﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ReqHub
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(IHttpClientFactory httpClientFactory, string name)
        {
            this.httpClient = httpClientFactory.CreateClient(name);
        }

        public async Task<TResult> GetAsync<TResult>(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.httpClient.GetAsync(path, cancellationToken);
            var result = await response.Content.ReadAsAsync<TResult>(cancellationToken);

            return result;
        }

        public async Task<TResult> PostAsync<TResult>(string path, HttpContent content, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.httpClient.PostAsync(path, content, cancellationToken);
            var result = await response.Content.ReadAsAsync<TResult>(cancellationToken);

            return result;
        }

        public async Task<TResult> PutAsync<TResult>(string path, HttpContent content, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.httpClient.PutAsync(path, content, cancellationToken);
            var result = await response.Content.ReadAsAsync<TResult>(cancellationToken);

            return result;
        }

        public async Task<TResult> PatchAsync<TResult>(string path, HttpContent content, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.httpClient.PatchAsync(path, content, cancellationToken);
            var result = await response.Content.ReadAsAsync<TResult>(cancellationToken);

            return result;
        }

        public async Task<TResult> DeleteAsync<TResult>(string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.httpClient.DeleteAsync(path, cancellationToken);
            var result = await response.Content.ReadAsAsync<TResult>(cancellationToken);

            return result;
        }

        public async Task<HttpResponseMessage> SendAsync(string path, HttpMethod method, HttpContent content = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(path, UriKind.Relative),
                Method = method,
                Content = content
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await this.httpClient.SendAsync(request, cancellationToken);
            return response;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await this.httpClient.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
