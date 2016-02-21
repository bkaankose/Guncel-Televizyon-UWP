using GuncelTelevizyonUWP.Models;
using Microsoft.WindowsAzure.MobileServices;
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
            return await _client.InvokeApiAsync<T>(apiEndpoint,HttpMethod.Get,null);
        }

        internal async Task<List<T>> GetTableData<T>()
        {
            var _ret = new List<T>();
            var table = _client.GetTable<T>();
            var collection = await table.ReadAsync();

            foreach (var item in collection)
                _ret.Add(item);

            return _ret;
        }
    }
}
