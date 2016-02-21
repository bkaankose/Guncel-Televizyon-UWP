using GuncelTelevizyonUWP.Models;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Helpers
{
    public class MobileServiceHelper
    {
        private MobileServiceClient _client;
        public MobileServiceHelper(MobileServiceClient client)
        {
            _client = client;
        }

        internal async Task<T> GetCustomApiData<T>(string apiEndpoint)
        {
            try
            {
                return await _client.InvokeApiAsync<T>(apiEndpoint, HttpMethod.Get, null);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        internal async Task<List<T>> GetTableData<T>()
        {
            var _ret = new List<T>();
            var table = _client.GetTable<T>();
            try
            {
                var collection = await table.ReadAsync();

                foreach (var item in collection)
                    _ret.Add(item);

                return _ret;
            }
            catch (Exception)
            {
                return default(List<T>);
            }
        }
        internal async Task<bool> PostTableData<T>(T data)
        {
            var splittedAssembly = data.GetType().ToString().Split('.');
            var tableName = splittedAssembly[splittedAssembly.Length - 1];
            var table = _client.GetTable(tableName);
            try
            {
                var jToken = await table.InsertAsync(JObject.Parse(JsonConvert.SerializeObject(data)));
                if (jToken == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
