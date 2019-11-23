using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CvECommon;

namespace CvEv6WinForm
{
    public class GenerateMainBody
    {
        public int YearsOfExperience { get; set; }
        Activities activities;
        Header header;
        Random rng;
        public GenerateMainBody()
        {
            activities = new Activities();
            rng = new Random();
        }
        
        public string Get(string[] domains)
        {
            header = new Header(YearsOfExperience);
            string finalText = $"{header.Get()}";
            finalText += Environment.NewLine;
            finalText += activities.getDomains(domains);
            return finalText;
        }

        public string Get()
        {
            header = new Header(rng.Next(2, 20));
            string finalText = $"{header.Get()}";
            finalText += Environment.NewLine;
            finalText += activities.getDomains();
            return finalText;
        }


    }
}