namespace uspproject
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uspdbDataSet = new uspproject.uspdbDataSet();
            this.uspdbDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.brandsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.brandsTableAdapter = new uspproject.uspdbDataSetTableAdapters.BrandsTableAdapter();
            this.brandsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oSTableAdapter = new uspproject.uspdbDataSetTableAdapters.OSTableAdapter();
            this.phonesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.phonesTableAdapter = new uspproject.uspdbDataSetTableAdapters.PhonesTableAdapter();
            this.phonesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.phonesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.phonesBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspdbDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonesBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Връзка с БД:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // uspdbDataSet
            // 
            this.uspdbDataSet.DataSetName = "uspdbDataSet";
            this.uspdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uspdbDataSetBindingSource
            // 
            this.uspdbDataSetBindingSource.DataSource = this.uspdbDataSet;
            this.uspdbDataSetBindingSource.Position = 0;
            // 
            // brandsBindingSource
            // 
            this.brandsBindingSource.DataMember = "Brands";
            this.brandsBindingSource.DataSource = this.uspdbDataSetBindingSource;
            // 
            // brandsTableAdapter
            // 
            this.brandsTableAdapter.ClearBeforeFill = true;
            // 
            // brandsBindingSource1
            // 
            this.brandsBindingSource1.DataMember = "Brands";
            this.brandsBindingSource1.DataSource = this.uspdbDataSetBindingSource;
            // 
            // oSBindingSource
            // 
            this.oSBindingSource.DataMember = "OS";
            this.oSBindingSource.DataSource = this.uspdbDataSetBindingSource;
            // 
            // oSTableAdapter
            // 
            this.oSTableAdapter.ClearBeforeFill = true;
            // 
            // phonesBindingSource
            // 
            this.phonesBindingSource.DataMember = "Phones";
            this.phonesBindingSource.DataSource = this.uspdbDataSetBindingSource;
            // 
            // phonesTableAdapter
            // 
            this.phonesTableAdapter.ClearBeforeFill = true;
            // 
            // phonesBindingSource1
            // 
            this.phonesBindingSource1.DataMember = "Phones";
            this.phonesBindingSource1.DataSource = this.uspdbDataSetBindingSource;
            // 
            // phonesBindingSource2
            // 
            this.phonesBindingSource2.DataMember = "Phones";
            this.phonesBindingSource2.DataSource = this.uspdbDataSetBindingSource;
            // 
            // phonesBindingSource3
            // 
            this.phonesBindingSource3.DataMember = "Phones";
            this.phonesBindingSource3.DataSource = this.uspdbDataSet;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 308);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Система - търсене на моб. телефон";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspdbDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phonesBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource uspdbDataSetBindingSource;
        private uspdbDataSet uspdbDataSet;
        private System.Windows.Forms.BindingSource brandsBindingSource;
        private uspdbDataSetTableAdapters.BrandsTableAdapter brandsTableAdapter;
        private System.Windows.Forms.BindingSource brandsBindingSource1;
        private System.Windows.Forms.BindingSource oSBindingSource;
        private uspdbDataSetTableAdapters.OSTableAdapter oSTableAdapter;
        private System.Windows.Forms.BindingSource phonesBindingSource;
        private uspdbDataSetTableAdapters.PhonesTableAdapter phonesTableAdapter;
        private System.Windows.Forms.BindingSource phonesBindingSource1;
        private System.Windows.Forms.BindingSource phonesBindingSource2;
        private System.Windows.Forms.BindingSource phonesBindingSource3;

    }
}