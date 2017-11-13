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
    public partial class Form_Email_View_Send_email : Form
    {

        
        cldbSql cmdsql = new cldbSql();
        CurrencyManager cm;
 



        public Form_Email_View_Send_email()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }


        public void SearchDB(string str)
        {
             
                DataBindingClear();

                DataView dv;
                dv = cmdsql.vt(str);

                dataGridView1.DataSource = dv;

                DataBindingAdd(dv);


                // DataBindingAdd(dv);

                cm = (CurrencyManager)BindingContext[dv];
          


        }

        public void DataBindingClear()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            textBox8.DataBindings.Clear();
            textBox9.DataBindings.Clear();
            textBox10.DataBindings.Clear();
            textBox11.DataBindings.Clear();
            textBox12.DataBindings.Clear();
            textBox13.DataBindings.Clear();
            textBox14.DataBindings.Clear();

        
            
            textBox18.DataBindings.Clear();
        

        }

        public void DataBindingAdd(DataView dv)
        {

          //-----------------فرستنده--------------------------------
             textBox1.DataBindings.Add("Text", dv, "فرستنده");
             textBox2.DataBindings.Add("Text", dv, "Name");
             textBox3.DataBindings.Add("Text", dv, "Family");
             textBox4.DataBindings.Add("Text", dv, "us");
             textBox5.DataBindings.Add("Text", dv, "T_u");
      

        //----------------------گیرنده--------------------------------
            textBox6.DataBindings.Add("Text", dv, "گیرنده");
            textBox7.DataBindings.Add("Text", dv, "نام");
            textBox8.DataBindings.Add("Text", dv, "فامیلی");
            textBox9.DataBindings.Add("Text", dv, "کد_ملی");
            textBox10.DataBindings.Add("Text", dv, "کد_عضویت");

            
        //--------------------------جزئیات ارسال پپام-----------------          
            textBox11.DataBindings.Add("Text", dv, "کد_ارسال");
            textBox12.DataBindings.Add("Text", dv, "تاریخ_ارسال");
            textBox13.DataBindings.Add("Text", dv, "موضوع");
    
            textBox14.DataBindings.Add("Text", dv, "فایل_پیوست");
            
            
            
            textBox18.DataBindings.Add("Text", dv, "متن_پیام");
            


        }

        private void Form_Email_View_Send_email_Load(object sender, EventArgs e)
        {
            //SearchDB(" select  send_email.کد_ارسال,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی ,send_email.فرستنده,send_email.گیرنده,send_email.موضوع,send_email.تاریخ_ارسال,send_email.فایل_پیوست,send_email.متن_پیام,send_email.us,log.T_u,log.Name,log.Family from Personel,log,send_email where Personel.کد_عضویت=send_email.کد_عضویت and  send_email.us=log.us");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox11.Text != "")
            {
                //MessageBoxFrmEx.Show("آیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شود؟", "حذف اعضا", MessageBoxButtons.YesNo);


                if (MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا این پیام حذف شود ؟", "حذف پیام ارسال شده", "بله", "خیر", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes)
                {


                    try
                    {

                        string str1 = "";
                        str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                        SqlConnection con = new SqlConnection(str1);
                        SqlCommand com = con.CreateCommand();
                        com.CommandText = "delete from send_email where  کد_ارسال=N'" + textBox11.Text + "'";

                        com.CommandType = CommandType.Text;

                        DataSet ds = new DataSet();

                        SqlDataAdapter da = new SqlDataAdapter(com);

                        SqlCommandBuilder comb = new SqlCommandBuilder(da);

                        da.Fill(ds);



                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox13.Text = "";
                        textBox14.Text = "";
                        textBox15.Text = "";



                        cm.RemoveAt(cm.Position);


                    }
                    catch (Exception)
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "دیگر انتخابی برای حذف وجود ندارد ", "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    }


                }


            }

            else
            {


                MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ سطری برای حذف انتخاب نشده است", "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            groupBox8.Enabled = false;
            groupBox9.Enabled = true;

            textBox17.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox8.Enabled = true;
            groupBox9.Enabled = false;

            textBox15.Text = "";
            textBox16.Text = "";
          
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (textBox20.Text != "")
            {
             
                SearchDB(" select  send_email.کد_ارسال,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی ,send_email.فرستنده,send_email.گیرنده,send_email.موضوع,send_email.تاریخ_ارسال,send_email.فایل_پیوست,send_email.متن_پیام,send_email.us,log.T_u,log.Name,log.Family from Personel,log,send_email where Personel.کد_عضویت=send_email.کد_عضویت and  send_email.us=log.us and Personel.کد_عضویت like N'%" + textBox20.Text + "%'");
       
            }
            else
            {
                 SearchDB(" select  send_email.کد_ارسال,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی ,send_email.فرستنده,send_email.گیرنده,send_email.موضوع,send_email.تاریخ_ارسال,send_email.فایل_پیوست,send_email.متن_پیام,send_email.us,log.T_u,log.Name,log.Family from Personel,log,send_email where Personel.کد_عضویت=send_email.کد_عضویت and  send_email.us=log.us and Personel.کد_عضویت = N'' ");
       
                Clear_ViewMoeshekhasatePersonel();
            }

        }


        public void Clear_ViewMoeshekhasatePersonel()
        {


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text != "")
            {

                SearchDB(" select  send_email.کد_ارسال,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی ,send_email.فرستنده,send_email.گیرنده,send_email.موضوع,send_email.تاریخ_ارسال,send_email.فایل_پیوست,send_email.متن_پیام,send_email.us,log.T_u,log.Name,log.Family from Personel,log,send_email where Personel.کد_عضویت=send_email.کد_عضویت and  send_email.us=log.us and Personel.کد_ملی like N'%" + textBox19.Text + "%'");

            }
            else
            {
                SearchDB(" select  send_email.کد_ارسال,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی ,send_email.فرستنده,send_email.گیرنده,send_email.موضوع,send_email.تاریخ_ارسال,send_email.فایل_پیوست,send_email.متن_پیام,send_email.us,log.T_u,log.Name,log.Family from Personel,log,send_email where Personel.کد_عضویت=send_email.کد_عضویت and  send_email.us=log.us and Personel.کد_عضویت = N'' ");

                Clear_ViewMoeshekhasatePersonel();
            }

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text != "")
            {

                SearchDB(" select  send_email.کد_ارسال,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی ,send_email.فرستنده,send_email.گیرنده,send_email.موضوع,send_email.تاریخ_ارسال,send_email.فایل_پیوست,send_email.متن_پیام,send_email.us,log.T_u,log.Name,log.Family from Personel,log,send_email where Personel.کد_عضویت=send_email.کد_عضویت and  send_email.us=log.us and send_email.گیرنده like N'%" + textBox17.Text + "%'");

            }
            else
            {
                SearchDB(" select  send_email.کد_ارسال,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی ,send_email.فرستنده,send_email.گیرنده,send_email.موضوع,send_email.تاریخ_ارسال,send_email.فایل_پیوست,send_email.متن_پیام,send_email.us,log.T_u,log.Name,log.Family from Personel,log,send_email where Personel.کد_عضویت=send_email.کد_عضویت and  send_email.us=log.us and Personel.کد_عضویت = N'' ");

                Clear_ViewMoeshekhasatePersonel();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox16.Text != "" & textBox15.Text != "")
            {


                SearchDB(" select  send_email.کد_ارسال,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی ,send_email.فرستنده,send_email.گیرنده,send_email.موضوع,send_email.تاریخ_ارسال,send_email.فایل_پیوست,send_email.متن_پیام,send_email.us,log.T_u,log.Name,log.Family from Personel,log,send_email where Personel.کد_عضویت=send_email.کد_عضویت and  send_email.us=log.us and Personel.نام = N'" + textBox16.Text + "' and Personel.فامیلی  = N'" + textBox15.Text + "' ");

                 

            }

            else
            {


                MsgBox.ShowMessage(this.Handle.ToInt32(), " برای جستجو سبک 2 ، باید نام و فامیلی هر دو نوشته شوند", "توجه", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }

        }

        private void textBox20_Enter(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox19.Text = "";
         
        }

        private void textBox19_Enter(object sender, EventArgs e)
        {
            textBox17.Text = "";
          
            textBox20.Text = "";

        }

        private void textBox17_Enter(object sender, EventArgs e)
        {
            
            textBox19.Text = "";
            textBox20.Text = "";

        }

    }
}
