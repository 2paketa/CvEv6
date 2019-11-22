namespace CvEv6WinForm
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataBox = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.domainButton = new System.Windows.Forms.RadioButton();
            this.titleButton = new System.Windows.Forms.RadioButton();
            this.documentButton = new System.Windows.Forms.RadioButton();
            this.domainDropDownList = new System.Windows.Forms.ComboBox();
            this.action = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.apiDataGrid = new System.Windows.Forms.DataGridView();
            this.documentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.domainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.titleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.apiDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataBox
            // 
            this.dataBox.Location = new System.Drawing.Point(132, 64);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(237, 20);
            this.dataBox.TabIndex = 3;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(258, 297);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(140, 29);
            this.start.TabIndex = 4;
            this.start.Text = "Send";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // domainButton
            // 
            this.domainButton.AutoSize = true;
            this.domainButton.Location = new System.Drawing.Point(12, 40);
            this.domainButton.Name = "domainButton";
            this.domainButton.Size = new System.Drawing.Size(61, 17);
            this.domainButton.TabIndex = 5;
            this.domainButton.Text = "Domain";
            this.domainButton.UseVisualStyleBackColor = true;
            this.domainButton.CheckedChanged += new System.EventHandler(this.domainButton_Checked);
            // 
            // titleButton
            // 
            this.titleButton.AutoSize = true;
            this.titleButton.Location = new System.Drawing.Point(79, 40);
            this.titleButton.Name = "titleButton";
            this.titleButton.Size = new System.Drawing.Size(45, 17);
            this.titleButton.TabIndex = 7;
            this.titleButton.Text = "Title";
            this.titleButton.UseVisualStyleBackColor = true;
            this.titleButton.CheckedChanged += new System.EventHandler(this.titleButton_Checked);
            // 
            // documentButton
            // 
            this.documentButton.AutoSize = true;
            this.documentButton.Location = new System.Drawing.Point(130, 41);
            this.documentButton.Name = "documentButton";
            this.documentButton.Size = new System.Drawing.Size(74, 17);
            this.documentButton.TabIndex = 13;
            this.documentButton.Text = "Document";
            this.documentButton.UseVisualStyleBackColor = true;
            this.documentButton.CheckedChanged += new System.EventHandler(this.documentButton_CheckedChanged);
            // 
            // domainDropDownList
            // 
            this.domainDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.domainDropDownList.FormattingEnabled = true;
            this.domainDropDownList.Location = new System.Drawing.Point(12, 63);
            this.domainDropDownList.Name = "domainDropDownList";
            this.domainDropDownList.Size = new System.Drawing.Size(114, 21);
            this.domainDropDownList.TabIndex = 14;
            this.domainDropDownList.SelectedIndexChanged += new System.EventHandler(this.domainDropDownList_SelectedIndexChanged);
            // 
            // action
            // 
            this.action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.action.FormattingEnabled = true;
            this.action.Items.AddRange(new object[] {
            "Create",
            "Edit",
            "Delete",
            "Patch"});
            this.action.Location = new System.Drawing.Point(87, 9);
            this.action.Name = "action";
            this.action.Size = new System.Drawing.Size(121, 21);
            this.action.TabIndex = 15;
            this.action.SelectedIndexChanged += new System.EventHandler(this.action_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Select action:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(104, 297);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Maximum = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(142, 29);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 17;
            this.progressBar1.Visible = false;
            // 
            // apiDataGrid
            // 
            this.apiDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apiDataGrid.Location = new System.Drawing.Point(12, 117);
            this.apiDataGrid.Name = "apiDataGrid";
            this.apiDataGrid.Size = new System.Drawing.Size(354, 150);
            this.apiDataGrid.TabIndex = 20;
            // 
            // documentsBindingSource
            // 
            this.documentsBindingSource.DataMember = "Documents";
            this.documentsBindingSource.DataSource = this.domainBindingSource;
            // 
            // domainBindingSource
            // 
            this.domainBindingSource.DataSource = typeof(CvEv6WinForm.Domain);
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataSource = typeof(CvEv6WinForm.Document);
            // 
            // titleBindingSource
            // 
            this.titleBindingSource.DataSource = typeof(CvEv6WinForm.Title);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 338);
            this.Controls.Add(this.apiDataGrid);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.action);
            this.Controls.Add(this.domainDropDownList);
            this.Controls.Add(this.documentButton);
            this.Controls.Add(this.titleButton);
            this.Controls.Add(this.domainButton);
            this.Controls.Add(this.start);
            this.Controls.Add(this.dataBox);
            this.Name = "Form2";
            this.Text = "Add to API";
            ((System.ComponentModel.ISupportInitialize)(this.apiDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dataBox;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.RadioButton domainButton;
        private System.Windows.Forms.RadioButton titleButton;
        private System.Windows.Forms.RadioButton documentButton;
        private System.Windows.Forms.ComboBox domainDropDownList;
        private System.Windows.Forms.ComboBox action;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private System.Windows.Forms.DataGridView apiDataGrid;
        private System.Windows.Forms.BindingSource titleBindingSource;
        private System.Windows.Forms.BindingSource domainBindingSource;
        private System.Windows.Forms.BindingSource documentsBindingSource;
    }
}