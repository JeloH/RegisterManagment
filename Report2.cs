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
    public partial class Report2 : Form
    {

       
        public Report2(string AddressReportRdlc, string codeSql_tableName, string OnvaneGozaresh, string Tarikh)
        {
            InitializeComponent();

            SourceReport(AddressReportRdlc, codeSql_tableName, OnvaneGozaresh, Tarikh);
          
           


        }

        private void Report2_Load(object sender, EventArgs e)
        {

          this.reportViewer1.RefreshReport();

       //   Microsoft.Reporting.WinForms.ReportPageSettings pgSettings = reportViewer1.LocalReport.GetDefaultPageSettings();
       //   pgSettings.Margins.Top = 25;
       //   pgSettings.Margins.Bottom = 25;
     //     pgSettings.Margins.Left = 10;
        //  pgSettings.Margins.Right = 25;


      
        }



        public void SourceReport(string AddressReportRdlc, string codeSql_tableName,string OnvaneGozaresh,string Tarikh)
        {





            try
            {

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection conReport = new SqlConnection(str1);

                // "select * from Personel,ser "

                SqlCommand command = new SqlCommand(codeSql_tableName, conReport);


                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                ReportDataSource reportDataSource1 = new ReportDataSource();
                ReportDataSource reportDataSource2 = new ReportDataSource();
                ReportDataSource reportDataSource3 = new ReportDataSource();
                ReportDataSource reportDataSource4 = new ReportDataSource();
                ReportDataSource reportDataSource5 = new ReportDataSource();
                ReportDataSource reportDataSource6 = new ReportDataSource();

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = ds.Tables[0];

                reportDataSource2.Name = "DataSet2";
                reportDataSource2.Value = ds.Tables[0];

                reportDataSource3.Name = "DataSet3";
                reportDataSource3.Value = ds.Tables[0];

                reportDataSource4.Name = "DataSet4";
                reportDataSource4.Value = ds.Tables[0];

                reportDataSource5.Name = "DataSet5";
                reportDataSource5.Value = ds.Tables[0];

                reportDataSource6.Name = "DataSet6";
                reportDataSource6.Value = ds.Tables[0];



                reportViewer1.LocalReport.ReportPath = AddressReportRdlc;



                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Date_ReportParameter1", Tarikh));
                 reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("NameGozaresh_ReportParameter1",OnvaneGozaresh));


                reportViewer1.LocalReport.DataSources.Clear();




                reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

                reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
                reportViewer1.LocalReport.DataSources.Add(reportDataSource6);


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
