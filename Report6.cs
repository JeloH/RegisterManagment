using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Applictaion_Ozviat
{
    public partial class Report6 : Form
    {
        public Report6(string AddressReportRdlc, string codeSql_tableName )

        {
            InitializeComponent();


            SourceReport(AddressReportRdlc, codeSql_tableName);
    
        }

        private void Report6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db20DataSet1.Personel' table. You can move, or remove it, as needed.
            this.PersonelTableAdapter.Fill(this.db20DataSet1.Personel);
            // TODO: This line of code loads data into the 'db20DataSet1.ser' table. You can move, or remove it, as needed.
            this.serTableAdapter.Fill(this.db20DataSet1.ser);

            this.reportViewer1.RefreshReport();
     
        }



        public void SourceReport(string AddressReportRdlc, string codeSql_tableName )
     
        {

            this.reportViewer1.RefreshReport();



            try
            {

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection conReport = new SqlConnection(str1);



                SqlCommand command = new SqlCommand(codeSql_tableName, conReport);


                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                ReportDataSource reportDataSource1 = new ReportDataSource();
                //   ReportDataSource reportDataSource2 = new ReportDataSource();
                //  ReportDataSource reportDataSource3 = new ReportDataSource();

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = ds.Tables[0];

                //    reportDataSource2.Name = "DataSet2";
                //    reportDataSource2.Value = ds.Tables[0];

                //    reportDataSource3.Name = "DataSet3";
                //     reportDataSource3.Value = ds.Tables[0];




                reportViewer1.LocalReport.ReportPath = AddressReportRdlc;


                // reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ColorText_ReportParameter1", NameColorText));
                // reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ColorBackground_ReportParameter2", NameBackgroundColor));
                //reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("HiddenLogo_ReportParameter3","True"));




                reportViewer1.LocalReport.DataSources.Clear();




                reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                //    reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
                //    reportViewer1.LocalReport.DataSources.Add(reportDataSource3);


                //  reportViewer1.DocumentMapCollapsed = true;


                reportViewer1.Show();

            }
            catch (Exception ex)
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }


        }
 
    


    }
}
