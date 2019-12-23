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
            dataBox.Text = "";
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
            //var dataArray = dataBox.Text.LineToArray();
            SendMultipleRequests();
            ReDraw();
        }

        private void SendMultipleRequests()
        {
            if(options == Options.Create)
            {
                var dataArray = dataBox.Text.LineToArray();
                foreach (var input in dataArray)
                {
                    SendSingleCreateRequest(input);
                }
                MessageBox.Show("Data successfully registered to API");
            }
            if (options == Options.Delete)
            {
                for (int i = 0; i < apiDataGrid.SelectedRows.Count; i++)
                {
                    var dto = apiDataGrid.SelectedRows[i].DataBoundItem;
                    SendSingleDeleteRequest(dto as IDto);
                }
            }
        }

        private void SendSingleDeleteRequest(IDto _dto)
        {
            if (_dto != null)
            {
                cvERepo.sendData(_dto, options);
            }
        }

        private void SendSingleCreateRequest(string input)
        {
            
            IDto _dto = null;
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
            if (documentButton.Checked)
            {
                domainDropDownList.Enabled = true;
                domainDropDownList.SelectedIndex = 0;
            }
            else
            {
                domainDropDownList.Enabled = false;
            }
                
            switch (action.SelectedIndex)
            {
                case 0:
                    options = Options.Create;
                    dataBox.Visible = true;
                    break;
                case 1:
                    options = Options.Edit;
                    dataBox.Visible = true;
                    break;
                case 2:
                    options = Options.Delete;
                    dataBox.Visible = false;
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
