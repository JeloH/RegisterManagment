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

    
    public partial class Report : Form
    {





        public Report(string NameReportRdlc, string codeSql_tableName)
        {
            InitializeComponent();

            comboBox4.MaxLength = 2;
            comboBox8.MaxLength = 2;
            textBox10.MaxLength = 4;


            SourceReport(NameReportRdlc, codeSql_tableName);

        }

        private void Report_Load(object sender, EventArgs e)
        {
            Disable_RightClick_Menu_Field();
        }



        public void SourceReport(string NameReportRdlc, string codeSql_tableName)
        {



            try{
 
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
             //   ReportDataSource reportDataSource3 = new ReportDataSource();
              //  ReportDataSource reportDataSource4 = new ReportDataSource();
             //   ReportDataSource reportDataSource5 = new ReportDataSource();
               // ReportDataSource reportDataSource6 = new ReportDataSource();

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = ds.Tables[0];

               reportDataSource2.Name = "DataSet2";
               reportDataSource2.Value = ds.Tables[0];

              //  reportDataSource3.Name = "DataSet3";
              //  reportDataSource3.Value = ds.Tables[0];

               // reportDataSource4.Name = "DataSet4";
              //  reportDataSource4.Value = ds.Tables[0];

              //  reportDataSource5.Name = "DataSet5";
              //  reportDataSource5.Value = ds.Tables[0];

              //  reportDataSource6.Name = "DataSet6";
              //  reportDataSource6.Value = ds.Tables[0];



                reportViewer1.LocalReport.ReportPath = NameReportRdlc;



                reportViewer1.LocalReport.DataSources.Clear();




                reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

                reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
              //  reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
              //  reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
             //   reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
              //  reportViewer1.LocalReport.DataSources.Add(reportDataSource6);


                //  reportViewer1.DocumentMapCollapsed = true;


            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{

            BarrasiTarikh();
           

             if (comboBox4.Text == "")  {
                 MsgBox.ShowMessage(this.Handle.ToInt32(), " روز تاریخ گزارش را وارد کنيد", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }

             else if (comboBox8.Text == "")
             {
                 MsgBox.ShowMessage(this.Handle.ToInt32(), " ماه تاریخ گزارش را وارد کنيد", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
             }
            
             else if (textBox10.Text == "") 
             {
       
                 MsgBox.ShowMessage(this.Handle.ToInt32(), " سال تاریخ گزارش را وارد کنيد", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
              }

            else
            {
                string str_rouz = "", str_mah = "", str_sal = "";

                str_rouz = comboBox4.Text;
                str_mah = comboBox8.Text;
                str_sal = textBox10.Text;

                string Tarikh = str_sal + "/" + str_mah + "/" + str_rouz;

                reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Date_ReportParameter1", Tarikh));

                reportViewer1.RefreshReport();

                reportViewer1.Show();
                groupBox1.Visible = false;
                reportViewer1.Dock = DockStyle.Fill;

                 }



            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }


        public void BarrasiTarikh() {
            //برای اینکه عدد بزرگتر از 31 روز وارد نشود..و.و

            if (comboBox4.Text != "")
            {
                int num1 = int.Parse(comboBox4.Text);

                if (num1 >= 32 || comboBox4.Text == "00" || comboBox4.Text == "0")
                {


 
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ گزارش را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                    comboBox4.Text = "";

                }

            }






            //برای اینکه عدد بزرگتر از 12 ماه وارد نشودو  ..و.و



             if (comboBox8.Text != "")
            {
                int num2 = int.Parse(comboBox8.Text);

                if (num2 >= 13 || comboBox8.Text == "00" || comboBox8.Text == "0")
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ گزارش را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                    comboBox8.Text = "";

                }
            }



             if (textBox10.Text != "")
            {
                int num3 = int.Parse(textBox10.Text);
                if (num3 <= 999 || textBox10.Text == "0000" || textBox10.Text == "000" || textBox10.Text == "00" || textBox10.Text == "0")
                {


                    MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ گزارش را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    textBox10.Text = "";

                }

            }
        
        
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }

        }

        private void comboBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }

        }




        public void Disable_RightClick_Menu_Field()
        {


            // غیر فعال کردن راست کلیک

   
            comboBox4.ContextMenu = new ContextMenu();
         
            comboBox8.ContextMenu = new ContextMenu();
 

            textBox10.ContextMenu = new ContextMenu();
      



        }




    }

}