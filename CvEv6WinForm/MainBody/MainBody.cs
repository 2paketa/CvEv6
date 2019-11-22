using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CvECommon;

namespace CvEv6WinForm
{
    public class MainBody
    {
        public int YearsOfExperience { get; set; }
        Activities activities;
        Header header;
        public MainBody()
        {
            activities = new Activities();
        }
        
        public string Get(string[] domains)
        {
            header = new Header(YearsOfExperience);
            string finalText = $"{header.Get()}";
            finalText += Environment.NewLine;
            finalText += activities.getDomains(domains);
            return finalText;
        }


    }
}