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
    public partial class AddUser_M : Form
    {
        private static string str;

        public static string Str
        {
            get { return AddUser_M.str; }
            set { AddUser_M.str = value; }
        }

        public AddUser_M()
        {
            InitializeComponent();
            label1.Text = Str;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.

            
                byte[] data = null;
                try
                {

                //Use FileInfo object to get file size.

                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;

                //Open FileStream to read file
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

                //Use BinaryReader to read file stream into byte array.
                BinaryReader br = new BinaryReader(fStream);

                //When you use BinaryReader, you need to supply number of bytes to read from file.
                //In this case we want to read entire file. So supplying total number of bytes.
                data = br.ReadBytes((int)numBytes);


               }

            catch(Exception ex)
            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }

            return data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        

            if (textBox1.Text == "") errorProvider1.SetError(textBox1, " لطفا نام را وارد کنید");
            else if (textBox2.Text == "") errorProvider1.SetError(textBox2, " فاميلي را وارد کنيد");

            else if (textBox3.Text == "") errorProvider1.SetError(textBox3, "  نام کاربری را وارد کنيد");
            else if (textBox4.Text == "") errorProvider1.SetError(textBox4, " رمز عبور را وارد کنيد");
            else if (comboBox1.Text == "") errorProvider1.SetError(comboBox1, "نوع کاربر را مشخص کنید");
            else if (txtImagePath.Text == "") errorProvider1.SetError(pictureBox1, " عکس کاربر اضافه نشده");

            else
            {

                try
                {

                    string str1 = "";
                    str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                    SqlConnection con = new SqlConnection(str1);

                    con.Open();
                    //جلوگیری از تکرار کد_ملی

                    string s1 = " select * from log where us='" + textBox3.Text + "'  ";
                    SqlDataAdapter da = new SqlDataAdapter(s1, con);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {

                        //----------این نام کاربری  وجود ندارد -------------------------------------

                        Insert_OR_Add_User();

                        //-----------------------------------------------------------------------


                    }


                    else
                    {

                        //------------

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "این  نام کاربری وجود دارد", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);



                    }

                }
                catch (Exception ex)
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }


            }



        }



        public void Insert_OR_Add_User() {


            try
            {


                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection CN = new SqlConnection(str1);

                string qry = "insert into log(Name,Family,us,pass,T_u,Adr_Pic,Pic,E_Moshakh,E_Report,E_Parvande,E_Sabt,E_SMS,E_Mail) values(@c1,@c2,@c3,@c4,@c5,@c6,@c7,@c8,@c9,@c10,@c11,@c12,@c13)";

                byte[] imageData = ReadFile(txtImagePath.Text);


                
                SqlCommand SqlCom = new SqlCommand(qry, CN);

                SqlCom.Parameters.Add(new SqlParameter("@c1", (object)textBox1.Text));
                SqlCom.Parameters.Add(new SqlParameter("@c2", (object)textBox2.Text));
                SqlCom.Parameters.Add(new SqlParameter("@c3", (object)textBox3.Text));
                SqlCom.Parameters.Add(new SqlParameter("@c4", (object)textBox4.Text));
                SqlCom.Parameters.Add(new SqlParameter("@c5", (object)comboBox1.Text));
                SqlCom.Parameters.Add(new SqlParameter("@c6", (object)txtImagePath.Text));
                SqlCom.Parameters.Add(new SqlParameter("@c7", (object)imageData));

                SqlCom.Parameters.Add(new SqlParameter("@c8", (object)"مجوز ندارد"));
                SqlCom.Parameters.Add(new SqlParameter("@c9", (object)"مجوز ندارد"));
                SqlCom.Parameters.Add(new SqlParameter("@c10", (object)"مجوز ندارد"));
                SqlCom.Parameters.Add(new SqlParameter("@c11", (object)"مجوز دارد"));

                SqlCom.Parameters.Add(new SqlParameter("@c12", (object)"مجوز ندارد"));
                SqlCom.Parameters.Add(new SqlParameter("@c13", (object)"مجوز ندارد"));


                CN.Open();

                SqlCom.ExecuteNonQuery();
              
                MsgBox.ShowMessage(this.Handle.ToInt32(), "عملیات ثبت با موفقیت انجام شد ", "  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                CN.Close();


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                pictureBox1.Image = null;

            }
            catch (Exception er)
            {
 
                MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }
          
        
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();

            try{

            if (dlgRes != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = dlg.FileName;

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                txtImagePath.Text = dlg.FileName;

            }


            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

    }
}
