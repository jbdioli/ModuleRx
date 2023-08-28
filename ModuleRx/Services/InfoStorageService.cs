using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ModuleRx.Models_Dto;
using ModuleRx.Shared;
using Newtonsoft.Json;

namespace ModuleRx.Services
{
    public class InfoStorageService
    {

        //private RxNetHandler _rxNetHandler;

        private HttpClient _httpClient;
        private List<InfoDto> _infos;


        public InfoStorageService()
        {
            _infos = new List<InfoDto>();
            InitHttps();

        }


        

        public async Task<List<InfoDto>> GetInfosDetails()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts?userId=1");
            var content = response.Content;


            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await content.ReadAsStringAsync();
                _infos = JsonConvert.DeserializeObject<List<InfoDto>>(jsonResponse);
            }
            else
            {
                throw new Exception(((int)response.StatusCode).ToString() + " - " + response.ReasonPhrase);
            }

            RxNetHandler.InfoSubject.OnNext(_infos);
            return _infos;
        }



        private void InitHttps()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(15);
            _httpClient.MaxResponseContentBufferSize = 256000;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

    }
}