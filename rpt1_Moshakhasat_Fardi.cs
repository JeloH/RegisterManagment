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
    public partial class rpt1_Parv_Fardi : Form
    {

        SqlDataAdapter da = new SqlDataAdapter();
        cldbSql cmdsql = new cldbSql();
         CurrencyManager cm;
 
         
       

        public rpt1_Parv_Fardi()
        {
            InitializeComponent();
        }

    

        
        public void SearchDB(string str)
        {

            try
            {

                DataBindingClear();

                DataView dv;
                dv = cmdsql.vt(str);

                dataGridView1.DataSource = dv;

                dataGridView1.Columns["عکس"].Visible = false;


                DataBindingAdd(dv);


                // DataBindingAdd(dv);

                cm = (CurrencyManager)BindingContext[dv];


            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

       




        public void DataBindingClear()
        {
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
            textBox15.DataBindings.Clear();
            textBox16.DataBindings.Clear();
            textBox17.DataBindings.Clear();
            textBox18.DataBindings.Clear();
 
            pictureBox1.DataBindings.Clear();
        }



        public void DataBindingAdd(DataView dv)
        {

            textBox5.DataBindings.Add("Text", dv, "کد_عضویت");
            textBox6.DataBindings.Add("Text", dv, "نام");
            textBox7.DataBindings.Add("Text", dv, "فامیلی");
            textBox8.DataBindings.Add("Text", dv, "نام_پدر");
            textBox9.DataBindings.Add("Text", dv, "تاریخ_تولد");
            textBox10.DataBindings.Add("Text", dv, "شماره_شناسنامه");
            textBox11.DataBindings.Add("Text", dv, "کد_ملی");
            textBox12.DataBindings.Add("Text", dv, "شهر_اقامت");
            textBox13.DataBindings.Add("Text", dv, "تلفن_همراه");
            textBox14.DataBindings.Add("Text", dv, "تابعیت");
            textBox15.DataBindings.Add("Text", dv, "پست_الکترونیکی");
            textBox16.DataBindings.Add("Text", dv, "مذهب");
            textBox17.DataBindings.Add("Text", dv, "وضعیت_تاهل");
            textBox18.DataBindings.Add("Text", dv, "آدرس");


            pictureBox1.DataBindings.Add("image", dv, "عکس",true);
        }

    
 




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

            SearchDB("select * from Personel where کد_عضویت like N'%" + textBox1.Text + "%'");

            
           
        }

        
 

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           

            SearchDB("select * from Personel where نام like N'%" + textBox3.Text + "%' or فامیلی like N'%" + textBox4.Text + "%'  ");   

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
             

            SearchDB("select * from Personel where کد_ملی like N'%" + textBox2.Text + "%'");   
         }

      
     


      

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (textBox20.Text != "")
            {


                SearchDB("select Personel.عکس, Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel where نام like N'%" + textBox20.Text + "%'");
            
            
            }
            else
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N''");
                Clear_ViewMoeshekhasatePersonel();



               } 


        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text != "")
            {



                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel where فامیلی like N'%" + textBox19.Text + "%'");

            }
            else
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N''");

                Clear_ViewMoeshekhasatePersonel();


            } 


        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

            if (textBox3.Text != "")
            {




                SearchDB("select Personel.عکس, Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel where کد_عضویت like N'%" + textBox3.Text + "%'");

            }
            else
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N''");
                Clear_ViewMoeshekhasatePersonel();



            } 


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (textBox4.Text != "")
            {


                SearchDB("select Personel.عکس, Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel where کد_ملی like N'%" + textBox4.Text + "%'");
          
            }
            else
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N''");
                Clear_ViewMoeshekhasatePersonel();



            } 

        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "")
            {

                DataBindingClear();
                SearchDB("select Personel.عکس, Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel where   Personel.نام = N'" + textBox2.Text + "' and Personel.فامیلی  = N'" + textBox1.Text + "'  ");
                 

            }

            else
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), " برای جستجو سبک 2 ، باید نام و فامیلی هر دو نوشته شوند", "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox5.Text != "")
            {
                Report r = new Report("..\\Debug\\rpt\\rpt1\\Report_MoshakhasatFardi.rdlc", "select * from Personel,ser where کد_عضویت = '" + int.Parse(textBox5.Text) + "'  or کد_ملی = '" + textBox1.Text + "'  or (نام = '" + textBox3.Text + "' and فامیلی = '" + textBox4.Text + "') ");
                //r.MdiParent = this;
                r.ShowDialog();
            }
            else
            {

               
                MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ فردی انتخاب نشده است", "توجه !! ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }
            
            
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox7.Enabled = true;
            label25.Enabled = true;

            groupBox9.Enabled = false;
            label26.Enabled = false;


            textBox2.Text = "";
            textBox1.Text = "";

            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N''");


            Clear_ViewMoeshekhasatePersonel();


        }



        public void Clear_ViewMoeshekhasatePersonel()
        {


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
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            pictureBox1.Image = null;
        }




        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox7.Enabled = false;
            label25.Enabled = false;

            groupBox9.Enabled = true;
            label26.Enabled = true;

            textBox3.Text = "";
            textBox4.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";

            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N''");

            Clear_ViewMoeshekhasatePersonel();


             
        }



        private void textBox20_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox19.Text = "";

        }

        private void textBox19_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox20.Text = "";

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox20.Text = "";
            textBox19.Text = "";
            textBox4.Text = "";

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            try{

            
                this.dataGridView1.Columns["تاریخ_تولد"].DefaultCellStyle.Format = "yyyy/MM/dd";
     

            
            }

            catch (Exception ex)
            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchDB("select Personel.عکس, Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel ");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        
    }
}
