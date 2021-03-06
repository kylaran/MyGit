﻿namespace ShopTrade
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ContextMenu = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoDay = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.EntProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.EditProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.DelProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.краскиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьЦенниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переучётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articuleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DBSDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBSDataSet1 = new ShopTrade.DBSDataSet1();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.nameD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basketsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.basketsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter = new ShopTrade.DBSDataSet1TableAdapters.ProductsTableAdapter();
            this.basketsTableAdapter = new ShopTrade.DBSDataSet1TableAdapters.BasketsTableAdapter();
            this.productsTableAdapter1 = new ShopTrade.DBSDataSet1TableAdapters.ProductsTableAdapter();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменаПароляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.резервнаяКопияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаПоследнихБазToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBSDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBSDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basketsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basketsBindingSource)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поиск:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(76, 250);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(694, 26);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyPress);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(15, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 47);
            this.button2.TabIndex = 5;
            this.button2.Text = "Оплата";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Edit,
            this.Help,
            this.печатьToolStripMenuItem});
            this.ContextMenu.Location = new System.Drawing.Point(0, 0);
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(779, 24);
            this.ContextMenu.TabIndex = 7;
            this.ContextMenu.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoDay,
            this.Exit});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(48, 20);
            this.File.Text = "Файл";
            // 
            // InfoDay
            // 
            this.InfoDay.Name = "InfoDay";
            this.InfoDay.Size = new System.Drawing.Size(180, 22);
            this.InfoDay.Text = "Итоги";
            this.InfoDay.Click += new System.EventHandler(this.InfoDay_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(180, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Edit
            // 
            this.Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EntProduct,
            this.EditProduct,
            this.DelProduct,
            this.краскиToolStripMenuItem});
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(51, 20);
            this.Edit.Text = "Товар";
            // 
            // EntProduct
            // 
            this.EntProduct.Name = "EntProduct";
            this.EntProduct.Size = new System.Drawing.Size(180, 22);
            this.EntProduct.Text = "Ввод";
            this.EntProduct.Click += new System.EventHandler(this.EntProduct_Click);
            // 
            // EditProduct
            // 
            this.EditProduct.Name = "EditProduct";
            this.EditProduct.Size = new System.Drawing.Size(180, 22);
            this.EditProduct.Text = "Редактирование";
            this.EditProduct.Click += new System.EventHandler(this.EditProduct_Click);
            // 
            // DelProduct
            // 
            this.DelProduct.Name = "DelProduct";
            this.DelProduct.Size = new System.Drawing.Size(180, 22);
            this.DelProduct.Text = "Удаление";
            this.DelProduct.Click += new System.EventHandler(this.DelProduct_Click);
            // 
            // краскиToolStripMenuItem
            // 
            this.краскиToolStripMenuItem.Name = "краскиToolStripMenuItem";
            this.краскиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.краскиToolStripMenuItem.Text = "Краски";
            this.краскиToolStripMenuItem.Click += new System.EventHandler(this.КраскиToolStripMenuItem_Click);
            // 
            // Help
            // 
            this.Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(65, 20);
            this.Help.Text = "Справка";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сменаПароляToolStripMenuItem,
            this.резервнаяКопияToolStripMenuItem,
            this.загрузкаПоследнихБазToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.ОПрограммеToolStripMenuItem_Click);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьЦенниковToolStripMenuItem,
            this.переучётToolStripMenuItem});
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.печатьToolStripMenuItem.Text = "Печать";
            // 
            // печатьЦенниковToolStripMenuItem
            // 
            this.печатьЦенниковToolStripMenuItem.Name = "печатьЦенниковToolStripMenuItem";
            this.печатьЦенниковToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.печатьЦенниковToolStripMenuItem.Text = "Печать ценников";
            this.печатьЦенниковToolStripMenuItem.Click += new System.EventHandler(this.ПечатьЦенниковToolStripMenuItem_Click);
            // 
            // переучётToolStripMenuItem
            // 
            this.переучётToolStripMenuItem.Name = "переучётToolStripMenuItem";
            this.переучётToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.переучётToolStripMenuItem.Text = "Переучёт";
            this.переучётToolStripMenuItem.Click += new System.EventHandler(this.ПереучётToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(334, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "КОРЗИНА";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 26);
            this.label3.TabIndex = 12;
            this.label3.Text = "К ОПЛАТЕ: 0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.nameDataGridViewTextBoxColumn,
            this.articuleDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productsBindingSource1;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(19, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(751, 214);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_CellMouseDown);
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 106;
            // 
            // articuleDataGridViewTextBoxColumn
            // 
            this.articuleDataGridViewTextBoxColumn.DataPropertyName = "Articule";
            this.articuleDataGridViewTextBoxColumn.HeaderText = "Артикул";
            this.articuleDataGridViewTextBoxColumn.Name = "articuleDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Страна производитель";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // productsBindingSource1
            // 
            this.productsBindingSource1.DataMember = "Products";
            this.productsBindingSource1.DataSource = this.DBSDataSet1BindingSource;
            // 
            // DBSDataSet1BindingSource
            // 
            this.DBSDataSet1BindingSource.DataSource = this.DBSDataSet1;
            this.DBSDataSet1BindingSource.Position = 0;
            // 
            // DBSDataSet1
            // 
            this.DBSDataSet1.DataSetName = "DBSDataSet1";
            this.DBSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameD2,
            this.countryD2,
            this.quantityD2,
            this.priceD2});
            this.dataGridView2.DataSource = this.basketsBindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(15, 348);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(755, 150);
            this.dataGridView2.TabIndex = 15;
            // 
            // nameD2
            // 
            this.nameD2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameD2.DataPropertyName = "Name";
            this.nameD2.HeaderText = "Наименование";
            this.nameD2.Name = "nameD2";
            this.nameD2.Width = 106;
            // 
            // countryD2
            // 
            this.countryD2.DataPropertyName = "Country";
            this.countryD2.HeaderText = "Страна производитель";
            this.countryD2.Name = "countryD2";
            // 
            // quantityD2
            // 
            this.quantityD2.DataPropertyName = "Quantity";
            this.quantityD2.HeaderText = "Количество";
            this.quantityD2.Name = "quantityD2";
            // 
            // priceD2
            // 
            this.priceD2.DataPropertyName = "Price";
            this.priceD2.HeaderText = "Цена";
            this.priceD2.Name = "priceD2";
            // 
            // basketsBindingSource1
            // 
            this.basketsBindingSource1.DataMember = "Baskets";
            this.basketsBindingSource1.DataSource = this.DBSDataSet1BindingSource;
            // 
            // basketsBindingSource
            // 
            this.basketsBindingSource.DataMember = "Baskets";
            this.basketsBindingSource.DataSource = this.DBSDataSet1BindingSource;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // basketsTableAdapter
            // 
            this.basketsTableAdapter.ClearBeforeFill = true;
            // 
            // productsTableAdapter1
            // 
            this.productsTableAdapter1.ClearBeforeFill = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(536, 278);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(234, 32);
            this.button3.TabIndex = 17;
            this.button3.Text = "Добавить в корзину";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(536, 311);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(234, 34);
            this.button4.TabIndex = 18;
            this.button4.Text = "Удалить из корзины";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(155, 48);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.EditProduct_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DelProduct_Click);
            // 
            // сменаПароляToolStripMenuItem
            // 
            this.сменаПароляToolStripMenuItem.Name = "сменаПароляToolStripMenuItem";
            this.сменаПароляToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.сменаПароляToolStripMenuItem.Text = "Смена пароля";
            this.сменаПароляToolStripMenuItem.Click += new System.EventHandler(this.НастройкиToolStripMenuItem_Click);
            // 
            // резервнаяКопияToolStripMenuItem
            // 
            this.резервнаяКопияToolStripMenuItem.Name = "резервнаяКопияToolStripMenuItem";
            this.резервнаяКопияToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.резервнаяКопияToolStripMenuItem.Text = "Резервная копия";
            this.резервнаяКопияToolStripMenuItem.Click += new System.EventHandler(this.резервнаяКопияToolStripMenuItem_Click);
            // 
            // загрузкаПоследнихБазToolStripMenuItem
            // 
            this.загрузкаПоследнихБазToolStripMenuItem.Name = "загрузкаПоследнихБазToolStripMenuItem";
            this.загрузкаПоследнихБазToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.загрузкаПоследнихБазToolStripMenuItem.Text = "Загрузка последних баз";
            this.загрузкаПоследнихБазToolStripMenuItem.Click += new System.EventHandler(this.загрузкаПоследнихБазToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 550);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContextMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(750, 589);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Магазин";
            this.Activated += new System.EventHandler(this.MainMenu_Activated);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMenu_KeyDown);
            this.Resize += new System.EventHandler(this.MainMenu_Resize);
            this.ContextMenu.ResumeLayout(false);
            this.ContextMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBSDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basketsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basketsBindingSource)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem InfoDay;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem EntProduct;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStripMenuItem EditProduct;
        private System.Windows.Forms.ToolStripMenuItem DelProduct;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource DBSDataSet1BindingSource;
        private DBSDataSet1 DBSDataSet1;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private DBSDataSet1TableAdapters.ProductsTableAdapter productsTableAdapter;
        private System.Windows.Forms.BindingSource basketsBindingSource;
        private DBSDataSet1TableAdapters.BasketsTableAdapter basketsTableAdapter;
        private System.Windows.Forms.BindingSource productsBindingSource1;
        private DBSDataSet1TableAdapters.ProductsTableAdapter productsTableAdapter1;
        private System.Windows.Forms.BindingSource basketsBindingSource1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articuleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameD2;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryD2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityD2;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceD2;
        private System.Windows.Forms.ToolStripMenuItem краскиToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьЦенниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переучётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменаПароляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem резервнаяКопияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкаПоследнихБазToolStripMenuItem;
    }
}

