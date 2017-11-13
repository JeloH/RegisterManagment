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
using System.IO;

namespace Applictaion_Ozviat
{
    public partial class login : Form
    {
        Main m = new Main();
        public SqlConnection con;
        public SqlDataAdapter da;

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
          
            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
              con = new SqlConnection(str1);

            con.Open();
            //جلوگیری از تکرار کد_ملی
            string s1 = "select * from ser,log where us='" + textBox1.Text + "'and pass='" + textBox2.Text + "'";
              da = new SqlDataAdapter(s1, con);
            DataTable dt = new DataTable();
             
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {

        
                 MsgBox.ShowMessage(this.Handle.ToInt32(), "صحیح وارد کنید", " توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
          
            }
            else 
            {


                label8.Text = (dt.Rows[0]["T_u"].ToString());

           
                
            

                if (label8.Text == "مدیر")
                {
                    m.label7.Text = (dt.Rows[0]["Name"].ToString());
                    m.label9.Text = (dt.Rows[0]["Family"].ToString());
                    m.label11.Text = (dt.Rows[0]["us"].ToString());
                    m.label13.Text = (dt.Rows[0]["T_u"].ToString());

                    m.اپراتورToolStripMenuItem.Visible = false;

                    m.pictureBox1.ImageLocation = (dt.Rows[0]["Adr_Pic"].ToString());

                    m.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    m.toolStripLabel1.Text = (dt.Rows[0]["Name_Company"].ToString());


                }
                else if (label8.Text == "کاربر فعال")
                {
                    m.label7.Text = (dt.Rows[0]["Name"].ToString());
                    m.label9.Text = (dt.Rows[0]["Family"].ToString());
                    m.label11.Text = (dt.Rows[0]["us"].ToString());
                    m.label13.Text = (dt.Rows[0]["T_u"].ToString());

                    Main.E_Moshakh = (dt.Rows[0]["E_Moshakh"].ToString());
                    Main.E_Parvande = (dt.Rows[0]["E_Parvande"].ToString());
                    Main.E_Report = (dt.Rows[0]["E_Report"].ToString());
                    Main.E_Sabt = (dt.Rows[0]["E_Sabt"].ToString());
                    Main.E_Mail = (dt.Rows[0]["E_Mail"].ToString());
                    Main.E_SMS = (dt.Rows[0]["E_SMS"].ToString());
    
                    m.toolStripSplitButton4.Visible = false;
                    m.مدیریتToolStripMenuItem.Visible = false;

                    m.pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0]["Pic"])); ;

                    m.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    m.toolStripLabel1.Text = (dt.Rows[0]["Name_Company"].ToString());



                }



                m.Show();
                this.Hide();
            }

            con.Close();


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }



        }

  
        DataSet ds;
        DataTable dt;
        private void button3_Click(object sender, EventArgs e)
        {
            try{

            ds = new DataSet();
            dt = new DataTable();
            this.Text = ds.Tables["Personel"].Rows[0]["کد_عضویت"].ToString();


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }
             //dt = ds.Tables["Personel"];
            //string stId = dt.Rows[3]["فامیلی"].ToString();
          //  this.Text = stId;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
