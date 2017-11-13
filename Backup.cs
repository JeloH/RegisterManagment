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
    public partial class Backup : Form
    {

        cldbSql cmdsql=new cldbSql();

        public Backup()
        {
            InitializeComponent();
        }

   





        private void button3_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            DialogResult dlgRes = dlgSave.ShowDialog();
            
           try{


            if (dlgRes != DialogResult.Cancel)
            {

                textBox1.Text = dlgSave.FileName;
                
                label2.Text = "لطفا صبر کنید...";
                button3.Enabled = false;
                button4.Enabled = false; 



                
                backgroundWorker1.RunWorkerAsync();

            }

           
           }
                catch (Exception)
                {
 
                     MsgBox.ShowMessage(this.Handle.ToInt32(), "دیگر انتخابی برای حذف وجود ندارد ", "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }


        }


        public void CallDB2(string strCodeSql, string msg)
        {

      
            try
            {
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

               // groupBox2.Enabled = false;
              //  groupBox3.Enabled = false;

              //  textBox1.Text = "";
               // textBox2.Text = "";

            }
            catch (Exception er)
            {
               // MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                MessageBoxFrmEx.Show(er.Message.ToString(), "خطا ");


            }



        }
        private void button4_Click(object sender, EventArgs e)
        {
             this.Close();



              
        }

      
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

           

            CallDB2("BACKUP DATABASE db20 TO DISK = '" + textBox1.Text + ".bak" + "' WITH FORMAT", "عملیات پشتیبان گیری با موفقیت انجام شد");

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
         //   label2.BackColor = Color.Green;
            //  label2.Text = " عملیات گزارشگیی انجام شد ";
             label2.Text = "";
            
           
             button3.Enabled = true;
             button4.Enabled = true; 

        }




   

       
    }
}
