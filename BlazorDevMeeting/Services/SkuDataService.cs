using BlazorDevMeeting.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlazorDevMeeting.Services
{
    public interface ISkuDataService
    {
        Task<List<SkuModel>> GetListOfSku(string sortField, bool sortDesc);
    }

    public class SkuDataService : ISkuDataService
    {
        public HttpClient HttpClient { get; }

        public SkuDataService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<SkuModel>> GetListOfSku(string sortField, bool sortDesc)
        {
            var url = "your api url";

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "your token");
            var response = await HttpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<SkuList>(json);

            if (sortDesc)
            {
                return data.results.OrderByDescending(s => s.GetType().GetProperty(sortField).GetValue(s)).ToList();
            }
            else {
                return data.results.OrderBy(s => s.GetType().GetProperty(sortField).GetValue(s)).ToList();
            }
        }
    }
}
