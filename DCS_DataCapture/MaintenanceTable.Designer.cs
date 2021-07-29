namespace DCS_DataCapture
{
    partial class MaintenanceTable
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
            this.btnSave = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblOldCode = new System.Windows.Forms.Label();
            this.txtParam3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(454, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 54);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 51;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(431, 346);
            this.grid.TabIndex = 1;
            // 
            // cboTable
            // 
            this.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Items.AddRange(new object[] {
            "Associate Type",
            "Branch",
            "Marital Status",
            "Membership Status",
            "Membership Type",
            "Printing Type",
            "Replace Reason",
            "System Role"});
            this.cboTable.Location = new System.Drawing.Point(12, 25);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(431, 24);
            this.cboTable.TabIndex = 2;
            this.cboTable.SelectedIndexChanged += new System.EventHandler(this.cboTable_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Table";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(454, 73);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(233, 23);
            this.txtID.TabIndex = 4;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(454, 126);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(233, 74);
            this.txtValue.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Value";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 406);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 34);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(88, 406);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 34);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(535, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(163, 406);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 34);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(449, 384);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(49, 16);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "Ready";
            this.lblResult.Visible = false;
            // 
            // lblOldCode
            // 
            this.lblOldCode.AutoSize = true;
            this.lblOldCode.Location = new System.Drawing.Point(449, 368);
            this.lblOldCode.Name = "lblOldCode";
            this.lblOldCode.Size = new System.Drawing.Size(64, 16);
            this.lblOldCode.TabIndex = 13;
            this.lblOldCode.Text = "OldCode";
            this.lblOldCode.Visible = false;
            // 
            // txtParam3
            // 
            this.txtParam3.Location = new System.Drawing.Point(454, 231);
            this.txtParam3.Name = "txtParam3";
            this.txtParam3.ReadOnly = true;
            this.txtParam3.Size = new System.Drawing.Size(233, 23);
            this.txtParam3.TabIndex = 14;
            this.txtParam3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Code";
            this.label4.Visible = false;
            // 
            // MaintenanceTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 449);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtParam3);
            this.Controls.Add(this.lblOldCode);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTable);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MaintenanceTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maintenance Table";
            this.Load += new System.EventHandler(this.MaintenanceTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblOldCode;
        private System.Windows.Forms.TextBox txtParam3;
        private System.Windows.Forms.Label label4;
    }
}