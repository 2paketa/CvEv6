using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CvECommon;

namespace CvEv6WinForm
{
    class Activities
    {
        private CvERepo _cvERepo;
        Random rng;
        public Activities()
        {
            _cvERepo = CvERepo.GetInstance();
            rng = new Random();
        }

        public string getDocsOfDomain(string domain)
        {
            var fulltext = $"{domain} ";
            var randomDocs = _cvERepo.getDocs(domain);
            if (randomDocs == null) { return null; }
            int numberOfDocsPerDomain;
            if (randomDocs.Length < _cvERepo.currentNumberOfDocs) { numberOfDocsPerDomain = randomDocs.Length; } else { numberOfDocsPerDomain = _cvERepo.currentNumberOfDocs; }
            rng.Shuffle(randomDocs);
            for (int i = 0; i < numberOfDocsPerDomain; i++)
            {
                if (i == 0)
                    fulltext += $"({randomDocs[i]}";
                else
                    fulltext += $", {randomDocs[i]}";
            }
            fulltext += ")";
            return fulltext;
        }


        public string getDomains(string[] domains)
        {
            string domainText = "";
            string[] domainsAndDocs = domains;
            rng.Shuffle(domains);

            for (int i = 0; i < domains.Length; i++)
            {
                domainsAndDocs[i] = getDocsOfDomain(domainsAndDocs[i]);
            }
            domainText = domainsAndDocs.ApplyFormatting();
            return domainText;
        }

        public string getDomains()
        {
            string domainText = "";
            string[] domainsAndDocs = getRandomDomainNames();
            rng.Shuffle(domainsAndDocs);
            for (int i = 0; i < domainsAndDocs.Length; i++)
            {
                domainsAndDocs[i] = getDocsOfDomain(domainsAndDocs[i]);
            }
            domainText = domainsAndDocs.ApplyFormatting();
            return domainText;
        }

        private string[] getRandomDomainNames()
        {
            var randomDocs = new List<string>();
            var domains = _cvERepo.GetDomains().Where(d => d.Documents.Count > 0).ToList();
            foreach (var domain in domains.Take(rng.Next(2, domains.Count)))
            {
                randomDocs.Add(domain.Name);
            }
            return randomDocs.ToArray();
        }
    }
}
