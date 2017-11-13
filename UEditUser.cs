using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using System.Configuration;
using System.Data.SqlClient;


namespace Applictaion_Ozviat
{
    public partial class UEditUser : Form
    {
        public string s20;
        public string s21;
        public UEditUser(string str)
        {
            InitializeComponent();

            s20 = str;
        }

        cldbSql cmdsql=new cldbSql();
        login m = new login();
       
        Main m2 = new Main();


        private void Form6_Load(object sender, EventArgs e)
        {
            try{
           
            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection CN = new SqlConnection(str1);


            CN.Open();
            // DateTime.ParseExact(tarikh, "yyyy/MM/dd", null).ToString("yyyy/MM/dd")


            SqlCommand SqlCom = new SqlCommand("select * from log where us='" + s20 + "'", CN);
            SqlDataReader reader = SqlCom.ExecuteReader();
 
            while (reader.Read())
            {

                textBox1.Text = reader["Name"].ToString();
                textBox2.Text = reader["Family"].ToString();
                textBox3.Text = reader["us"].ToString();
                textBox4.Text = reader["pass"].ToString();
                pictureBox1.BackgroundImage = Image.FromStream(new MemoryStream((byte[])reader["Pic"]));

            }
          
            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{

            if (textBox3.Text != "")
            {
                cldbSql.CallDB("update log set Name= '" + textBox1.Text + "',Family='" + textBox2.Text + "',us='" + textBox3.Text + "',pass='" + textBox4.Text + "' where us= '" + textBox3.Text + "'");

                UpdatePicturePersonel();

                 MsgBox.ShowMessage(this.Handle.ToInt32(), "تغییرات به موفقیت انجام شد <--> با ورود مجدد کاربر تمام تغییرات انجام شده صورت می گیرد", "توجه", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
            }

            else

            {

 
                MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ کاربری صحیح وارد نشده است", "توجه", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
            }


            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
           
        }


        public void UpdatePicturePersonel()
        {
            //به خاطر این نوشته شده تا زمانی که آدرس عکس  جدید داده شد عملیات بروزرسانی انجام شود if
            //اگر نباشد خطا بوجود می آید if 

            if (textBox5.Text != "")
            {

                try{

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection CN = new SqlConnection(str1);

                string qry = "update log set Adr_Pic=@Adr_Pic,Pic=@Pic where us=N'" + textBox3.Text + "'  ";




                SqlCommand cmd = new SqlCommand(qry, CN);



                byte[] imageData = Class_mft.ReadFile(textBox5.Text);

                cmd.Parameters.Add("@Pic", SqlDbType.VarBinary).Value = imageData;//برای به روز رسانی یا برای نماش عکس نیاز به وجود آدرس عکس نمی باشد همان فیلد باینری کافی می باشد
                cmd.Parameters.Add("@Adr_Pic", SqlDbType.NVarChar).Value = textBox5.Text;//



                CN.Open();

                cmd.ExecuteNonQuery();

                MsgBox.ShowMessage(this.Handle.ToInt32(), "تغییرات به موفقیت انجام شد <--> با ورود مجدد کاربر تمام تغییرات انجام شده صورت می گیرد", "توجه", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            

                CN.Close();

              
                }
                catch (Exception ex)
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();

            try{

            if (dlgRes != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = dlg.FileName;

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                textBox5.Text = dlg.FileName;

            }

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }
  
        private void button2_Click(object sender, EventArgs e)
        {
           //Main.S20 = "13252";

            this.Close(); 
 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            pictureBox1.ImageLocation = "";
        }

       

    }
}
