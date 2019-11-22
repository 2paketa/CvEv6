namespace CvEv6WinForm
{
    partial class Form1
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
            this.sendToAPI = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.random = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.bulletPoints = new System.Windows.Forms.RadioButton();
            this.commaSeparated = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numericYearExp = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericDoc = new System.Windows.Forms.NumericUpDown();
            this.finalText = new System.Windows.Forms.TextBox();
            this.getText = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedDomains = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericYearExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // sendToAPI
            // 
            this.sendToAPI.Location = new System.Drawing.Point(325, 89);
            this.sendToAPI.Name = "sendToAPI";
            this.sendToAPI.Size = new System.Drawing.Size(90, 23);
            this.sendToAPI.TabIndex = 47;
            this.sendToAPI.Text = "Send to API";
            this.sendToAPI.UseVisualStyleBackColor = true;
            this.sendToAPI.Click += new System.EventHandler(this.sendToAPI_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 33);
            this.button1.TabIndex = 46;
            this.button1.Text = "Open library";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "label5";
            // 
            // random
            // 
            this.random.AutoSize = true;
            this.random.Location = new System.Drawing.Point(221, 117);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(65, 17);
            this.random.TabIndex = 44;
            this.random.TabStop = true;
            this.random.Text = "Random";
            this.random.UseVisualStyleBackColor = true;
            this.random.CheckedChanged += new System.EventHandler(this.random_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Select formatting";
            // 
            // bulletPoints
            // 
            this.bulletPoints.AutoSize = true;
            this.bulletPoints.Location = new System.Drawing.Point(133, 117);
            this.bulletPoints.Name = "bulletPoints";
            this.bulletPoints.Size = new System.Drawing.Size(82, 17);
            this.bulletPoints.TabIndex = 42;
            this.bulletPoints.TabStop = true;
            this.bulletPoints.Text = "Bullet points";
            this.bulletPoints.UseVisualStyleBackColor = true;
            // 
            // commaSeparated
            // 
            this.commaSeparated.AutoSize = true;
            this.commaSeparated.Location = new System.Drawing.Point(12, 117);
            this.commaSeparated.Name = "commaSeparated";
            this.commaSeparated.Size = new System.Drawing.Size(110, 17);
            this.commaSeparated.TabIndex = 41;
            this.commaSeparated.TabStop = true;
            this.commaSeparated.Text = "Comma separated";
            this.commaSeparated.UseVisualStyleBackColor = true;
            this.commaSeparated.CheckedChanged += new System.EventHandler(this.commaSeparated_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Years of experience";
            // 
            // numericYearExp
            // 
            this.numericYearExp.Location = new System.Drawing.Point(171, 78);
            this.numericYearExp.Name = "numericYearExp";
            this.numericYearExp.Size = new System.Drawing.Size(99, 20);
            this.numericYearExp.TabIndex = 39;
            this.numericYearExp.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Number of random documents";
            // 
            // numericDoc
            // 
            this.numericDoc.Location = new System.Drawing.Point(12, 78);
            this.numericDoc.Name = "numericDoc";
            this.numericDoc.Size = new System.Drawing.Size(98, 20);
            this.numericDoc.TabIndex = 37;
            this.numericDoc.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // finalText
            // 
            this.finalText.Location = new System.Drawing.Point(12, 140);
            this.finalText.Multiline = true;
            this.finalText.Name = "finalText";
            this.finalText.Size = new System.Drawing.Size(406, 271);
            this.finalText.TabIndex = 36;
            // 
            // getText
            // 
            this.getText.Location = new System.Drawing.Point(325, 23);
            this.getText.Name = "getText";
            this.getText.Size = new System.Drawing.Size(93, 20);
            this.getText.TabIndex = 35;
            this.getText.Text = "Get Text";
            this.getText.UseVisualStyleBackColor = true;
            this.getText.Click += new System.EventHandler(this.getText_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Insert domain(s)";
            // 
            // selectedDomains
            // 
            this.selectedDomains.Location = new System.Drawing.Point(12, 23);
            this.selectedDomains.Name = "selectedDomains";
            this.selectedDomains.Size = new System.Drawing.Size(305, 20);
            this.selectedDomains.TabIndex = 33;
            this.selectedDomains.TextChanged += new System.EventHandler(this.selectedDomains_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 425);
            this.Controls.Add(this.sendToAPI);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.random);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bulletPoints);
            this.Controls.Add(this.commaSeparated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericYearExp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericDoc);
            this.Controls.Add(this.finalText);
            this.Controls.Add(this.getText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedDomains);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericYearExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendToAPI;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton random;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton bulletPoints;
        private System.Windows.Forms.RadioButton commaSeparated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericYearExp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericDoc;
        private System.Windows.Forms.TextBox finalText;
        private System.Windows.Forms.Button getText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox selectedDomains;
    }
}

