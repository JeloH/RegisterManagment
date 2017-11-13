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
    public partial class Form7 : Form
    {

        cldbSql cmdsql=new cldbSql();
        CurrencyManager cm;

        SqlDataAdapter da = new SqlDataAdapter();
   
        SqlConnection con;
     
        
        string rb9 = "", rb8 = "", rb3 = "", rb5 = "", rb7 = "", rb1 = "", rb2 = "", rb4 = "", rb6 = "", rb10 = "", rb11 = "", rb12 = "";


        public Form7()
        {
            InitializeComponent();


            comboBox21.MaxLength = 2;
            comboBox22.MaxLength = 2;
            comboBox10.MaxLength = 2;
            comboBox9.MaxLength = 2;
           
           



        }
 
       

        private void button1_Click(object sender, EventArgs e)
        {
            try{
  

            
            if (radioButton1.Checked)
           
               {
                   SearchDB("select  Personel.کد_عضویت,Sabt_ozv.نوع_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'" + comboBox1.Text + "' ");
           
               }

            else if (radioButton2.Checked)
            {
                SearchDB("select Personel.کد_عضویت,shoghl.نوع_شغل,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel,shoghl where Personel.کد_عضویت=shoghl.کد_عضویت  and shoghl.نوع_شغل = N'" + comboBox2.Text + "' ");
            }
            else if (radioButton3.Checked)
            {
                SearchDB("select  Personel.کد_عضویت,faal.موضوع_فعالیت as بخش,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel,faal where Personel.کد_عضویت=faal.کد_عضویت  and faal.موضوع_فعالیت =N'" + comboBox3.Text + "' ");
            }

            else if (radioButton4.Checked)
            {
                SearchDB("select  Personel.کد_عضویت,Personel.شهر_اقامت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where شهر_اقامت ='" + comboBox4.Text + "' ");
            }

            else if (radioButton5.Checked)
            {
                SearchDB("select Personel.کد_عضویت,tah.میزان_تحصیلات,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel,tah where Personel.کد_عضویت=tah.کد_عضویت  and tah.میزان_تحصیلات =N'" + comboBox5.Text + "' ");
            }


            else if (radioButton6.Checked)
            {
                SearchDB("select   Personel.کد_عضویت,Personel.وضعیت_تاهل,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel where وضعیت_تاهل ='" + comboBox6.Text + "' ");
            }
            else if (radioButton7.Checked)
            {
                SearchDB("select   Personel.کد_عضویت,tah.رشته_تحصیلی,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس   from Personel,tah where Personel.کد_عضویت=tah.کد_عضویت  and tah.رشته_تحصیلی = N'" + comboBox7.Text + "' ");
            }
            else if (radioButton8.Checked)
            {
                //int x1 = int.Parse(textBox1.Text);
                //int x2 = int.Parse(textBox2.Text);



                SearchDB("select Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس   from Personel,Sabt_ozv where Personel.کد_عضویت= Sabt_ozv.کد_عضویت and Personel.کد_عضویت between '" + comboBox8_1.Text + "' and '" + comboBox8_2.Text + "' ");
            }



            else if (radioButton9.Checked)
            {
                
                BarrasiFieldTarikhi();

                errorProvider1.Clear();

                if (comboBox21.Text == "") errorProvider1.SetError(comboBox21, " روز تاريخ اول تولد را وارد کنيد");
                else if (comboBox22.Text == "") errorProvider1.SetError(comboBox22, " ماه تاريخ اول را وارد کنيد");
                else if (textBox23.Text == "") errorProvider1.SetError(textBox23, " سال تاريخ اول را وارد کنيد");

                else if (comboBox10.Text == "") errorProvider1.SetError(comboBox10, " روز تاريخ دوم را وارد کنيد");
                else if (comboBox9.Text == "") errorProvider1.SetError(comboBox9, " ماه تاريخ دوم را وارد کنيد");
                else if (textBox1.Text == "") errorProvider1.SetError(textBox1, " سال تاريخ دوم را وارد کنيد");

                 else
                 {

                     //--------------------------------تاریخ اول--------------------------
                     string str_rouz = "", str_mah = "", str_sal = "";

                     str_rouz = comboBox21.Text;
                     str_mah = comboBox22.Text;
                     str_sal = textBox23.Text;

                     string tarikh1 = str_sal + "/" + str_mah + "/" + str_rouz;

                     //----------------------------------تاریخ دوم----------------
                     string str_rouz2 = "", str_mah2 = "", str_sal2 = "";

                     str_rouz2 = comboBox10.Text;
                     str_mah2 = comboBox9.Text;
                     str_sal2 = textBox1.Text;

                     string tarikh2 = str_sal2 + "/" + str_mah2 + "/" + str_rouz2;
                     //-----------------------------------------------------------------------------------

                     SearchDB("select   Personel.کد_عضویت,Sabt_ozv.تاریخ_عضویت ,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel,Sabt_ozv where Personel.کد_عضویت= Sabt_ozv.کد_عضویت and Sabt_ozv.تاریخ_عضویت between '" + tarikh1 + "' and '" + tarikh2 + "' ");

                 }
            }

          


         
            
            else if (radioButton10.Checked)
            {
                SearchDB("select * from Personel");
            }
            
            else if (radioButton11.Checked)
            {

                SearchDB("select * from Personel where جنسیت='مذکر' ");
           
            }

            else if (radioButton12.Checked)
            {
                SearchDB("select * from Personel where جنسیت='موئنث' ");

            }

            else { 
                
                MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ انتخابی برای عملیات جستجو صورت نگرفته است", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
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


            this.dataGridView1.Columns["تاریخ_تولد"].DefaultCellStyle.Format = "yyyy/MM/dd";


            if (radioButton9.Checked == true)
            {

                this.dataGridView1.Columns["تاریخ_عضویت"].DefaultCellStyle.Format = "yyyy/MM/dd";

            }


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

            text1.DataBindings.Clear();
            text2.DataBindings.Clear();
            text3.DataBindings.Clear();
            text4.DataBindings.Clear();

            //---

            text5.DataBindings.Clear();
            text6.DataBindings.Clear();
            text7.DataBindings.Clear();
            //---

            text8.DataBindings.Clear();
            text9.DataBindings.Clear();
            text10.DataBindings.Clear();
            text11.DataBindings.Clear();
            text12.DataBindings.Clear();
            text13.DataBindings.Clear();
            maskedTextBox3.DataBindings.Clear();
            

            //------

            
             
        }


        public void DataBindingAdd(DataView dv)
        {
            text1.DataBindings.Add("Text", dv, "کد_عضویت");
            text2.DataBindings.Add("Text", dv, "نام");
            text3.DataBindings.Add("Text", dv, "فامیلی");
            text4.DataBindings.Add("Text", dv, "نام_پدر");

            //--------
 
            Binding b = new Binding("Text", dv, "تاریخ_تولد", true);
            b.FormatString = "yyyy/MM/dd";
            //     b.FormatString = "yyyy/MM/dd hh:mm tt";

            maskedTextBox3.DataBindings.Add(b);  
 
            
            
            
            text5.DataBindings.Add("Text", dv, "شماره_شناسنامه");
            text6.DataBindings.Add("Text", dv, "کد_ملی");

            //--------

            text7.DataBindings.Add("Text", dv, "شهر_اقامت");
            text8.DataBindings.Add("Text", dv, "تلفن_همراه");
            text9.DataBindings.Add("Text", dv, "تابعیت");
            text10.DataBindings.Add("Text", dv, "پست_الکترونیکی");
            text11.DataBindings.Add("Text", dv, "مذهب");
            text12.DataBindings.Add("Text", dv, "وضعیت_تاهل");
            //--------
            text13.DataBindings.Add("Text", dv, "آدرس");

              //--------
             
        }

        

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
            
            // TODO: This line of code loads data into the 'db20DataSet1.Sabt_ozv' table. You can move, or remove it, as needed.
            this.sabt_ozvTableAdapter.Fill(this.db20DataSet1.Sabt_ozv);
            // TODO: This line of code loads data into the 'db20DataSet1.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.db20DataSet1.Personel);
            // TODO: This line of code loads data into the 'db20DataSet1.faal' table. You can move, or remove it, as needed.
            this.faalTableAdapter.Fill(this.db20DataSet1.faal);
           
             
            ComboBox5_ReshteTah_BindingSource();
            ComboBox11_ReshteTah_BindingSource();


            Disable_RightClick_Menu_Field();

            
            }
            catch (Exception)
            {
                
                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

            }
        }

      
        
        public void Disable_RightClick_Menu_Field()
        {


            // غیر فعال کردن راست کلیک

            comboBox21.ContextMenu = new ContextMenu();
            comboBox22.ContextMenu = new ContextMenu();
            comboBox10.ContextMenu = new ContextMenu();
            comboBox9.ContextMenu = new ContextMenu();

            comboBox13.ContextMenu = new ContextMenu();
            comboBox12.ContextMenu = new ContextMenu();
            textBox2.ContextMenu = new ContextMenu();
           
            comboBox8_2.ContextMenu = new ContextMenu();
            comboBox8_1.ContextMenu = new ContextMenu();

            //      comboBox3.ContextMenu = new ContextMenu();

            textBox23.ContextMenu = new ContextMenu();
            textBox1.ContextMenu = new ContextMenu();

           

        }
  
        public void onvanGozaresh (){

           
            rb1 = radioButton1.Text + " " + comboBox1.Text + " " + label5.Text;
            rb2 = radioButton2.Text + " " + comboBox2.Text + " " + label5.Text;
            rb3 = radioButton3.Text + " " + comboBox3.Text + " " + label5.Text;              
            rb4 = radioButton4.Text + " " + comboBox4.Text + " " + label25.Text;
            rb5 = radioButton5.Text + " " + comboBox5.Text + " " + label6.Text;
            rb6 = radioButton6.Text + " " + comboBox6.Text + " " + label9.Text;
            rb7 = radioButton7.Text + " " + comboBox7.Text + " " + label5.Text;         
            rb8 = radioButton8.Text + " " + comboBox8_1.Text + " " + label3.Text + " " + comboBox8_2.Text + " " + label5.Text;
            rb9 = radioButton9.Text + " " + comboBox9.Text + " " + textBox23.Text + "/" + comboBox22.Text + "/" + comboBox21.Text + " " + label1.Text + " " + textBox1.Text + "/" + comboBox9.Text + "/" + comboBox10.Text + " " + label2.Text;                   
            rb10 = radioButton10.Text;
            rb11 = radioButton11.Text;
            rb12 = radioButton12.Text;
  


    
    }
   
 
        private void button2_Click(object sender, EventArgs e)
        {
           

            text13.Text = rb9;
        }

       

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.personelTableAdapter.FillBy(this.db20DataSet1.Personel);
            }
            catch (System.Exception ex)
            {
                
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }

        }





        public void ComboBox5_ReshteTah_BindingSource()
        {


            string str1 = "";

            try
            {

                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                con = new SqlConnection(str1);

                //  SqlCommand com = new SqlCommand("select رشته_تحصیلی from tah", con);

                con.Open();

                SqlCommand cmd = null;
                cmd = con.CreateCommand();
                cmd.CommandText = "select distinct رشته_تحصیلی from tah";

                SqlDataAdapter MyAdapter = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                MyAdapter.Fill(DS, "tah");
                con.Close();
      
            comboBox7.DataSource = DS.Tables["tah"];
            comboBox7.DisplayMember = "رشته_تحصیلی";
            //    comboBox5.ValueMember = "رشته_تحصیلی";

            }
            catch (Exception ex)
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }

        }
    
        
        public void ComboBox11_ReshteTah_BindingSource()
        {


            string str1 = "";


            try
            {

            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            con = new SqlConnection(str1);

            //  SqlCommand com = new SqlCommand("select رشته_تحصیلی from tah", con);

            con.Open();

            SqlCommand cmd = null;
            cmd = con.CreateCommand();
            cmd.CommandText = "select distinct شهر_اقامت from Personel";

            SqlDataAdapter MyAdapter = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            MyAdapter.Fill(DS, "Personel");
            con.Close();

            comboBox4.DataSource = DS.Tables["Personel"];
            comboBox4.DisplayMember = "شهر_اقامت";
            //    comboBox5.ValueMember = "رشته_تحصیلی";

               }
            catch (Exception ex)
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }


        public void BarrasiTarikhGozaresh()
        {

            if (comboBox13.Text != "" & comboBox12.Text != "" & textBox2.Text != "")
            {


                if (comboBox13.Text != "")
                {
                    int num1 = int.Parse(comboBox13.Text);

                    if (num1 >= 32 || comboBox13.Text == "00" || comboBox13.Text == "0")
                    {


                       
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ گزارش را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                        comboBox13.Text = "";

                    }

                }






                //برای اینکه عدد بزرگتر از 12 ماه وارد نشودو  ..و.و



                if (comboBox12.Text != "")
                {
                    int num2 = int.Parse(comboBox12.Text);

                    if (num2 >= 13 || comboBox12.Text == "00" || comboBox12.Text == "0")
                    {


                        
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ گزارش را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                        comboBox12.Text = "";

                    }
                }



                if (textBox2.Text != "")
                {
                    int num3 = int.Parse(textBox2.Text);
                    if (num3 <= 999 || textBox2.Text == "0000" || textBox2.Text == "000" || textBox2.Text == "00" || textBox2.Text == "0")
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ گزارش را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                        textBox2.Text = "";

                    }

                }


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{



            errorProvider1.Clear();

          
            BarrasiTarikhGozaresh();
            
       
                if (comboBox13.Text == "") errorProvider1.SetError(comboBox13, "   روز تاریخ گزارش را وارد نمایید");
                else if (comboBox12.Text == "") errorProvider1.SetError(comboBox12, "   ماه تاریخ گزارش را وارد نمایید");
                else if (textBox2.Text == "") errorProvider1.SetError(textBox2, "   سال تاریخ گزارش را وارد نمایید");

                else
                {


                 

                    //--------------------------------------------------------------------------------

                    onvanGozaresh();



                    //--------------------------تنظیم تاریخ گزارش---------------------

                    string str_rouz_G = "", str_mah_G = "", str_sal_G = "";

                    str_rouz_G = comboBox13.Text;
                    str_mah_G = comboBox12.Text;
                    str_sal_G = textBox2.Text;

                    string tarikh_G = str_sal_G + "/" + str_mah_G + "/" + str_rouz_G;

                    //------------------------------------------------------



                    if (radioButton1.Checked == true)
                    {
                        errorProvider1.Clear();


                        if (comboBox1.Text == "") errorProvider1.SetError(comboBox1, "  نوع عضویت را وارد نمایید");

                        else
                        {



                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_NovehOzviat.rdlc", " select * from Personel,ser,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'" + comboBox1.Text + "'   ", rb1, tarikh_G);
                            r.ShowDialog();


                        }
                    }


                    else if (radioButton2.Checked == true)
                    {

                        errorProvider1.Clear();


                        if (comboBox2.Text == "") errorProvider1.SetError(comboBox2, "  نوع شغل را وارد نمایید");

                        else
                        {


                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_NovehShoghl.rdlc", " select * from Personel,ser,shoghl where Personel.کد_عضویت=shoghl.کد_عضویت  and shoghl.نوع_شغل = N'" + comboBox2.Text + "' ", rb2, tarikh_G);
                            r.ShowDialog();

                        }
                    }


                    else if (radioButton3.Checked == true)
                    {
                        errorProvider1.Clear();


                        if (comboBox3.Text == "") errorProvider1.SetError(comboBox3, "نام بخش را مشخص نمایید");

                        else
                        {

                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_BakhshOzviat.rdlc", " select * from Personel,ser,faal where Personel.کد_عضویت=faal.کد_عضویت  and faal.موضوع_فعالیت =N'" + comboBox3.Text + "' ", rb3, tarikh_G);
                            r.ShowDialog();

                        }


                    }


                    else if (radioButton4.Checked)
                    {
                        //SearchDB("select * from Personel where شهر_اقامت ='" + comboBox11.Text + "' ");

                        errorProvider1.Clear();


                        if (comboBox4.Text == "") errorProvider1.SetError(comboBox4, " شهر محل اقامت را وارد نمایید");

                        else
                        {

                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_ShareEghamat.rdlc", " select * from Personel,ser where شهر_اقامت ='" + comboBox4.Text + "' ", rb4, tarikh_G);
                            r.ShowDialog();

                        }


                    }


                    else if (radioButton5.Checked == true)
                    {

                        errorProvider1.Clear();


                        if (comboBox5.Text == "") errorProvider1.SetError(comboBox5, " میزان تحصیلات را وارد نمایید");

                        else
                        {


                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_MizaneTahsilat.rdlc", " select * from Personel,ser,tah where Personel.کد_عضویت=tah.کد_عضویت  and tah.میزان_تحصیلات =N'" + comboBox5.Text + "' ", rb5, tarikh_G);
                            r.ShowDialog();

                        }

                    }




                    else if (radioButton6.Checked == true)
                    {
                        errorProvider1.Clear();


                        if (comboBox6.Text == "") errorProvider1.SetError(comboBox6, "   ,وضعیت تأهل را وارد نمایید");

                        else
                        {



                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_VazeiatTaholl.rdlc", " select * from Personel,ser where وضعیت_تاهل ='" + comboBox6.Text + "' ", rb6, tarikh_G);
                            r.ShowDialog();
                        }

                    }


                    else if (radioButton7.Checked == true)
                    {
                        errorProvider1.Clear();


                        if (comboBox7.Text == "") errorProvider1.SetError(comboBox7, "  رشته تحصیلی را وارد نمایید");

                        else
                        {

                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_p_Reshtetah.rdlc", " select * from Personel,ser,tah where Personel.کد_عضویت=tah.کد_عضویت  and tah.رشته_تحصیلی like N'" + comboBox7.Text + "' ", rb7, tarikh_G);
                            r.ShowDialog();

                        }
                    }



                    else if (radioButton8.Checked == true)
                    {
                        errorProvider1.Clear();


                        if (comboBox8_1.Text == "") errorProvider1.SetError(comboBox8_1, " شماره عضویت ابتدا وارد نمایید");
                        else if (comboBox8_2.Text == "") errorProvider1.SetError(comboBox8_2, " شماره عضویت انتها وارد نمایید");

                        else
                        {

                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_ListKol.rdlc", "select * from Personel,ser,Sabt_ozv where Personel.کد_عضویت= Sabt_ozv.کد_عضویت and Personel.کد_عضویت between '" + comboBox8_1.Text + "' and '" + comboBox8_2.Text + "'", rb8, tarikh_G);
                            r.ShowDialog();
                        }
                    }




                    //----------radioButton9----------------







                    else if (radioButton9.Checked == true)
                    {







                        BarrasiFieldTarikhi();

                        errorProvider1.Clear();


                        if (comboBox13.Text == "") errorProvider1.SetError(comboBox13, " روز تاريخ اول تولد را وارد کنيد");
                        else if (comboBox12.Text == "") errorProvider1.SetError(comboBox12, " ماه تاريخ اول را وارد کنيد");
                        else if (textBox2.Text == "") errorProvider1.SetError(textBox2, " سال تاريخ اول را وارد کنيد");
                        else if (comboBox21.Text == "") errorProvider1.SetError(comboBox21, " روز تاريخ اول تولد را وارد کنيد");
                        else if (comboBox22.Text == "") errorProvider1.SetError(comboBox22, " ماه تاريخ اول را وارد کنيد");
                        else if (textBox23.Text == "") errorProvider1.SetError(textBox23, " سال تاريخ اول را وارد کنيد");

                        else if (comboBox10.Text == "") errorProvider1.SetError(comboBox10, " روز تاريخ دوم را وارد کنيد");
                        else if (comboBox9.Text == "") errorProvider1.SetError(comboBox9, " ماه تاريخ دوم را وارد کنيد");
                        else if (textBox1.Text == "") errorProvider1.SetError(textBox1, " سال تاريخ دوم را وارد کنيد");

                        else
                        {

                            //--------------------------------تاریخ اول--------------------------
                            string str_rouz = "", str_mah = "", str_sal = "";

                            str_rouz = comboBox21.Text;
                            str_mah = comboBox22.Text;
                            str_sal = textBox23.Text;

                            string tarikh1 = str_sal + "/" + str_mah + "/" + str_rouz;

                            //----------------------------------تاریخ دوم----------------
                            string str_rouz2 = "", str_mah2 = "", str_sal2 = "";

                            str_rouz2 = comboBox10.Text;
                            str_mah2 = comboBox9.Text;
                            str_sal2 = textBox1.Text;

                            string tarikh2 = str_sal2 + "-" + str_mah2 + "-" + str_rouz2;
                            //-----------------------------------------------------------------------------------


                            Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_p_TarikhOzviat.rdlc", " select * from Personel,ser,Sabt_ozv where Personel.کد_عضویت= Sabt_ozv.کد_عضویت and Sabt_ozv.تاریخ_عضویت between '" + tarikh1 + "' and '" + tarikh2 + "' ", rb9, tarikh_G);
                            r.ShowDialog();

                        }

                    }


                  //-----------------------------



                    else if (radioButton10.Checked == true)
                    {

                        Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_ListKol.rdlc", " select * from Personel,ser  ", rb10, tarikh_G);
                        r.ShowDialog();

                    }

                    else if (radioButton11.Checked == true)
                    {

                        Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_jensiat.rdlc", " select * from Personel,ser where جنسیت='مذکر' ", rb11, tarikh_G);
                        r.ShowDialog();

                    }

                    else if (radioButton12.Checked == true)
                    {
                        Report2 r = new Report2("..\\Debug\\rpt\\rpt2\\Report_jensiat.rdlc", " select * from Personel,ser where جنسیت='موئنث' ", rb12, tarikh_G);
                        r.ShowDialog();

                    }


                    else
                    {

                       
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ انتخابی برای عملیات گزارش صورت نگرفته است", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                    }


                }




            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (comboBox13.Text != "" && comboBox12.Text != "" && text10.Text.Length == 4)
            {

                button3.Enabled = true;
            
            }


        }



        public void BarrasiFieldTarikhi()
        {

 


             
                //برای اینکه عدد بزرگتر از 31 روز وارد نشود..و.و

          
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------

                //-------------------------------------------------برای بررسی تاریخ اول--------

                //برای اینکه عدد بزرگتر از 31 روز وارد نشود..و.و

                if (comboBox21.Text != "")
                {
                    int num1 = int.Parse(comboBox21.Text);

                    if (num1 >= 32 || comboBox21.Text == "00" || comboBox21.Text == "0")
                    {


                       
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ اول را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                        comboBox21.Text = "";

                    }

                }






                //برای اینکه عدد بزرگتر از 12 ماه وارد نشودو  ..و.و



                if (comboBox22.Text != "")
                {
                    int num2 = int.Parse(comboBox22.Text);

                    if (num2 >= 13 || comboBox22.Text == "00" || comboBox22.Text == "0")
                    {


                        MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ اول را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
 
                        comboBox22.Text = "";

                    }
                }



                if (textBox23.Text != "")
                {
                    int num3 = int.Parse(textBox23.Text);
                    if (num3 <= 999 || textBox23.Text == "0000" || textBox23.Text == "000" || textBox23.Text == "00" || textBox23.Text == "0")
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ اول را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                         textBox23.Text = "";

                    }

                }

                //-----------------------------------------------------------------------------------------


                //-------------------------------------------------برای بررسی تاریخ عضویت--------

                //برای اینکه عدد بزرگتر از 31 روز وارد نشود..و.و

                if (comboBox10.Text != "")
                {
                    int num1 = int.Parse(comboBox10.Text);

                    if (num1 >= 32 || comboBox10.Text == "00" || comboBox10.Text == "0")
                    {


                        MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ دوم را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                         comboBox10.Text = "";

                    }

                }






                //برای اینکه عدد بزرگتر از 12 ماه وارد نشودو  ..و.و



                if (comboBox9.Text != "")
                {
                    int num2 = int.Parse(comboBox9.Text);

                    if (num2 >= 13 || comboBox9.Text == "00" || comboBox9.Text == "0")
                    {


                        MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ دوم را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                    
                        comboBox9.Text = "";

                    }
                }



                if (textBox1.Text != "")
                {
                    int num3 = int.Parse(textBox1.Text);
                    if (num3 <= 999 || textBox23.Text == "0000" || textBox1.Text == "000" || textBox1.Text == "00" || textBox1.Text == "0")
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ دوم را صحیح وارد نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
          
                        textBox1.Text = "";

                    }

                
            }


        }

    
        private void comboBox21_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {

                e.Handled = true;
            
            }
        
        }

        private void comboBox22_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }

            else

            {

                e.Handled = true;

            
            }
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else

            {

                e.Handled = true;

            }
        }

        private void comboBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {


                e.Handled = true;

            }

        }

        private void comboBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {


                e.Handled = true;

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {


                e.Handled = true;

            }

        }

        private void comboBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {


                e.Handled = true;

            }

        }

        private void comboBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {


                e.Handled = true;

            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {


                e.Handled = true;

            }

        }

        private void comboBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {


                e.Handled = true;

            }

        }

        private void comboBox8_KeyPress(object sender, KeyPressEventArgs e)
        {


            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;

            }

            else
            {

                e.Handled = true;

            }



        }

 

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void comboBox7_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try{

            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ااا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;

        
        
            }
            catch (Exception)
            {
                
                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

            }
        
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
    
            try{
            
            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ااا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;

            
            }
            catch (Exception)
            {
                
                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

            }


        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            try{

            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ااا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;



            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try{

            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
            try{
            
            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }
     
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            try{
            
            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }

            }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            try{

            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            try{
            
            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

            }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            try{
            
            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }
        
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
        
            try{
            
            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;

            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            
            try{

            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            
            try {

            DataView dv;

            dv = cmdsql.vt("select  Personel.کد_عضویت as ا  from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Sabt_ozv.نوع_عضویت =N'' ");

            dataGridView1.DataSource = dv;

            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }

        }

 
        
    }
}
