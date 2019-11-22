using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CvECommon;

namespace CvEv6WinForm
{
    class Header
    {
        List<Title> titles;
        int currentYear;
        int yearsOfExperience;
        int startingYear;
        Random rng;
        
        public Header(int yearsOfExperience)
        {
            rng = new Random();
            this.yearsOfExperience = yearsOfExperience;
            currentYear = DateTime.Now.Year;
            startingYear = currentYear - yearsOfExperience;
            var titlesInstance = TitleRepo.GetInstance();
            titles = titlesInstance.GetTitles();
        }

        public string Get()
        {
            var title = $"{titles[rng.Next(titles.Count)].Name}";
            string result;
            if (title.Contains(nameof(startingYear)))
            {
                result = Regex.Replace(title, nameof(startingYear), startingYear.ToString());
            }
            else
            {
                result = Regex.Replace(title, nameof(yearsOfExperience), yearsOfExperience.ToString());
            }
            return result;
        }
    }
}
