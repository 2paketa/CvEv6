using CvECommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CvEv6WinForm
{
    public partial class Form1 : Form
    {
        private MainBody mainbody;
        private DomainRepo domainRepo;
        string[] desiredDomains;

        public Form1()
        {
            InitializeComponent();
            //Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data"));
            //var domainsLibrary = Path.Combine(Directory.GetCurrentDirectory(), "Data\\domains.csv");
            //using (var stream = File.Open(domainsLibrary, FileMode.OpenOrCreate))
            //{
            //}
            domainRepo = DomainRepo.GetInstance();
            numericDoc.Maximum = domainRepo.MaxNumberOfDocs;
            getText.Enabled = false;
            label5.Text = "";
        }

        private void Run()
        {
            mainbody = new MainBody();
            domainRepo.currentNumberOfDocs = (int)numericDoc.Value;
            mainbody.YearsOfExperience = (int)numericYearExp.Value;
            desiredDomains = selectedDomains.Text.LineToArray();
            finalText.Text = mainbody.Get(desiredDomains);
            desiredDomains = null;
            mainbody = null;
        }

        private void commaSeparated_CheckedChanged(object sender, EventArgs e)
        {
            if (commaSeparated.Checked) { Formatting.currentID = 1; }
        }

        private void bulletPoints_CheckedChanged(object sender, EventArgs e)
        {
            if (bulletPoints.Checked) { Formatting.currentID = 2; }
        }

        private void random_CheckedChanged(object sender, EventArgs e)
        {
            if (random.Checked) { Formatting.currentID = 0; }
        }

        private void selectedDomains_TextChanged(object sender, EventArgs e)
        {
            numericDoc.Maximum = domainRepo.MaxNumberOfDocs;
            var tempDomains = selectedDomains.Text
                .LineToArray();
            if (tempDomains.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                tempDomains = tempDomains
                    .GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.First())
                    .ToArray();
                label5.Text = $"Please remove the following duplicate value(s): {tempDomains.CommaSeparated()}";
                label5.ForeColor = Color.Red;
                getText.Enabled = false;
            }
            else if (domainRepo.isInputValid(selectedDomains.Text.LineToArray()))
            {
                label5.Text = "Click 'Get Text' to generate text";
                label5.ForeColor = Color.Green;
                getText.Enabled = true;
            }
            else
            {
                label5.Text = "Please insert at least one valid domain or more separated by comma and/or space";
                label5.ForeColor = Color.Red;
                getText.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sendToAPI_Click(object sender, EventArgs e)
        {

            var form2 = new Form2();
            form2.Show();
        }

        private void getText_Click(object sender, EventArgs e)
        {
            Run();
            label5.Text = "";
        }

    }
}
