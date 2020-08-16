using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PersonReader.Service
{
    public class ServiceReader : IPersonReader
    {
        HttpClient client = new HttpClient();

        public ServiceReader(ServiceReaderUri baseUri)
        {
            client.BaseAddress = new Uri(baseUri.ServiceUriString);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IReadOnlyCollection<Person>> GetPeople()
        {
            HttpResponseMessage response = await client.GetAsync("people");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Person>>(stringResult);
            }
            return new List<Person>();
        }

        public async Task<Person> GetPerson(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"people/{id}");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Person>(stringResult);
            }
            return new Person();
        }
    }
}
