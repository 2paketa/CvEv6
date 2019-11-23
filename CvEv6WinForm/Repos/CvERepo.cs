using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CvECommon;
using CvEv6WinForm.API;
using CvEv6WinForm.DTOs;

namespace CvEv6WinForm
{
    [Serializable]
    public class CvERepo
    {
        public int MaxNumberOfDocs
        {
            get
            {
                var maxNumberOfDocs = 0;
                while (Domains == null)
                {
                    continue;
                }
                foreach (var domain in Domains)
                {
                    if (domain.Documents.Count > maxNumberOfDocs)
                    {
                        maxNumberOfDocs = domain.Documents.Count;
                    }
                }
                return maxNumberOfDocs;
            }
        }

        

        private static CvERepo instance;
        private DataFromApi dataFromApi;
        public List<Domain> Domains;
        private List<Title> titles;
        private static string repoOfflinePath = Path.Combine(Directory.GetCurrentDirectory(), "Data\\CvERepo.dat");
        private static string domainsOfflinePath = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Domains.dat");
        private static string titlesOfflinePath = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Titles.dat");

        public int currentNumberOfDocs { get; set; }
        public List<MainBody> MainBodies { get; private set; }

        private CvERepo()
        {
            if (DataFromApi.IsApiOnline())
            {
                Task.Run(() => instance.getData());
            }
            else
            {
                RestoreOfflineData();
            }

        }

        //public bool IsApiOnline()
        //{
        //    try
        //    {
        //        Task.Run(() => getData());
        //    }
        //    catch (Exception ex)
        //    {
        //        using (var sr = new StreamReader(repoOfflinePath))
        //        {
        //            instance = (CvERepo)b.Deserialize(sr.BaseStream);
        //        }
        //    }
        //}

        public static CvERepo GetInstance()
        {
            if (instance == null) { instance = new CvERepo(); }

            return instance;
        }


        public Domain GetDomain(string name)
        {
            return Domains.Where(d => d.Name == name).FirstOrDefault();
        }

        public List<Domain> GetDomains()
        {
            return Domains.OrderBy(d => d.Name).ToList();
        }

        public List<MainBody> GetMainBodies()
        {
            return MainBodies.OrderBy(d => d.Name).ToList();
        }

        public string[] getDocs(string name)
        {
            var items = Domains.Where(d => d.Name == name).FirstOrDefault().Documents.ToArray();
            List<string> itemsNameList = new List<string>();
            foreach (var item in items)
            {
                itemsNameList.Add(item.Name);
            }
            return itemsNameList.ToArray();
        }

        public List<Title> GetTitles()
        {
            while (titles == null) { }
            return titles.OrderBy(d => d.Name).ToList();
        }

        public bool isInputValid(string[] input)
        {
            var isValid = true;
            foreach (string item in input)
            {
                if (!Domains.Any(d => d.Name == item) || string.IsNullOrEmpty(item))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        //private void setMaxNumberOfDocs()
        //{
        //    foreach (var domain in Domains)
        //    {
        //        if (domain.Documents.Count > maxNumberOfDocs)
        //        {
        //            maxNumberOfDocs = domain.Documents.Count;
        //        }
        //    }
        //}

        public async Task getData()
        {
            dataFromApi = new DataFromApi();
            Domains = await dataFromApi.getApiDomains();
            titles = await dataFromApi.getTitles();
            MainBodies = await dataFromApi.getMainBodies();
        }


        private async Task refreshData()
        {
            Domains = await dataFromApi.getApiDomains();
            titles = await dataFromApi.getTitles();
            MainBodies = await dataFromApi.getMainBodies();
        }

        public void sendData(IDto _dto, Options options)
        {
            if (!DataFromApi.IsApiOnline())
            {
                MessageBox.Show("API offline, unable to send data at the moment");
                return;
            }
            StoreDataToApi store = new StoreDataToApi(_dto);
            if (options == Options.Create)
            {
                store.CreateData();
            }
            else if (options == Options.Delete)
            {
                store.delData();
            }
            Task.Run(() => refreshData()).Wait();
        }

        public string[] GetNames()
        {
            var domainsName = new List<string>();
            foreach (var domain in Domains)
            {
                domainsName.Add(domain.Name);
            }
            return domainsName.ToArray();
        }

        public void SaveDataOffline()
        {
            BinaryFormatter b = new BinaryFormatter();
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data"));
            using (Stream stream = File.Open(repoOfflinePath, FileMode.Create))
            {
                b.Serialize(stream, instance);
            }
            MessageBox.Show("Data succesfully saved to file");
        }

        public void RestoreOfflineData()
        {
            BinaryFormatter b = new BinaryFormatter();
            using (Stream sr = File.Open(titlesOfflinePath, FileMode.Open))
            {
                titles = (List<Title>)b.Deserialize(sr);
            }

            using (Stream sr = File.Open(domainsOfflinePath, FileMode.Open))
            {
                Domains = (List<Domain>)b.Deserialize(sr);
            }
        }
    }
}
