namespace ShopTrade
{
    partial class DayResults
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dBSDataSet1 = new ShopTrade.DBSDataSet1();
            this.basketsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basketsTableAdapter = new ShopTrade.DBSDataSet1TableAdapters.BasketsTableAdapter();
            this.BuyersID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basketsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuyersID,
            this.DateTrade});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 425);
            this.dataGridView1.TabIndex = 0;
            // 
            // dBSDataSet1
            // 
            this.dBSDataSet1.DataSetName = "DBSDataSet1";
            this.dBSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // basketsBindingSource
            // 
            this.basketsBindingSource.DataMember = "Baskets";
            this.basketsBindingSource.DataSource = this.dBSDataSet1;
            // 
            // basketsTableAdapter
            // 
            this.basketsTableAdapter.ClearBeforeFill = true;
            // 
            // BuyersID
            // 
            this.BuyersID.DataPropertyName = "ListID";
            this.BuyersID.HeaderText = "способ продажи";
            this.BuyersID.Name = "BuyersID";
            this.BuyersID.ReadOnly = true;
            // 
            // DateTrade
            // 
            this.DateTrade.DataPropertyName = "ListID";
            this.DateTrade.HeaderText = "Дата продажи";
            this.DateTrade.Name = "DateTrade";
            this.DateTrade.ReadOnly = true;
            // 
            // DayResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DayResults";
            this.Text = "DayResults";
            this.Load += new System.EventHandler(this.DayResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basketsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DBSDataSet1 dBSDataSet1;
        private System.Windows.Forms.BindingSource basketsBindingSource;
        private DBSDataSet1TableAdapters.BasketsTableAdapter basketsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyersID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTrade;
    }
}