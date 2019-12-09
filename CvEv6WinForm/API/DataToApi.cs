using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using CvEv6WinForm.API;
using CvEv6WinForm.DTOs;

namespace CvEv6WinForm
{
    [Serializable]
    public class StoreDataToApi
    {
        private IDto _dto;
        HttpClient client;

        public StoreDataToApi(IDto dto)
        {
            _dto = dto;

        }
        public StoreDataToApi(IDto dto, Options options)
        {
            _dto = dto;
            if (options == Options.Create)
            {
                CreateData();
            }
            else if (options == Options.Delete)
            {
                delData();
            }
            
        }

        public void CreateData()
        {
            using (client = new HttpClient())
            {
                var jsonstr = JsonConvert.SerializeObject(new { name = _dto.Name });
                var value = new StringContent(jsonstr, Encoding.UTF8, "application/json");
                var url = "http://localhost:10412/api/";
                if (_dto is MainBody)
                {
                    url += $"{_dto.GetType().Name}/";
                }
                else if (_dto is Document)
                {
                    var doc = _dto as Document;
                    url += $"/domains/{doc.DomainId}/documents";
                }
                else
                {
                    url += $"{_dto.GetType().Name}s/";
                }
                var res = client.PostAsync(url, value);

                try
                {
                    res.Result.EnsureSuccessStatusCode();
                    //MessageBox.Show("Data successfully registered to API");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            //var value = JsonConvert.SerializeObject($"name: {_documentName}");
            //var content = new StringContent(value, Encoding.UTF8, "application/json");
            //var response = await _client.PostAsync("http://localhost:10412/api/domains/" + _domainId + "/documents", content);
        }

        public void delData()
        {

            using (client = new HttpClient())
            {
                var url = "http://localhost:10412/api/" + $"{_dto.GetType().Name}s/{_dto.Id}";
                if (_dto is Document)
                {
                    Document doc = _dto as Document;
                    url = "http://localhost:10412/api/domains/" + $"{doc.DomainId}/documents/{doc.Id}";
                }
                var res = client.DeleteAsync(url);

                try
                {
                    res.Result.EnsureSuccessStatusCode();
                    MessageBox.Show("Data successfully removed from the API");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            //var value = JsonConvert.SerializeObject($"name: {_documentName}");
            //var content = new StringContent(value, Encoding.UTF8, "application/json");
            //var response = await _client.PostAsync("http://localhost:10412/api/domains/" + _domainId + "/documents", content);
        }

    }
}
