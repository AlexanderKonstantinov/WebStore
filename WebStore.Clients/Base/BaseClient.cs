using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WebStore.Clients.Base
{
    /// <summary>
    /// Base client
    /// </summary>
    public abstract class BaseClient
    {
        /// <summary>
        /// Http client for connect
        /// </summary>
        protected HttpClient Client;

        /// <summary>
        /// Service address
        /// </summary>
        protected abstract string ServiceAddress { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="confi">Project configuration</param>
        public BaseClient(IConfiguration configuration)
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(configuration["ClientAddress"])
            };

            Client.DefaultRequestHeaders.Accept.Clear();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
