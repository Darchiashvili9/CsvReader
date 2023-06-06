using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System;
using System.Net.Http.Headers;
using CsvHelper;
using CsvHelper.Configuration;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using ElectricitydataStore.Models;
using ElectricitydataStore.Repository;

namespace ElectricityDataStore.Controllers
{
    [ApiController]
    [Route("api/elData")]
    public class ElectricityController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IElectrycityDataStoreRepository _repo;

        public ElectricityController(HttpClient client, IElectrycityDataStoreRepository repo)
        {
            _client = client;
            _repo = repo;
        }



        [HttpGet]
        public async Task GetData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            var _serviceUrl = "https://data.gov.lt/dataset/1975/download/10766/2022-05.csv";
          
            var response = await _client.GetAsync(_serviceUrl);
            using (var reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            {
                var csvr = new CsvReader(reader,config);
               
                var responseValue = csvr.GetRecords<ElectricityModel>().ToList();
               
                await _repo.AddData(responseValue);



            }
        }
    }
}
