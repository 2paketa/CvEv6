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
        DomainRepo domainRepo;
        TitleRepo titleRepo;
        List<Domain> domains;
        List<Title> titles;
        Options options;
        public Form2()
        {
            InitializeComponent();
            apiDataGrid.Columns.Add("NumberColumn", "#");
            action.SelectedIndex = 0;
            domainRepo = DomainRepo.GetInstance();
            titleRepo = TitleRepo.GetInstance();
            domains = domainRepo.GetItems();
            titles = titleRepo.GetTitles();
        }

        private void ReDraw()
        {
            progressBar1.Visible = true;
            //var loadDataTask = getData();
            //Task.Run(() => loadDataTask);
            //progressBar1.Visible = true;
            //var completedTask = Task.WhenAll(loadDataTask);
            //while (completedTask == null)
            //{
            //    continue;
            //}
            domains = domainRepo.GetItems();
            progressBar1.Visible = false;
            domainButton.Checked = false;
            titleButton.Checked = false;
            documentButton.Checked = false;
            apiDataGrid.DataSource = null;
        }



        //private async Task getData()
        //{
        //    var dataFromApi = DataFromApi.GetInstance(true);
        //    domains = await dataFromApi.getApiDomains();
        //    titles = await dataFromApi.getTitles();
        //}


        private void domainButton_Checked(object sender, EventArgs e)
        {
            domainDropDownList.Enabled = false;
            apiDataGrid.DataSource = domains;
            RowsNumbering();
            //if (!domainButton.Checked) { return; }
            //var dataFromApi = new DataFromApi();
            //var domains = await dataFromApi.getApiDomains();
        }



        private void titleButton_Checked(object sender, EventArgs e)
        {
            domainDropDownList.Enabled = false;
            apiDataGrid.DataSource = titles;
            RowsNumbering();
            //docComboBox.Visible = false;
            //if (options == Options.Create)
            //{
            //    domainDropDownList.Enabled = false;
            //    dataBox.Visible = true;
            //}
            //dropDownTitleList();
        }
        private void documentButton_CheckedChanged(object sender, EventArgs e)
        {
            domainDropDownList.Items.Clear();
            var _dtoNamesLIst = domainRepo.GetNames();
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
            RowsNumbering();
        }

        private void RowsNumbering()
        {
            var column = apiDataGrid.Columns.GetFirstColumn(DataGridViewElementStates.Displayed);
            var rows = apiDataGrid.Rows;

            for (int i = 0; i < rows.Count; i++)
            {
                rows[i].Cells[0].Value = i + 1;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            Send();
            ReDraw();
        }


        private void Send()
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
                if (dataBox.Text == "")
                {
                    MessageBox.Show("Please insert a valid input");
                    return;
                }
                if (titleButton.Checked)
                {
                    _dto = new Title { Name = dataBox.Text };
                }
                if (domainButton.Checked)
                {
                    _dto = new Domain { Name = dataBox.Text };
                }
                if (documentButton.Checked)
                {
                    var domain = domains.Where(d => d.Name == domainDropDownList.Text).FirstOrDefault();
                    _dto = new Document { Name = dataBox.Text, DomainId = domain.Id };
                }
            }

            if (_dto != null)
            {
                domainRepo.sendData(_dto, options);
            }
            //if (titleButton.Checked)
            //{
            //    new DataToApi(new Title { Name = dataBox.Text }, options);
            //}
            //if (domainButton.Checked)
            //{
            //    if (action.Text == "Create")
            //    {
            //        new DataToApi(new Domain { Name = dataBox.Text }, options);
            //    }
            //    else if (action.Text == "Delete")
            //    {
            //        var domain = domains
            //            .Where(d => d.Name == domainDropDownList.Text).FirstOrDefault();
            //        new DataToApi(new Domain { Name = dataBox.Text, Id = domain.Id }, options);
            //    }
            //    //domains.Remove(domain);
            //}
            //if (documentButton.Checked)
            //{
            //    var domain = domainRepo.GetDomain(domainDropDownList.Text);
            //    var domainName = domainDropDownList.SelectedItem.ToString();
            //    if (action.Text == "Create")
            //    {
            //        new DataToApi(new Document { Name = dataBox.Text, DomainId = domain.Id }, options);
            //    }
            //    else if (action.Text == "Delete")
            //    {
            //        var doc = domain.Documents.Where(d => d.Name == docComboBox.Text).FirstOrDefault();
            //        new DataToApi(doc, options);
            //    }
            //}
            //ReDraw();
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
            RowsNumbering();
        }





    }
}
