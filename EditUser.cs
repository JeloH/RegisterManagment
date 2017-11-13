using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;


namespace Applictaion_Ozviat
{
    public partial class EditUser : Form
    {

        CurrencyManager cm;
        cldbSql cmdsql = new cldbSql();
     

       
       
        public EditUser()
        {
            InitializeComponent();
        }


        public void DbdClear() {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
        }

        public void DataBiAdd(DataView dv) {


            textBox1.DataBindings.Add("Text", dv, "نام");
            textBox2.DataBindings.Add("Text", dv, "فامیلی");
            textBox3.DataBindings.Add("Text", dv, "نام کاربری");
            textBox4.DataBindings.Add("Text", dv, "رمز عبور");
            
            comboBox1.DataBindings.Add("Text", dv, "نوع کاربر");

            pictureBox1.DataBindings.Add("image", dv, "Pic",true);

        
        }

  
     
    

      
        public void SearchDB(string str)
        {
            try{

            DbdClear();

            DataView dv;
            dv = cmdsql.vt(str);

            dataGridView1.DataSource = dv;

            dataGridView1.Columns["Pic"].Visible = false;

            DataBiAdd(dv);


            // DataBindingAdd(dv);

            cm = (CurrencyManager)BindingContext[dv];
        
            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
        }
       
        
        

        private void Form7_Load(object sender, EventArgs e)
        {
            SearchDB("select Pic ,us as [نام کاربری],pass as [رمز عبور],Name as نام,Family as فامیلی,T_u as [نوع کاربر] from log ");
     
         
        }

        Main m3 = new Main();
        login l = new login();

 



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

                CN.Close();

                }
                catch (Exception ex)
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }


            }


        }



 

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                SearchDB("select Pic,us as [نام کاربری],pass as [رمز عبور],Name as نام,Family as فامیلی,T_u as [نوع کاربر] from log where us like N'%" + textBox6.Text + "%'  ");
            }
            else
            {
                SearchDB("select Pic,us as [نام کاربری],pass as [رمز عبور],Name as نام,Family as فامیلی,T_u as [نوع کاربر] from log where us = N''  ");
      
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchDB("select Pic ,us as [نام کاربری],pass as [رمز عبور],Name as نام,Family as فامیلی,T_u as [نوع کاربر] from log where Name = N'" + textBox15.Text + "' and  Family = N'" + textBox13.Text + "'  ");
      
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox9.Enabled = false;
            textBox15.Text = "";
            textBox13.Text = "";

            groupBox5.Enabled = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox5.Enabled = false;
            textBox6.Text = "";

            groupBox9.Enabled = true;
           
       

         
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != "")
            {


                try
                {


                    if (MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا عملیات حذف انجام شود ؟", "حذف ", "بله", "خیر", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes)
                    {



                        cldbSql.CallDB("delete from log where us= '" + textBox3.Text + "'");

                        cm.EndCurrentEdit();

                        cm.RemoveAt(cm.Position);


                    }


                }

                catch (Exception ex)
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{

            cldbSql.CallDB("update log set Name= N'" + textBox1.Text + "',Family=N'" + textBox2.Text + "',us=N'" + textBox3.Text + "',pass=N'" + textBox4.Text + "',T_u=N'" + comboBox1.Text + "' where us= N'" + textBox3.Text + "'");

            UpdatePicturePersonel();

            cm.EndCurrentEdit();


             MsgBox.ShowMessage(this.Handle.ToInt32(), "تغییرات به موفقیت انجام شد <--> با ورود مجدد کاربر تمام تغییرات انجام شده صورت می گیرد", "   ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                   }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

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

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchDB("select Pic,us as [نام کاربری],pass as [رمز عبور],Name as نام,Family as فامیلی,T_u as [نوع کاربر] from log ");
      
        }
 

    }
}
