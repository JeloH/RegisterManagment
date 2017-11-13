using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using System.Configuration;

namespace Applictaion_Ozviat
{
    public partial class RestoreDB : Form
    {

        cldbSql cmdsql = new cldbSql();

        public RestoreDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{

            string strFileName = string.Empty;
            openFileDialog1.Filter = @"SQL Backup files (*.BAK) |*.BAK";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Restore SQL File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;


             
            }

            if (textBox1.Text != "") {

                button3.Enabled = true;

            }


            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
        
            try{


            string path = "";
            openFileDialog1.Filter = @" (*.mdf) |*.mdf";
            //openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Restore SQL File";
          
           // openFileDialog1.FileName = "Filename will be ignored";
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.ShowReadOnly = false;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.ValidateNames = false;

            //  openFileDialog1.Filter = "File without extension (*.)|*.";
            //   openFileDialog1.Filter = "NCF files (*.ncf)|*.ncf|All files (*.*)|*.*|No Extensions (*.)|*."; 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
 
                path = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
          
            }

            textBox2.Text = path;//should contain the folder and a dummy filename

            if (textBox2.Text != "") {

                button1.Enabled = true;
               // textBox1.Enabled = true;
            }




            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }



            
            }




        public  void CallDB2(string strCodeSql ,string msg)
        {


            try{


            SqlConnection con = new SqlConnection();

           
                //  string s3 = "Data Source=.;Initial Catalog=db2;Integrated Security=true;";
                //string s3 = @"provider=microsoft.jet.oledb.4.0;" + @"data source=..\\Debug\\db\\db2.mdb";

                
                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                con = new SqlConnection(str1);



                SqlCommand cmd = new SqlCommand(strCodeSql, con);
                con.Open();
               

                cmd.ExecuteNonQuery();

                MessageBoxFrmEx.Show(msg);

                con.Close();

              
            }
            catch (Exception er)
            {

                MessageBoxFrmEx.Show(er.Message.ToString(), "خطا ");


            }
 
                

            
        }

 

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" & textBox2.Text != "")
            {

                
                  label2.Text = "لطفا صبر کنید...";
        
                button1.Enabled = false;

                button2.Enabled = false;

                button3.Enabled = false;
                
                button4.Enabled = false;

                
                
                backgroundWorker1.RunWorkerAsync();

                
              
            

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CallDB2("use master  RESTORE DATABASE [db20] FROM DISK = N'" + textBox1.Text + "' WITH FILE = 1, MOVE N'db20' TO N'" + textBox2.Text + "\\db20" + ".mdf" + "', MOVE N'db20_Log' TO N'" + textBox2.Text + "\\db20_log" + ".ldf" + "', KEEP_REPLICATION, NOUNLOAD, REPLACE, STATS = 10 "," عملیات بازیاب با موفقیت انجام شد");
            
                 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";

            button2.Enabled = true;

            button4.Enabled = true;

        }
 

        }

    }
