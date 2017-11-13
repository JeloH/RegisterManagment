namespace Applictaion_Ozviat
{
    partial class Report6
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.db20DataSet1 = new Applictaion_Ozviat.db20DataSet1();
            this.PersonelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PersonelTableAdapter = new Applictaion_Ozviat.db20DataSet1TableAdapters.PersonelTableAdapter();
            this.serBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serTableAdapter = new Applictaion_Ozviat.db20DataSet1TableAdapters.serTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.db20DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Applictaion_Ozviat.bin.Debug.rpt.rpt1.Report_MoshakhasatFardi_ListKol.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(811, 728);
            this.reportViewer1.TabIndex = 1;
            // 
            // db20DataSet1
            // 
            this.db20DataSet1.DataSetName = "db20DataSet1";
            this.db20DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PersonelBindingSource
            // 
            this.PersonelBindingSource.DataMember = "Personel";
            this.PersonelBindingSource.DataSource = this.db20DataSet1;
            // 
            // PersonelTableAdapter
            // 
            this.PersonelTableAdapter.ClearBeforeFill = true;
            // 
            // serBindingSource
            // 
            this.serBindingSource.DataMember = "ser";
            this.serBindingSource.DataSource = this.db20DataSet1;
            // 
            // serTableAdapter
            // 
            this.serTableAdapter.ClearBeforeFill = true;
            // 
            // Report6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 728);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report6";
            this.Load += new System.EventHandler(this.Report6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db20DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PersonelBindingSource;
        private db20DataSet1 db20DataSet1;
        private System.Windows.Forms.BindingSource serBindingSource;
        private db20DataSet1TableAdapters.PersonelTableAdapter PersonelTableAdapter;
        private db20DataSet1TableAdapters.serTableAdapter serTableAdapter;
    }
}