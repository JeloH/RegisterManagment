using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Applictaion_Ozviat
{
    public partial class Form_Email_Send_MultiSelect : Form
    {

        cldbSql cmdsql = new cldbSql();

        Tanzimat_email tem2 = new Tanzimat_email();

        datetime dom = new datetime();


        public Form_Email_Send_MultiSelect()
        {
            InitializeComponent();

            tem2.Tanzim_Email_set();
            textBox1_sender.Text = Class1.AddressSender;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Email_MultiSelect f1 = new Form_Email_MultiSelect(this);
            f1.ShowDialog();
        }

        private void Form_Email_Send_MultiSelect_Load(object sender, EventArgs e)
        {
            string c = "", m = "", y = "";


            string Name_day = dom.day();
 
            c = dom.daycount();

            m = dom.month();

            y = dom.year();

         string date  = y + "/" + m + "/" + c;

         
                string clock = DateTime.Now.ToLongTimeString();

           
            textBox5_Tarikh.Text = "این پیام در تاریخ "+date+" در روز "+Name_day+" در ساعت "+clock+"ارسال شده است";

            
            cldbSql.CallDB("update Personel set چکباکس= 'false'");
          
     
        }

        public void ViewGiandegan(string str)
        {
            try
            {
 
                DataView dv;
                dv = cmdsql.vt(str);
                dataGridView1.DataSource = dv;

              }
            catch (Exception ex)
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }



        private void button4_Click(object sender, EventArgs e)
        {
            //cldbSql.CallDB("update Personel set چکباکس= 'false'");
             
            this.Close();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (InternetCS.IsConnectedToInternet() == true || InternetCS.Check_Connect_Internet()==true)
            { 
         
            
            if (textBox1_sender.Text != "" & dataGridView1.RowCount > 0)
            {

                Form_Email_send_Final f_e_d_f = new Form_Email_send_Final(this);
                f_e_d_f.ShowDialog();


            }
            
            else if (textBox1_sender.Text == "")
            {

                MessageBox.Show("تنضیمات ارسال پیام را انجام نشده است ");
            }

            if (dataGridView1.RowCount == 0) {

                MessageBox.Show("هیچ انتخابی برای دریافت پیام صورت نگرفته است");

         
            
            }


             }

            else if (InternetCS.IsConnectedToInternet() == false)
            {
                MessageBox.Show("اتصال به اینترنت برقرار نیست");

            }
         


        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgopenFile = new OpenFileDialog();
            dlgopenFile.Filter = "All Files (*.*)|*.*";

            dlgopenFile.Title = "Select File to Attach";

            dlgopenFile.ShowDialog();
            textBox3_attach.Text = dlgopenFile.FileName;

        }

    }
}
