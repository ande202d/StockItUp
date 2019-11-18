﻿using System;
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
    public class Catalog<T>
    {
        #region Instance fields

        private string _serverURL = "http://localhost:64064";                 //INSERT SERVER URL
        private string _apiPrefix = "api";
        private string _apiID;
        private HttpClient _httpClient;

        #endregion

        #region Constructors

        private Catalog(string apiID)
        {
            _apiID = apiID;
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            _httpClient = new HttpClient(httpClientHandler);
        }

        #endregion

        #region Singleton
        private static Catalog<T> _instance;

        //to make sure we don't make multiple instances of the same catalog
        public static Catalog<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    //nameof(T)
                    _instance = new Catalog<T>("product"+"s"); //the url should end on the class name +s
                    return _instance;
                }

                return _instance;
            }
        }



        #endregion

        #region Methods

        //takes a key and removes the object in the key position
        public async Task Delete(int key)
        {
            string url = _serverURL + "/" + _apiPrefix + "/" + _apiID + "/" + key;
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync(url);
            
        }

        //returns all the objects as a list
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

        //takes a key and returns the object in the key position
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

        //takes a key and an object
        //updates the old object from the key position to the new object you assigned
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
