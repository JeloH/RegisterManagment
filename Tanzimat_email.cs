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
    public partial class Tanzimat_email : Form
    {


        Form_Email_Send_Taki f;
        Class_mft c1 = new Class_mft();
        

        public Tanzimat_email()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


       
        private void button2_Click(object sender, EventArgs e)
        {
            
            
            
         
           
            if (textBox1.Text == "") { MessageBox.Show("نام کاربری رایانامه را وارد نمایید"); }

            else if (textBox2.Text == "") { MessageBox.Show("رمز عبور رایانامه را وارد نمایید"); }

            else if (textBox3.Text == "" & c1.BarrasiFieldEmail(textBox3.Text) == false) { MessageBox.Show("رایانامه  را صحیح وارد نمایید"); }
          
            else if (textBox4.Text == "") { MessageBox.Show(" سرور ایمیل  را وارد نمایید(smtp)"); }
          
            else if (textBox5.Text == "") { MessageBox.Show("شماره پورت را وارد نمایید"); }



            else
            {

                cldbSql.CallDB("delete from Tanzim_email");

                SqlConnection con = new SqlConnection();


                try
                {

                    //  string s3 = "Data Source=.;Initial Catalog=db2;Integrated Security=true;";
                    //string s3 = @"provider=microsoft.jet.oledb.4.0;" + @"data source=..\\Debug\\db\\db2.mdb";


                    string str1 = "";
                    str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                    con = new SqlConnection(str1);

                    con.Open();


                    SqlCommand cmd = new SqlCommand("insert into Tanzim_email(us,pass,address_sender,smtp,port,ssl)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + checkBox1.Checked + "')", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("تنظیمات رایانامه ذخیره شد");
                    con.Close();

                }
                catch (Exception er)
                {
                    MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }


                //----------------------


                Tanzim_Email_set();


                //-------------------

             //   f = new Form_Email_Taki();

           //     f.Visible = true;

            }


        }


        public void Tanzim_Email_set()
        {


            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection con = new SqlConnection(str1);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Tanzim_email ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                if (dr["us"].ToString() != "")
                {

                    Class1.user = dr["us"].ToString();
                    Class1.password = dr["pass"].ToString();
                    Class1.AddressSender = dr["address_sender"].ToString();
                    Class1.SmtpMaileServer = dr["smtp"].ToString();
                    Class1.Port = dr["port"].ToString();
                    Class1.True_False_SSL = (bool)dr["ssl"];

                }

            }


        }

        private void Tanzimat_email_Load(object sender, EventArgs e)
        {
            textBox5.ContextMenu = new ContextMenu(); //Disable Right Click
            
            Tanzim_Email_set();
            View_Tanzimat();
        }


        public void View_Tanzimat() {

            if (Class1.user != "")
            {

                textBox1.Text = Class1.user;
                textBox2.Text = Class1.password;
                textBox3.Text = Class1.AddressSender;
                textBox4.Text = Class1.SmtpMaileServer;
                textBox5.Text = Class1.Port;

                checkBox1.Checked = Class1.True_False_SSL;

            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {


            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }

            else {

                e.Handled = true;
            
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
        
            DialogResult dr = MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا تنظیمات وارد شده پاک شوند؟", "پاک شدن تنظیمات", "بله", "خیر", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            if (dr == DialogResult.Yes)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                checkBox1.Checked = false;

               //-----------------------

                Class1.user ="";
                Class1.password = "";
                Class1.AddressSender = "";
                Class1.SmtpMaileServer = "";
                Class1.Port = "";
                Class1.True_False_SSL = false;


                //----------------
                cldbSql.CallDB("delete from Tanzim_email");

                this.Close();

            }

            else if (dr == DialogResult.No)
            {
             
            }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
