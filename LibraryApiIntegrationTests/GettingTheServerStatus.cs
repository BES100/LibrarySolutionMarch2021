﻿using LibraryApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApiIntegrationTests
{
    public class GettingTheServerStatus : IClassFixture<CustomWebApplicationFactory>
    {

        private readonly HttpClient _client;
        public GettingTheServerStatus(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateDefaultClient();
        }

        // Did we get a 200 Ok?
        [Fact]
        public async Task HasOkStatus()
        {
            var response = await _client.GetAsync("/status");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        // Is it encoded as Json?
        [Fact]
        public async Task IsEncodedAsJson()
        {
            var response = await _client.GetAsync("/status");
            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);

        }
        // Is the representation we got what we expected?

        [Fact]
        public async Task HasCorrectRepresentation()
        {
            var response = await _client.GetAsync("/status");
            var representation = await response.Content.ReadAsAsync<GetStatusResponse>();
            Assert.Equal("Everything is going great. Thanks for asking!", representation.message);
            Assert.Equal(DateTime.Now, representation.lastChecked);
        }
    }


    public class GetStatusResponse
    {
        public string message { get; set; }
        public DateTime lastChecked { get; set; }
    }

}