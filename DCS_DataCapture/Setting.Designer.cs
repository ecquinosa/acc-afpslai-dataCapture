namespace DCS_DataCapture
{
    partial class Setting
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
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCIF = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboBranchIssue = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMemTypeRegularAllwdYrs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMemTypeAssocAllwdYrs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardName_Length = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.Color.White;
            this.txtServer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.Location = new System.Drawing.Point(18, 21);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(333, 25);
            this.txtServer.TabIndex = 2;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(18, 54);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(138, 28);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Test Connection";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 383);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 38);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Location = new System.Drawing.Point(14, 279);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(367, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MIDDLE SERVER API";
            // 
            // txtCIF
            // 
            this.txtCIF.BackColor = System.Drawing.Color.White;
            this.txtCIF.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCIF.Location = new System.Drawing.Point(18, 81);
            this.txtCIF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCIF.Name = "txtCIF";
            this.txtCIF.Size = new System.Drawing.Size(66, 25);
            this.txtCIF.TabIndex = 1;
            this.txtCIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCIF_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCardName_Length);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboBranchIssue);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMemTypeRegularAllwdYrs);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMemTypeAssocAllwdYrs);
            this.groupBox2.Controls.Add(this.txtCIF);
            this.groupBox2.Location = new System.Drawing.Point(14, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(368, 271);
            this.groupBox2.TabIndex = 212;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(15, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 219;
            this.label7.Text = "BRANCH";
            // 
            // cboBranchIssue
            // 
            this.cboBranchIssue.BackColor = System.Drawing.Color.White;
            this.cboBranchIssue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranchIssue.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBranchIssue.FormattingEnabled = true;
            this.cboBranchIssue.Location = new System.Drawing.Point(101, 21);
            this.cboBranchIssue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboBranchIssue.Name = "cboBranchIssue";
            this.cboBranchIssue.Size = new System.Drawing.Size(250, 25);
            this.cboBranchIssue.TabIndex = 218;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(18, 164);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 18);
            this.label6.TabIndex = 217;
            this.label6.Text = "MEM.TYPE REGULAR ALLOWED YEARS";
            // 
            // txtMemTypeRegularAllwdYrs
            // 
            this.txtMemTypeRegularAllwdYrs.BackColor = System.Drawing.Color.White;
            this.txtMemTypeRegularAllwdYrs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemTypeRegularAllwdYrs.Location = new System.Drawing.Point(18, 182);
            this.txtMemTypeRegularAllwdYrs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMemTypeRegularAllwdYrs.Name = "txtMemTypeRegularAllwdYrs";
            this.txtMemTypeRegularAllwdYrs.Size = new System.Drawing.Size(64, 25);
            this.txtMemTypeRegularAllwdYrs.TabIndex = 216;
            this.txtMemTypeRegularAllwdYrs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemTypeRegularAllwdYrs_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(15, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 18);
            this.label5.TabIndex = 215;
            this.label5.Text = "MEM.TYPE ASSOCIATE ALLOWED YEARS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(15, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 18);
            this.label4.TabIndex = 214;
            this.label4.Text = "CIF TEXT LENGTH";
            // 
            // txtMemTypeAssocAllwdYrs
            // 
            this.txtMemTypeAssocAllwdYrs.BackColor = System.Drawing.Color.White;
            this.txtMemTypeAssocAllwdYrs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemTypeAssocAllwdYrs.Location = new System.Drawing.Point(18, 131);
            this.txtMemTypeAssocAllwdYrs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMemTypeAssocAllwdYrs.Name = "txtMemTypeAssocAllwdYrs";
            this.txtMemTypeAssocAllwdYrs.Size = new System.Drawing.Size(64, 25);
            this.txtMemTypeAssocAllwdYrs.TabIndex = 212;
            this.txtMemTypeAssocAllwdYrs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemTypeAssocAllwdYrs_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(18, 214);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 18);
            this.label1.TabIndex = 221;
            this.label1.Text = "CARD NAME LENGTH";
            // 
            // txtCardName_Length
            // 
            this.txtCardName_Length.BackColor = System.Drawing.Color.White;
            this.txtCardName_Length.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardName_Length.Location = new System.Drawing.Point(18, 232);
            this.txtCardName_Length.Margin = new System.Windows.Forms.Padding(4);
            this.txtCardName_Length.Name = "txtCardName_Length";
            this.txtCardName_Length.Size = new System.Drawing.Size(64, 25);
            this.txtCardName_Length.TabIndex = 220;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 431);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SETTING";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtCIF;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtMemTypeRegularAllwdYrs;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtMemTypeAssocAllwdYrs;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cboBranchIssue;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCardName_Length;
    }
}