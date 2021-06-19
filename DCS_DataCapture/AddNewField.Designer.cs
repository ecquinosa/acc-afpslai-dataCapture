namespace DCS_DataCapture
{
    partial class AddNewField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewField));
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.txtFieldID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMandatory = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aDDNEWFIELDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dELETEFIELDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboControlType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(397, 151);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 25);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Field Label";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(466, 41);
            this.txtLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(163, 20);
            this.txtLabel.TabIndex = 1;
            this.txtLabel.TextChanged += new System.EventHandler(this.txtLabel_TextChanged);
            // 
            // txtFieldID
            // 
            this.txtFieldID.Location = new System.Drawing.Point(466, 69);
            this.txtFieldID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFieldID.Name = "txtFieldID";
            this.txtFieldID.ReadOnly = true;
            this.txtFieldID.Size = new System.Drawing.Size(163, 20);
            this.txtFieldID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Field ID";
            // 
            // chkMandatory
            // 
            this.chkMandatory.AutoSize = true;
            this.chkMandatory.Location = new System.Drawing.Point(466, 127);
            this.chkMandatory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.Size = new System.Drawing.Size(100, 18);
            this.chkMandatory.TabIndex = 2;
            this.chkMandatory.Text = "Mandatory field";
            this.chkMandatory.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(478, 151);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(0, 29);
            this.grid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(390, 284);
            this.grid.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 7F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDNEWFIELDToolStripMenuItem,
            this.dELETEFIELDToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aDDNEWFIELDToolStripMenuItem
            // 
            this.aDDNEWFIELDToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aDDNEWFIELDToolStripMenuItem.Image")));
            this.aDDNEWFIELDToolStripMenuItem.Name = "aDDNEWFIELDToolStripMenuItem";
            this.aDDNEWFIELDToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.aDDNEWFIELDToolStripMenuItem.Text = "ADD NEW FIELD";
            this.aDDNEWFIELDToolStripMenuItem.Visible = false;
            this.aDDNEWFIELDToolStripMenuItem.Click += new System.EventHandler(this.aDDNEWFIELDToolStripMenuItem_Click);
            // 
            // dELETEFIELDToolStripMenuItem
            // 
            this.dELETEFIELDToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dELETEFIELDToolStripMenuItem.Image")));
            this.dELETEFIELDToolStripMenuItem.Name = "dELETEFIELDToolStripMenuItem";
            this.dELETEFIELDToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.dELETEFIELDToolStripMenuItem.Text = "DELETE FIELD";
            this.dELETEFIELDToolStripMenuItem.Click += new System.EventHandler(this.dELETEFIELDToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(110, 20);
            this.toolStripMenuItem2.Text = "MOVE ROW UP";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 20);
            this.toolStripMenuItem1.Text = "MOVE ROW DOWN";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(394, 181);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 14);
            this.lblStatus.TabIndex = 9;
            // 
            // cboControlType
            // 
            this.cboControlType.FormattingEnabled = true;
            this.cboControlType.Items.AddRange(new object[] {
            "TextBox",
            "MaskedTextBox",
            "CheckBox",
            "RadioButton"});
            this.cboControlType.Location = new System.Drawing.Point(466, 97);
            this.cboControlType.Name = "cboControlType";
            this.cboControlType.Size = new System.Drawing.Size(163, 22);
            this.cboControlType.TabIndex = 10;
            this.cboControlType.SelectedIndexChanged += new System.EventHandler(this.cboControlType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Control Type";
            // 
            // AddNewField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 314);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboControlType);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkMandatory);
            this.Controls.Add(this.txtFieldID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "AddNewField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Fields";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewField_FormClosing);
            this.Load += new System.EventHandler(this.AddNewField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.TextBox txtFieldID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMandatory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aDDNEWFIELDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dELETEFIELDToolStripMenuItem;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboControlType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}