using CvECommon;
using CvEv6WinForm.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Threading;
using System.Collections.Concurrent;
using CvEv6WinForm.DTOs;

namespace CvEv6WinForm
{
    public partial class Form2 : Form
    {
        CvERepo cvERepo;
        List<Domain> domains { get { return cvERepo.GetDomains(); } }
        List<Title> titles { get { return cvERepo.GetTitles(); } }

        List<MainBody> mainBodies { get { return cvERepo.GetMainBodies(); } }
        Options options;
        public Form2()
        {
            InitializeComponent();
            action.SelectedIndex = 0;
            cvERepo = CvERepo.GetInstance();
        }

        private void ReDraw()
        {
            domainButton.Checked = false;
            titleButton.Checked = false;
            documentButton.Checked = false;
            apiDataGrid.DataSource = null;
        }


        private void domainButton_Checked(object sender, EventArgs e)
        {
            domainDropDownList.Enabled = false;
            apiDataGrid.DataSource = domains;
            GenerateNumbersForFirstRow();
        }

        private void titleButton_Checked(object sender, EventArgs e)
        {
            domainDropDownList.Enabled = false;
            apiDataGrid.DataSource = titles;
            GenerateNumbersForFirstRow();
        }
        private void documentButton_CheckedChanged(object sender, EventArgs e)
        {
            domainDropDownList.Items.Clear();
            var _dtoNamesLIst = cvERepo.GetNames();
            domainDropDownList.Enabled = true;
            domainDropDownList.Items.AddRange(_dtoNamesLIst);
            domainDropDownList.SelectedIndex = 0;
            if (options == Options.Create)
            {
                dataBox.Visible = true;
            }
            if (options == Options.Delete)
            {
                domainDropDownList.Enabled = true;
            }
            GenerateNumbersForFirstRow();
        }

        private void GenerateNumbersForFirstRow()
        {
            var rows = apiDataGrid.Rows;

            for (int i = 0; i < rows.Count; i++)
            {
                rows[i].Cells[0].Value = i + 1;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            var dataArray = dataBox.Text.LineToArray();
            SendMultipleRequests(dataArray);
            ReDraw();
        }

        private void SendMultipleRequests(string[] dataArray)
        {
            foreach (var input in dataArray)
            {
                SendSingleRequest(input);
            }
        }

        private void SendSingleRequest(string input)
        {
            IDto _dto = null;
            if (options == Options.Delete)
            {
                if (apiDataGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete");
                }
                _dto = apiDataGrid.SelectedRows[0].DataBoundItem as IDto;
            }
            if (options == Options.Create)
            {
                if (input == "")
                {
                    MessageBox.Show("Please insert a valid input");
                    return;
                }
                if (titleButton.Checked)
                {
                    _dto = new Title { Name = input };
                }
                if (domainButton.Checked)
                {
                    _dto = new Domain { Name = input };
                }
                if (documentButton.Checked)
                {
                    var domain = domains.Where(d => d.Name == domainDropDownList.Text).FirstOrDefault();
                    _dto = new Document { Name = input, DomainId = domain.Id };
                }
                if (mainBodyButton.Checked)
                {
                    _dto = new MainBody { Name = input };
                }
            }

            if (_dto != null)
            {
                cvERepo.sendData(_dto, options);
            }
        }

        private void action_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataBox.Visible = false;
            domainDropDownList.Enabled = false;
            switch (action.SelectedIndex)
            {
                case 0:
                    options = Options.Create;
                    if (documentButton.Checked)
                    {
                        domainDropDownList.Enabled = true;
                    }
                    else
                    {
                        dataBox.Visible = true;
                        domainDropDownList.Enabled = false;
                    }
                    break;
                case 2:
                    options = Options.Delete;
                    dataBox.Visible = false;
                    if (documentButton.Checked)
                    {
                        domainDropDownList.Enabled = true;
                        domainDropDownList.SelectedIndex = 0;
                    }
                    break;
            }
        }



        private void domainDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDomain = domains.Where(d => d.Name == domainDropDownList.Text).FirstOrDefault();
            apiDataGrid.DataSource = selectedDomain.Documents;
            GenerateNumbersForFirstRow();
        }

        private void saveOffline_Click(object sender, EventArgs e)
        {
            cvERepo.SaveDataOffline();
        }

        private void mainBodyButton_CheckedChanged(object sender, EventArgs e)
        {
            domainDropDownList.Enabled = false;
            apiDataGrid.DataSource = mainBodies;
            GenerateNumbersForFirstRow();
        }
    }
}
