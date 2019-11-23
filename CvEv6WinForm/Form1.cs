using CvECommon;
using CvEv6WinForm.API;
using CvEv6WinForm.DTOs;
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
        private GenerateMainBody generateMainBody;
        private CvERepo cvERepo;
        string[] desiredDomains;

        public Form1()
        {
            InitializeComponent();
            cvERepo = CvERepo.GetInstance();
            numericDoc.Maximum = cvERepo.MaxNumberOfDocs;
            getText.Enabled = false;
            
            label5.Text = "";
        }

        private void Run()
        {
            generateMainBody = new GenerateMainBody();
            cvERepo.currentNumberOfDocs = (int)numericDoc.Value;
            generateMainBody.YearsOfExperience = (int)numericYearExp.Value;
            desiredDomains = selectedDomains.Text.LineToArray();
            finalText.Text = generateMainBody.Get(desiredDomains);
            desiredDomains = null;
            generateMainBody = null;
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
            numericDoc.Maximum = cvERepo.MaxNumberOfDocs;
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
            else if (cvERepo.isInputValid(selectedDomains.Text.LineToArray()))
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

        private void button1_Click(object sender, EventArgs e)
        {
            generateMainBody = new GenerateMainBody();
            cvERepo.currentNumberOfDocs = cvERepo.MaxNumberOfDocs;
            var mainBodies = new List<MainBody>();
            for (int i = 0; i < 30 ; i++)
            {
                if (!DataFromApi.IsApiOnline()) { break; }
                var mainbody = new MainBody { Name = generateMainBody.Get() };
                if (!mainBodies.Any(m => m.Name == mainbody.Name))
                {
                    cvERepo.sendData(new MainBody { Name = generateMainBody.Get() }, Options.Create);
                    mainBodies.Add(mainbody);
                }
            }
            MessageBox.Show("Done!");
        }
    }
}
