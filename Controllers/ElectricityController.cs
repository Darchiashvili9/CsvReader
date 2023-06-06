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
using AutoMapper;
using System.Runtime.Intrinsics.Arm;
using System.Collections.Generic;

namespace ElectricityDataStore.Controllers
{
    [ApiController]
    [Route("api/elData")]
    public class ElectricityController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IElectrycityDataStoreRepository _repo;
        private readonly IMapper _mapper;

        public ElectricityController(HttpClient client, IElectrycityDataStoreRepository repo, IMapper mapper)
        {
            _client = client;
            _repo = repo;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task GetData()
        {
            var edm = new List<ElectrycityDataModel>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            var urlList = new List<string>()
            {
                "https://data.gov.lt/dataset/1975/download/10766/2022-05.csv",
                "https://data.gov.lt/dataset/1975/download/10765/2022-04.csv",
                "https://data.gov.lt/dataset/1975/download/10764/2022-03.csv",
                "https://data.gov.lt/dataset/1975/download/10763/2022-02.csv"
            };

            var semaphore = new SemaphoreSlim(4, 4);
            var tasks = urlList.Select(u => MakeRequest(u, semaphore, _client, config, edm));
            var allResponses = await Task.WhenAll(tasks);

            await _repo.AddData(edm);
        }
        private async Task<string> MakeRequest(string url, SemaphoreSlim semaphore, HttpClient httpClient, CsvConfiguration config, List<ElectrycityDataModel> edm)
        {
            try
            {
                await semaphore.WaitAsync();

                var response = await _client.GetAsync(url);
                using (var reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                {
                    var csvr = new CsvReader(reader, config);

                    //Filter only apartament (Butas) data 
                    var responseValue = csvr.GetRecords<ElectricityModel>().ToList().Where(e => e.Obt_Pavadinmas == "Butas");

                    var list = _mapper.Map<List<ElectrycityDataModel>>(responseValue);
                    edm.AddRange(list);
                }

                return await response.Content.ReadAsStringAsync();
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
