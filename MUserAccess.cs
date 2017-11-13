using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Applictaion_Ozviat
{ 
    public partial class MUserAccess : Form
    {
       
        CurrencyManager cm;


         cldbSql cmdsql = new cldbSql();
       

        public MUserAccess()
        {
            InitializeComponent(); 
  
        }

   
 
        private void button2_Click(object sender, EventArgs e)
        {
           //dbAccess.CallDB("insert into log(us,E_Moshakh,E_Parvande,E_Sabt,E_Report)values('" + textBox4.Text + "','" + label4.Text + "','" + label5.Text + "','" + label6.Text + "','" + label7.Text + "')");
            try{


            if (textBox3.Text != "")
            {

                cldbSql.CallDB("update log set E_Moshakh='" + comboBox1.Text + "',E_Report='" + comboBox2.Text + "',E_Parvande='" + comboBox3.Text + "',E_Sabt='" + comboBox4.Text + "',E_SMS='" + comboBox5.Text + "' ,E_Mail='" + comboBox6.Text + "'where us= '" + textBox3.Text + "'");

                 
                 MsgBox.ShowMessage(this.Handle.ToInt32(), "تغییرات به موفقیت انجام شد <--> با ورود مجدد کاربر تمام تغییرات انجام شده صورت می گیرد", "   ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                
                cm.EndCurrentEdit();
            }

            else
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), " هیچ سطری انتخاب نشده است", "   ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }



          }




        public void SearchDB(string str)
        {
            try{

            DataBindingClear();

            DataView dv;
            dv = cmdsql.vt(str);

            dataGridView1.DataSource = dv;

            dataGridView1.Columns["ویرایش مشخصات اعضا"].Visible = false;
            dataGridView1.Columns["انجام گزارشگیری"].Visible = false;
            dataGridView1.Columns["ویرایش پرونده فنی"].Visible = false;
            dataGridView1.Columns["ثبت نام کردن"].Visible = false;
            dataGridView1.Columns["ارسال پیام کوتاه_اس_ام_اس"].Visible = false;
            dataGridView1.Columns["ارسال رایانامه"].Visible = false;

         

            DataBindingAdd(dv);


            // DataBindingAdd(dv);

            cm = (CurrencyManager)BindingContext[dv];


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }

        }

        public void DataBindingClear()
        {


    //        textBox1.DataBindings.Clear();

            
            //textBox12.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();


            comboBox1.DataBindings.Clear();

            comboBox2.DataBindings.Clear();
            comboBox3.DataBindings.Clear();
            comboBox4.DataBindings.Clear();
            comboBox5.DataBindings.Clear();
            comboBox6.DataBindings.Clear();

      
        }


        public void DataBindingAdd(DataView dv)
        {
             
       
             textBox2.DataBindings.Add("Text", dv, "نام و نام خانوادگی");
            textBox3.DataBindings.Add("Text", dv, "نام کاربری");
            //comboBox14.DataBindings.Add("Text", dv, "E_Moshakh");
          
            comboBox1.DataBindings.Add("Text", dv, "ویرایش مشخصات اعضا");

            
            comboBox2.DataBindings.Add("Text", dv, "انجام گزارشگیری");
            comboBox3.DataBindings.Add("Text", dv, "ویرایش پرونده فنی");
            comboBox4.DataBindings.Add("Text", dv, "ثبت نام کردن");
            comboBox5.DataBindings.Add("Text", dv, "ارسال پیام کوتاه_اس_ام_اس");
            comboBox6.DataBindings.Add("Text", dv, "ارسال رایانامه");


        }


 
     

        private void MUserAccess_Load_2(object sender, EventArgs e)
        {

            SearchDB("select Name+' '+Family as [Name and family ],us as [User Name],pass as [Password],T_u as [Type of User],E_Moshakh AS [Edit for personal information],E_Report [Reporting],E_Parvande AS [Edit for Technical Information],E_Sabt AS [Register],E_SMS AS [send sms],E_Mail AS [send mail]  from log where T_u='کاربر فعال' ");
         
       
            //   textBox1.DataBindings.Add("Text", dv, "us");

            //  textBox2.DataBindings.Add("Text", dv, "Name");
            //  textBox3.DataBindings.Add("Text", dv, "Family");


             

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            SearchDB("select Name+' '+Family as [Name and family ],us as [User Name],pass as [Password],T_u as [Type of User],E_Moshakh AS [Edit for personal information],E_Report [Reporting],E_Parvande AS [Edit for Technical Information],E_Sabt AS [Register],E_SMS AS [send sms],E_Mail AS [send mail] from log where T_u='کاربر فعال' and us like N'%" + textBox1.Text + "%' ");
         
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
         
            SearchDB("select Name+' '+Family as [Name and family ],us as [User Name],pass as [Password],T_u as [Type of User],E_Moshakh AS [Edit for personal information],E_Report [Reporting],E_Parvande AS [Edit for Technical Information],E_Sabt AS [Register],E_SMS AS [send sms],E_Mail AS [send mail] FROM log  where  us='" + textBox1.Text + "' and  exists(select T_u from log  where Name=N'" + textBox15.Text + "' and  Family=N'" + textBox13.Text + "')");
         
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SearchDB("select us as  from log where   us = '' ");
         

            groupBox9.Enabled = false;
            groupBox5.Enabled = true;

            textBox15.Text = "";
            textBox13.Text = "";


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox9.Enabled = true;
            groupBox5.Enabled = false;

            textBox1.Text = "";
             
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SearchDB("select Name+' '+Family as [Name and family ],us as [User Name],pass as [Password],T_u as [Type of User],E_Moshakh AS [Edit for personal information],E_Report [Reporting],E_Parvande AS [Edit for Technical Information],E_Sabt AS [Register],E_SMS AS [send sms],E_Mail AS [send mail]  from log where T_u='کاربر فعال' ");
         
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
 
     
        
             
    }
}
