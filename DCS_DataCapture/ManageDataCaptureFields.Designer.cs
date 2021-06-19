namespace DCS_DataCapture
{
    partial class ManageDataCaptureFields
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDataCaptureFields));
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewField = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuiltIn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Mandatory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsSearchable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsReceiptViewable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsCapturedListViewable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldName,
            this.BuiltIn,
            this.Mandatory,
            this.IsSearchable,
            this.IsReceiptViewable,
            this.IsCapturedListViewable});
            this.grid.Location = new System.Drawing.Point(2, 2);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(660, 394);
            this.grid.TabIndex = 0;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(6, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 43);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewField
            // 
            this.btnNewField.Location = new System.Drawing.Point(519, 407);
            this.btnNewField.Name = "btnNewField";
            this.btnNewField.Size = new System.Drawing.Size(143, 32);
            this.btnNewField.TabIndex = 71;
            this.btnNewField.Text = "Manage Custom Field";
            this.btnNewField.UseVisualStyleBackColor = true;
            this.btnNewField.Visible = false;
            this.btnNewField.Click += new System.EventHandler(this.btnNewField_Click);
            // 
            // btnReset
            // 
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(99, 402);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 43);
            this.btnReset.TabIndex = 72;
            this.btnReset.Text = "Reset to Default";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FieldName
            // 
            this.FieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FieldName.DataPropertyName = "Field";
            this.FieldName.HeaderText = "Field Name";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            this.FieldName.Width = 84;
            // 
            // BuiltIn
            // 
            this.BuiltIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BuiltIn.DataPropertyName = "IsBuiltInControl";
            this.BuiltIn.HeaderText = "Built-In";
            this.BuiltIn.Name = "BuiltIn";
            this.BuiltIn.ReadOnly = true;
            this.BuiltIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BuiltIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BuiltIn.Width = 64;
            // 
            // Mandatory
            // 
            this.Mandatory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Mandatory.DataPropertyName = "IsMandatory";
            this.Mandatory.HeaderText = "Mandatory";
            this.Mandatory.Name = "Mandatory";
            this.Mandatory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mandatory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Mandatory.Width = 83;
            // 
            // IsSearchable
            // 
            this.IsSearchable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IsSearchable.DataPropertyName = "IsSearchable";
            this.IsSearchable.HeaderText = "Searchable";
            this.IsSearchable.Name = "IsSearchable";
            this.IsSearchable.ReadOnly = true;
            this.IsSearchable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSearchable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSearchable.Visible = false;
            this.IsSearchable.Width = 87;
            // 
            // IsReceiptViewable
            // 
            this.IsReceiptViewable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IsReceiptViewable.DataPropertyName = "IsReceiptViewable";
            this.IsReceiptViewable.HeaderText = "Receipt Viewable";
            this.IsReceiptViewable.Name = "IsReceiptViewable";
            this.IsReceiptViewable.ReadOnly = true;
            this.IsReceiptViewable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsReceiptViewable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsReceiptViewable.Visible = false;
            this.IsReceiptViewable.Width = 117;
            // 
            // IsCapturedListViewable
            // 
            this.IsCapturedListViewable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IsCapturedListViewable.DataPropertyName = "IsCapturedListViewable";
            this.IsCapturedListViewable.HeaderText = "Captured List Viewable";
            this.IsCapturedListViewable.Name = "IsCapturedListViewable";
            this.IsCapturedListViewable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCapturedListViewable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsCapturedListViewable.Visible = false;
            this.IsCapturedListViewable.Width = 145;
            // 
            // ManageDataCaptureFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 452);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnNewField);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageDataCaptureFields";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Fields";
            this.Load += new System.EventHandler(this.ManageDataCaptureFields_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewField;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BuiltIn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mandatory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSearchable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsReceiptViewable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCapturedListViewable;
    }
}