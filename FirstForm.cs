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
    public partial class FirstForm : Form
    {
        Main m = new Main();
        login lgn = new login();

        public SqlConnection con;
        public SqlDataAdapter da;



        public FirstForm()
        {
            InitializeComponent();





        }

        private void button1_Click(object sender, EventArgs e)
        {



            try
            {

                if (textBox1.Text != null & textBox3.Text == "AsFCDF1Q3QWSW9fsFS0fd3vF7i29H")
                {
                    this.Visible = false;
                    login l = new login();

                    l.Show();


                    string str1 = "";
                    str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                    SqlConnection CN = new SqlConnection(str1);

                    string qry = "insert into ser(Name_Company) values(@c1)";



                    SqlCommand SqlCom = new SqlCommand(qry, CN);

                    SqlCom.Parameters.Add(new SqlParameter("@c1", (object)textBox1.Text));


                    CN.Open();

                    SqlCom.ExecuteNonQuery();

                    CN.Close();

                }
            }
            catch (Exception er)
            {

                
                MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }




        }

       



        EditPersoal ep = new EditPersoal();

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();


        }

       
         

        private void FirstForm_VisibleChanged(object sender, EventArgs e)
        {
            try{

            Barrasi_Serial();

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }




        public void Barrasi_Serial() {

            try{

            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            con = new SqlConnection(str1);

            con.Open();
            //جلوگیری از تکرار کد_ملی
            string s1 = "select * from ser where serial='1111333399990000rraammaazaann'";

            da = new SqlDataAdapter(s1, con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
             
                timer1.Enabled = false;

            }
            else
            {

                //m.toolStripl1.Text = (dt.Rows[0]["Name_Company"].ToString());
                pictureBox1.Visible = true;

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                timer1.Enabled = true;



            }


            con.Close();


            }
            catch (Exception er)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }

        } 




        private void timer1_Tick(object sender, EventArgs e)
        {

            this.Hide();
            lgn.Show();

            timer1.Enabled = false;


        }

    

        private void button3_Click(object sender, EventArgs e)
        {
         

            if (textBox1.Text == "") errorProvider1.SetError(textBox1, " لطفا نام را وارد کنید");
            else if (textBox4.Text == "") errorProvider1.SetError(textBox2, " فاميلي را وارد کنيد");

             else

                try
                {


                    string str1 = "";
                    str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                    SqlConnection CN = new SqlConnection(str1);

                    string qry = "insert into ser(Name_Company,name_Modir,logo,address_logo,serial) values(@c1,@c2,@c3,@c4,@c5)";

                    byte[] imageData = Class_mft.ReadFile(label6.Text);



                    SqlCommand SqlCom = new SqlCommand(qry, CN);

                    SqlCom.Parameters.Add(new SqlParameter("@c1", (object)textBox1.Text));
                    SqlCom.Parameters.Add(new SqlParameter("@c2", (object)textBox4.Text));

                    SqlCom.Parameters.Add(new SqlParameter("@c3", (object)imageData));
                    SqlCom.Parameters.Add(new SqlParameter("@c4", (object)label6.Text));
                    SqlCom.Parameters.Add(new SqlParameter("@c5", (object)textBox3.Text));

                    CN.Open();

                    SqlCom.ExecuteNonQuery();

               //     MsgBox.ShowMessage(this.Handle.ToInt32(), " مشخصات وارد شده با موفقیت ثبت شد ", "   ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                    CN.Close();

                }
                catch (Exception er)
                {
 
                    MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                }

                finally
                {

                    Barrasi_Serial();

                }
          

        }

 


        private void button2_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();
            
            try{

            if (dlgRes != DialogResult.Cancel)
            {
                pictureBox2.ImageLocation = dlg.FileName;

                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                label6.Text = dlg.FileName;

            }

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

         

        }
    }

