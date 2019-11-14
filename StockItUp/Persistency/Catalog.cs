using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Newtonsoft.Json;

namespace StockItUp.Persistency
{
    class Catalog<T>
    {
        #region Instance fields

        private string _serverURL = "";                 //INSERT SERVER URL
        private string _apiPrefix = "api";
        private string _apiID;
        private HttpClientHandler _httpClientHandler;
        private HttpClient _httpClient;

        #endregion

        #region Constructors

        private Catalog(string apiID)
        {
            _apiID = apiID;
            _httpClientHandler = new HttpClientHandler();
            _httpClient = new HttpClient(_httpClientHandler);
        }

        #endregion

        #region Singleton
        private static Catalog<T> _instance;

        public static Catalog<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Catalog<T>(nameof(T)+"s");
                    return _instance;
                }

                return _instance;
            }
        }



        #endregion

        #region Methods

        public async Task Delete(int key)
        {
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync(url);
            
        }

        public async Task<List<T>> ReadAll()
        {
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID;

            var content = _httpClient.GetAsync(url).Result;
            if (content.IsSuccessStatusCode)
            {
                var objAsString = content.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<T>>(objAsString);
                return list;

            }

            return null;
            
        }

        public async Task<T> Read(int key)
        {
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;

            var content = _httpClient.GetAsync(url).Result;
            if (content.IsSuccessStatusCode)
            {
                var objAsString = content.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<T>(objAsString);
                return obj;

            }

            return default(T);
        }

        public async Task update(int key, T obj)
        {
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;

            var serializedString = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(serializedString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _httpClient.PutAsync(url, content);
        }

        #endregion



    }
}
