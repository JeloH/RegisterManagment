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
    public partial class Report5 : Form
    {


       

        public Report5(string AddressReportRdlc, string codeSql_tableName, string OnvaneGozaresh, string Tarikh, string[] SelectNameField, string Hidden_Image_True_OR_False)
        {
            InitializeComponent();


            SourceReport(AddressReportRdlc, codeSql_tableName, OnvaneGozaresh, Tarikh, SelectNameField, Hidden_Image_True_OR_False);

        }

        private void Report5_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }



        public void SourceReport(string AddressReportRdlc, string codeSql_tableName, string OnvaneGozaresh, string Tarikh ,string[] SelectNameField, string Hidden_Image_True_OR_False)
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
           
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = ds.Tables[0];
 

                reportViewer1.LocalReport.ReportPath = AddressReportRdlc;


                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("NameGozaresh_ReportParameter1", OnvaneGozaresh));


                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Date_ReportParameter1", Tarikh));

                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Hidden_Image_ReportParameter1", Hidden_Image_True_OR_False));


                 
                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column2", SelectNameField[0]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column3", SelectNameField[1]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column4", SelectNameField[2]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column5", SelectNameField[3]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column6", SelectNameField[4]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column7", SelectNameField[5]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column8", SelectNameField[6]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column9", SelectNameField[7]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column10", SelectNameField[8]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column11", SelectNameField[9]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column12", SelectNameField[10]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column13", SelectNameField[11]));

                  reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("R_Parameter_Column14", SelectNameField[12]));


 


                reportViewer1.LocalReport.DataSources.Clear();




                reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
 
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
