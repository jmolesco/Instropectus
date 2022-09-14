using Introspectus.Api.Infrastructure.Cache;
using Introspectus.Api.Interfaces;
using Introspectus.Api.Models;
using Introspectus.Api.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Introspectus.Api.Repository
{
    public class MobileSpeedCameraRepository : IMobileSpeedCameraRepository
    {
        private readonly ILogger<MobileSpeedCameraRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string APIUrl;
        public MobileSpeedCameraRepository(ILogger<MobileSpeedCameraRepository> logger, IConfiguration configuration, ICacheService cacheService, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _cacheService = cacheService;
            _clientFactory = clientFactory;
            APIUrl = _configuration.GetValue<string>(Constants.APIURL);
        }
        public async Task<List<MobileSpeedCameraResponse>> SearchMobileSpeedCamera()
        {
            string apiResponse = string.Empty;
            var result = new List<MobileSpeedCameraResponse>();

     
            try
            {
             
                var client = _clientFactory.CreateClient("ApiHttpsHandler");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // calling regis claims API search method
                var regisClaimsResponse = await client.GetAsync(APIUrl);

                apiResponse = await regisClaimsResponse.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    try
                    {
                         result = JsonConvert.DeserializeObject<List<MobileSpeedCameraResponse>>(apiResponse);
                    }
                    catch (Exception)
                    {
                       
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace);
           
            }
            return result;
        }
    }
}
