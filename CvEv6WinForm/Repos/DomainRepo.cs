using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CvECommon;
using CvEv6WinForm.API;
using CvEv6WinForm.DTOs;

namespace CvEv6WinForm
{
    public class DomainRepo
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
        private static DomainRepo instance;
        private DataFromApi dataFromApi;
        public List<Domain> Domains;

        public int currentNumberOfDocs { get; set; }
        
        private DomainRepo()
        {
            Task.Run(() => getData());
        }

        public static DomainRepo GetInstance()
        {
            if (instance == null)
            {
                instance = new DomainRepo();
            }
            return instance;
        }


        public Domain GetItem(string name)
        {
            return Domains.Where(d => d.Name == name).FirstOrDefault();
        }

        public List<Domain> GetItems()
        {
            return Domains;
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
        }


        private async Task refreshData()
        {
            Domains = await dataFromApi.getApiDomains();
        }

        public void sendData(IDto _dto, Options options)
        {
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
    }
}
