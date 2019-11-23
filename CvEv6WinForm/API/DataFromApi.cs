using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CvEv6WinForm.DTOs;

namespace CvEv6WinForm
{
    [Serializable]
    public class DataFromApi
    {


        public bool DataLoaded;

        public DataFromApi()
        {
        }


        public async Task<List<Domain>> getApiDomains()
        {
            DataLoaded = false;
            try
            {
                using (var client = new HttpClient())
                {
                    var res = await client.GetAsync($"http://localhost:10412/api/domains");
                    var content = await res.Content.ReadAsStringAsync();
                    
                    if (content != null)
                    {
                        var items = JsonConvert.DeserializeObject<List<Domain>>(content);
                        foreach (var item in items)
                        {
                            item.Documents.AddRange(await getApiDocumentsForDomain(item.Id));
                        }
                        DataLoaded = true;
                        return items;
                        //Parse your data into a object.
                        //domains = items;
                    }
                    else
                    {
                        MessageBox.Show("Woops");
                        return null;
                    }
                }
                //return items;
            }
            catch(Exception exception)
            {
                MessageBox.Show("Get Exceptioned");
                MessageBox.Show(exception.ToString());
                return null;
            }

        }

        private async Task<List<Document>> getApiDocumentsForDomain(int id)
        {
            {
                string baseUrl = "http://localhost:10412/api/domains/" + id + "/documents";
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var res = await client.GetAsync("http://localhost:10412/api/domains/" + id + "/documents");
                        var content = await res.Content.ReadAsStringAsync();


                        if (content != null)
                        {
                            //Parse your data into a object.
                            var items = JsonConvert.DeserializeObject<List<Document>>(content);
                            foreach (var item in items)
                            {
                                item.DomainId = id;
                            }
                            return items;
                            //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                            //Which will convert it to a string, since each property value is a instance of JToken.
                            //Log your pokeItem's name to the Console.
                        }
                        else
                        {
                            MessageBox.Show("Woops");
                            return null;
                        }
                        
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Get Exceptioned");
                    MessageBox.Show(exception.ToString());
                    return null;
                }

            }
        }

        public async Task<List<Title>> getTitles()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var res = await client.GetAsync($"http://localhost:10412/api/titles");
                    var content = await res.Content.ReadAsStringAsync();

                    if (content != null)
                    {
                        var items = JsonConvert.DeserializeObject<List<Title>>(content);
                        return items;
                    }
                    else
                    {
                        MessageBox.Show("Woops");
                        return null;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Get Exceptioned");
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public async Task<List<MainBody>> getMainBodies()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var res = await client.GetAsync($"http://localhost:10412/api/mainbody");
                    var content = await res.Content.ReadAsStringAsync();

                    if (content != null)
                    {
                        var items = JsonConvert.DeserializeObject<List<MainBody>>(content);
                        return items;
                    }
                    else
                    {
                        MessageBox.Show("Woops");
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Get Exceptioned");
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public static bool IsApiOnline()
        {
            try
            {
                using (var client = new WebClient())
                {
                    string result = client.DownloadString("http://localhost:10412/api/");
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("API Offline");
                return false;
            }
        }
    }
}
