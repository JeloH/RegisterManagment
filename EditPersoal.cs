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
    public partial class EditPersoal : Form
    {
        public EditPersoal()
        {
            InitializeComponent();
        }

  


 
        string cmdAccess;

        Class_mft clmft = new Class_mft();


        

public string CmdAccess
{
  get { return cmdAccess; }
  set { cmdAccess = value; }

}
SqlDataAdapter da=new SqlDataAdapter();
cldbSql cmdsql = new cldbSql();
SqlConnection con;
CurrencyManager cm;
SqlCommand com;
DataSet ds;




        public void Tload(string st) {

            try
            {

            


                DataView dv;
                dv = cmdsql.vt(st);
                dataGridView1.DataSource = dv;

                //dataGridView1.DataSource = ds;
                //dataGridView1.DataMember = ds.Tables[0].TableName;
        
                
                
                textBox_1.DataBindings.Add("Text", dv, "کد_عضویت");
     
                textBox_2.DataBindings.Add("Text", dv, "نام");
                textBox_3.DataBindings.Add("Text", dv, "فامیلی");
                textBox_4.DataBindings.Add("Text", dv, "نام_پدر");


               
                ///-------------------صحیح نشان دان تاریخ تولد روز/ماه/سال------------

                // maskedTextBox1.DataBindings.Add("Text", dv, "تاریخ_تولد");

                //Binding b = new Binding("Text", dv, "تاریخ_تولد", true);
            //    b.FormatString = "yyyy/MM/dd";
           //     b.FormatString = "yyyy/MM/dd hh:mm tt";

                maskedTextBox1.DataBindings.Add("Text", dv, "تاریخ_تولد");  

                ///--------------------------------------
             

               
                textBox_5.DataBindings.Add("Text", dv, "شماره_شناسنامه");
                textBox_6.DataBindings.Add("Text", dv, "کد_ملی");
                
        label17.DataBindings.Add("Text", dv, "کد_ملی");

                textBox_7.DataBindings.Add("Text", dv, "شهر_اقامت");
                textBox_11.DataBindings.Add("Text", dv, "مذهب");
                textBox_9.DataBindings.Add("Text", dv, "تابعیت");
                textBox_10.DataBindings.Add("Text", dv, "پست_الکترونیکی");
                textBox_8.DataBindings.Add("Text", dv, "تلفن_همراه");
                textBox_12.DataBindings.Add("Text", dv, "آدرس");
                comboBox1.DataBindings.Add("Text", dv, "وضعیت_تاهل");

               comboBox2.DataBindings.Add("Text", dv, "جنسیت");



           //    textBox4.DataBindings.Add("Text", dv, "آدرس_عکس");

             pictureBox1.DataBindings.Add("image", dv, "عکس", true);

               
               cm = (CurrencyManager)BindingContext[dv];

            }
            catch (Exception er)
            {
         
            
                MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message, "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
          }
        }



        public void Tload2(string st)
        {

            try
            {

                DataView dv;
                dv = cmdsql.vt(st);
                dataGridView1.DataSource = dv;
 

            }
            catch (Exception er)
            {
               
                 MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message, "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
      
            }
        }



        private void EditPersoal_Load(object sender, EventArgs e)
        {
           
            Disable_RightClick_Menu_Field();

         

            cldbSql.CallDB("delete from Personel where کد_عضویت='"+""+"'");

     
        }


        public void Disabe_TextBox_Combobax()
        {

            textBox_1.Enabled = false;
            textBox_2.Enabled = false;
            textBox_3.Enabled = false;
            textBox_4.Enabled = false;
            textBox_5.Enabled = false;
            textBox_6.Enabled = false;
            textBox_7.Enabled = false;

            textBox_8.Enabled = false;
            textBox16.Enabled = false;

            textBox_9.Enabled = false;
            textBox_10.Enabled = false;
            textBox_11.Enabled = false;
            textBox_12.Enabled = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;

            maskedTextBox1.Enabled = false;

            button1.Enabled = false;

        }

        public void Enable_TextBox_Combobax()
        {

            textBox_1.Enabled = true;
            textBox_2.Enabled = true;
            textBox_3.Enabled = true;
            textBox_4.Enabled = true;
            textBox_5.Enabled = true;
            textBox_6.Enabled = true;
            textBox_7.Enabled = true;

            textBox_8.Enabled = true;
            textBox16.Enabled = true;

            textBox_9.Enabled = true;
            textBox_10.Enabled = true;
            textBox_11.Enabled = true;
            textBox_12.Enabled = true;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;

            maskedTextBox1.Enabled = true;

            button1.Enabled = true;


        }


        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            try{
            string str1 = "";

            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
             con = new SqlConnection(str1);
            SqlCommand com = new SqlCommand("select * from sft where CodeNarmAfzar=N'" + textBox_2.Text + "'", con);


             ds = new DataSet();
              da = new SqlDataAdapter(com);
            da.Fill(ds);



            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }



        public bool BarrasiTarikh() {

            int rouz_int, mah_int, sall_int;
            string temp, rouz, mah, sall;

            bool bf = true;

            temp = maskedTextBox1.Text;


            if (temp.Length!=10)
            {

                bf = false;

                //طول تاریخ عمراه با عدد با مویز 10 تا کارکتر است پس باید کمتر یا بیشتر نباشد
            }

            else
            {



                rouz = temp.Substring(8, 2);

                mah = temp.Substring(5, 2);

                sall = temp.Substring(0, 4);
                ///----------------------------------نمایش تاریخ تولد------

                //  comboBox11.Text = rouz;

                //   comboBox22.Text = mah;

                //  textBox51.Text = sall;


                //textBox15.Text = sall + "/" + mah + "/" + rouz;

                rouz_int = int.Parse(rouz);
                mah_int = int.Parse(mah);
                sall_int = int.Parse(sall);


                if (rouz_int >= 32 || rouz_int==00)
                {

                    bf = false;
                   
                 
                     MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ تولد را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }



                if (mah_int >= 13 || mah_int == 00)
                {

                    bf = false;
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ تولد را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }



                if (sall_int <= 999 || sall_int == 0000)
                {

                    bf = false;
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ تولد را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }

            }
            return bf;
        }



        public void BarrasiFieldTell(){
            
            errorProvider1.Clear();



        }





        private void button5_Click(object sender, EventArgs e)
        {
            try{

            errorProvider1.Clear();


            if (textBox_8.Text.StartsWith("0") == true)
            {
                errorProvider1.SetError(textBox_8, " شماره تلفن_همراه همراه  را (بدون صفر) کامل و صحیح وارد کنيد");

            }

           
            else if (BarrasiTarikh() == false) {

                errorProvider1.SetError(maskedTextBox1, " تاریخ تولد را صحیح وارد نمایید ");

            
            }

            else if (textBox_10.Text !="" && clmft.BarrasiFieldEmail(textBox_10.Text) == false)
            {

                errorProvider1.SetError(textBox_10, " رایانامه را صحیح وارد نمایید");
              
                textBox_10.Text = "";


            }



            else if (textBox_6.Text.Length <= 9)
            {
                 

               errorProvider1.SetError(textBox_6, "کد ملی 10 رقمی را صحیح وارد نمایید");

            }


            else

            {

            ///---------------------------------------------

                        
            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
              con = new SqlConnection(str1);

            con.Open();
            //جلوگیری از تکرار کد_ملی
            string s1 = " select * from Personel where کد_ملی='"+textBox_6.Text+"'  ";
              da = new SqlDataAdapter(s1, con);
            DataTable dt = new DataTable();
             
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {

                //----------این کدملی اصلا وجود ندارد -------------------------------------


                cldbSql.CallDB("update Personel set نام= N'" + textBox_2.Text + "',فامیلی=N'" + textBox_3.Text + "',نام_پدر=N'" + textBox_4.Text + "',تاریخ_تولد=N'" + maskedTextBox1.Text + "',شماره_شناسنامه=N'" + textBox_5.Text + "',کد_ملی=N'" + textBox_6.Text + "',شهر_اقامت=N'" + textBox_7.Text + "',مذهب=N'" + textBox_11.Text + "',تابعیت=N'" + textBox_9.Text + "',وضعیت_تاهل='" + comboBox1.Text + "',پست_الکترونیکی=N'" + textBox_10.Text + "',تلفن_همراه=N'" + textBox_8.Text + "',جنسیت=N'" + comboBox2.Text + "',آدرس=N'" + textBox_12.Text + "',آدرس_عکس=N'" + textBox4.Text + "' where کد_عضویت=N'" + textBox_1.Text + "'  ");


                cm.EndCurrentEdit();


                //-----------------------------------------------------------------------


            }


            else
            {

                //-------------این کدملی وجود داردکه همان کد ملی وارد شده ثبت نام می باشد
                //--------------------------------درحالتی که کد ملی نمایش روی text6 می باشد-------------------------------

                if (label17.Text != textBox_6.Text)
                {


                     
                     MsgBox.ShowMessage(this.Handle.ToInt32(), "کد ملی تکراری می باشد" , "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                    textBox_6.Text = label17.Text;

                }
                else
                {


                    cldbSql.CallDB("update Personel set نام= N'" + textBox_2.Text + "',فامیلی=N'" + textBox_3.Text + "',نام_پدر=N'" + textBox_4.Text + "',تاریخ_تولد=N'" + maskedTextBox1.Text + "',شماره_شناسنامه=N'" + textBox_5.Text + "',کد_ملی=N'" + textBox_6.Text + "',شهر_اقامت=N'" + textBox_7.Text + "',مذهب=N'" + textBox_11.Text + "',تابعیت=N'" + textBox_9.Text + "',وضعیت_تاهل='" + comboBox1.Text + "',پست_الکترونیکی=N'" + textBox_10.Text + "',تلفن_همراه=N'" + textBox_8.Text + "',جنسیت=N'" + comboBox2.Text + "',آدرس=N'" + textBox_12.Text + "',آدرس_عکس=N'" + textBox4.Text + "' where کد_عضویت=N'" + textBox_1.Text + "'  ");

                    cm.EndCurrentEdit();


                    //-----------------------------------------------------------------------


                }



            }


            }
                 }
                catch (Exception ex)
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }

 

            }
            
    

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        public void DataBindingClear() {
            textBox_2.DataBindings.Clear();
            textBox_3.DataBindings.Clear();
            textBox_4.DataBindings.Clear();
            maskedTextBox1.DataBindings.Clear();
            textBox_5.DataBindings.Clear();
            textBox_6.DataBindings.Clear();
            textBox_7.DataBindings.Clear();
            textBox_11.DataBindings.Clear();
            textBox_9.DataBindings.Clear();
            textBox_10.DataBindings.Clear();
            textBox_8.DataBindings.Clear();
            textBox_12.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
         //   comboBox2.DataBindings.Clear();

     label17.DataBindings.Clear();

            textBox_1.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();


        }



        public void DataBindingAdd(DataView dv)
        {


            textBox_2.DataBindings.Add("Text", dv, "نام");
            textBox_3.DataBindings.Add("Text", dv, "فامیلی");
            textBox_4.DataBindings.Add("Text", dv, "نام_پدر");
          
           // Binding b = new Binding("Text", dv, "تاریخ_تولد", true);
          //  b.FormatString = "yyyy/MM/dd";
            //     b.FormatString = "yyyy/MM/dd hh:mm tt";

            maskedTextBox1.DataBindings.Add("Text", dv, "تاریخ_تولد"); 
            textBox_5.DataBindings.Add("Text", dv, "شماره_شناسنامه");
            textBox_6.DataBindings.Add("Text", dv, "کد_ملی");
            textBox_7.DataBindings.Add("Text", dv, "شهر_اقامت");
            textBox_11.DataBindings.Add("Text", dv, "مذهب");
            textBox_9.DataBindings.Add("Text", dv, "تابعیت");
            textBox_10.DataBindings.Add("Text", dv, "پست_الکترونیکی");
            textBox_8.DataBindings.Add("Text", dv, "تلفن_همراه");
            textBox_12.DataBindings.Add("Text", dv, "آدرس");
            comboBox1.DataBindings.Add("Text", dv, "وضعیت_تاهل");
            //comboBox2.DataBindings.Add("Text", dv, "جنسیت");

  label17.DataBindings.Add("Text", dv, "کد_ملی");

            textBox_1.DataBindings.Add("Text", dv, "کد_عضویت");

            //textBox4.DataBindings.Add("Text", dv, "آدرس_عکس");
            pictureBox1.DataBindings.Add("image", dv, "عکس", true);
        }

        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {


        }


        public void SearchDB(string str)
        {
            try
            {

                DataBindingClear();

                DataView dv;
                dv = cmdsql.vt(str);

                dataGridView1.DataSource = dv;

                this.dataGridView1.Columns["عکس"].Visible = false;// عدم نمایش ستون عکس
      
                DataBindingAdd(dv);


                // DataBindingAdd(dv);

                cm = (CurrencyManager)BindingContext[dv];
            }
            catch (Exception ex)
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }


        private void textBox15_TextChanged_1(object sender, EventArgs e)
        {
            

            SearchDB("SELECT  کد_عضویت  ,نام,فامیلی ,نام_پدر ,تاریخ_تولد,شماره_شناسنامه,کد_ملی ,شهر_اقامت,مذهب,تابعیت,پست_الکترونیکی,تلفن_همراه ,وضعیت_تاهل,جنسیت,آدرس,آدرس_عکس FROM Personel where فامیلی like N'%" + textBox15.Text + "%' order by کد_عضویت");   

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

                textBox4.Text = dlg.FileName;

            }

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }

   
        
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

      

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

   



        public void Disable_RightClick_Menu_Field()
        {


            // غیر فعال کردن راست کلیک

            maskedTextBox1.ContextMenu = new ContextMenu();
            textBox_6.ContextMenu = new ContextMenu();

            textBox_8.ContextMenu = new ContextMenu();

            comboBox1.ContextMenu = new ContextMenu();
            comboBox2.ContextMenu = new ContextMenu();




        }

    

      

        private void button3_Click_1(object sender, EventArgs e)
        {
            //
           
             this.Close();
        }
 


        private void button5_Click_1(object sender, EventArgs e)
        {


            if (textBox_1.Text != "")
            {





                errorProvider1.Clear();


                if (textBox_8.Text.StartsWith("0") == true)
                {
                    errorProvider1.SetError(textBox_8, " شماره تلفن_همراه همراه  را (بدون صفر) کامل و صحیح وارد کنيد");

                }


                else if (BarrasiTarikh() == false)
                {

                    errorProvider1.SetError(maskedTextBox1, " تاریخ عضویت را صحیح وارد نمایید . مثلا :" + " " + "1391/03/28");

                     
                     MsgBox.ShowMessage(this.Handle.ToInt32(), " تاریخ عضویت را صحیح وارد نمایید . مثلا :" + " " + "1391/03/28", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }

                else if (textBox_10.Text != "" && clmft.BarrasiFieldEmail(textBox_10.Text) == false)
                {

                    errorProvider1.SetError(textBox_10, " رایانامه را صحیح وارد نمایید");

                    textBox_10.Text = "";


                }



                else if (textBox_6.Text.Length <= 9)
                {


                    errorProvider1.SetError(textBox_6, "کد ملی 10 رقمی را صحیح وارد نمایید");

                }


                else
                {

                    ///---------------------------------------------

                    try
                    {

                        string str1 = "";
                        str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                        con = new SqlConnection(str1);

                        con.Open();
                        //جلوگیری از تکرار کد_ملی

                        string s1 = " select * from Personel where کد_ملی='" + textBox_6.Text + "'  ";
                        da = new SqlDataAdapter(s1, con);
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {

                            //----------این کدملی اصلا وجود ندارد -------------------------------------

                            byte[] imageData = Class_mft.ReadFile(textBox4.Text);
                            cldbSql.CallDB("update Personel set نام= N'" + textBox_2.Text + "',فامیلی=N'" + textBox_3.Text + "',نام_پدر=N'" + textBox_4.Text + "',تاریخ_تولد=N'" + maskedTextBox1.Text + "',شماره_شناسنامه=N'" + textBox_5.Text + "',کد_ملی=N'" + textBox_6.Text + "',شهر_اقامت=N'" + textBox_7.Text + "',مذهب=N'" + textBox_11.Text + "',تابعیت=N'" + textBox_9.Text + "',وضعیت_تاهل='" + comboBox1.Text + "',پست_الکترونیکی=N'" + textBox_10.Text + "',تلفن_همراه=N'" + textBox_8.Text + "',جنسیت=N'" + comboBox2.Text + "',آدرس=N'" + textBox_12.Text + "' where کد_عضویت=N'" + textBox_1.Text + "'  ");

                            UpdatePicturePersonel();

                            cm.EndCurrentEdit();


                            //-----------------------------------------------------------------------


                        }


                        else
                        {

                            //-------------این کدملی وجود داردکه همان کد ملی وارد شده ثبت نام می باشد
                            //--------------------------------درحالتی که کد ملی نمایش روی text6 می باشد-------------------------------

                            if (label17.Text != textBox_6.Text)
                            {



                                MsgBox.ShowMessage(this.Handle.ToInt32(), "کد ملی تکراری می باشد", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


                                textBox_6.Text = label17.Text;

                            }
                            else
                            {

                                //byte[] imageData = Class_mft.ReadFile(textBox4.Text);
                                cldbSql.CallDB("update Personel set نام= N'" + textBox_2.Text + "',فامیلی=N'" + textBox_3.Text + "',نام_پدر=N'" + textBox_4.Text + "',تاریخ_تولد=N'" + maskedTextBox1.Text + "',شماره_شناسنامه=N'" + textBox_5.Text + "',کد_ملی=N'" + textBox_6.Text + "',شهر_اقامت=N'" + textBox_7.Text + "',مذهب=N'" + textBox_11.Text + "',تابعیت=N'" + textBox_9.Text + "',وضعیت_تاهل='" + comboBox1.Text + "',پست_الکترونیکی=N'" + textBox_10.Text + "',تلفن_همراه=N'" + textBox_8.Text + "',جنسیت=N'" + comboBox2.Text + "',آدرس=N'" + textBox_12.Text + "' where کد_عضویت=N'" + textBox_1.Text + "'  ");

                                UpdatePicturePersonel();

                                cm.EndCurrentEdit();


                                //-----------------------------------------------------------------------


                            }



                        }

                    }

                    catch (Exception ex)
                    {
                        MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    }


                    button5.Visible = false;
                    button8.Visible = true;

                    groupBox7.Enabled = true;


                    Disabe_TextBox_Combobax();

                    dataGridView1.Enabled = true;
         


                }





            }



            else

            {
 
                 MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ سطری انتخاب نشده است", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

            }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            if (textBox_1.Text != "")
            {
                //MessageBoxFrmEx.Show("آیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شود؟", "حذف اعضا", MessageBoxButtons.YesNo);


                if (MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا عملیات حذف انجام شود ؟", "حذف اعضا", "بله", "خیر", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes)
                {
             

                try
                {

                    string str1 = "";
                    str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                    SqlConnection con = new SqlConnection(str1);
                    SqlCommand com = con.CreateCommand();
                    com.CommandText = "delete from Personel where  کد_عضویت=N'" + textBox_1.Text + "'";

                    com.CommandType = CommandType.Text;

                    DataSet ds = new DataSet();

                    SqlDataAdapter da = new SqlDataAdapter(com);

                    SqlCommandBuilder comb = new SqlCommandBuilder(da);

                    da.Fill(ds);



                    textBox_2.Text = "";
                    textBox_3.Text = "";
                    textBox_4.Text = "";
                    maskedTextBox1.Text = "";
                    textBox_5.Text = "";
                    textBox_6.Text = "";
                    textBox_7.Text = "";
                    textBox_11.Text = "";
                    textBox_9.Text = "";
                    textBox_10.Text = "";
                    textBox_8.Text = "";
                    textBox_12.Text = "";
                    textBox13.Text = "";
                    textBox_1.Text = "";


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

     public void UpdatePicturePersonel()
     
     {
         //به خاطر این نوشته شده تا زمانی که آدرس عکس  جدید داده شد عملیات بروزرسانی انجام شود if
         //اگر نباشد خطا بوجود می آید if 

         try{


         if (textBox4.Text != "")
         {


             string str1 = "";
             str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
             SqlConnection CN = new SqlConnection(str1);

             string qry = "update Personel set آدرس_عکس=@Address_aks,عکس=@aks where کد_عضویت=N'" + textBox_1.Text + "'  ";




             SqlCommand cmd = new SqlCommand(qry, CN);



             byte[] imageData = Class_mft.ReadFile(textBox4.Text);

             cmd.Parameters.Add("@aks", SqlDbType.VarBinary).Value = imageData;//برای به روز رسانی یا برای نماش عکس نیاز به وجود آدرس عکس نمی باشد همان فیلد باینری کافی می باشد
           //  cmd.Parameters.Add("@Address_aks", SqlDbType.NVarChar).Value = textBox4.Text;//



             CN.Open();

             cmd.ExecuteNonQuery();

             CN.Close();

         }
           
          }
                catch (Exception)
                {
 
                     MsgBox.ShowMessage(this.Handle.ToInt32(), "دیگر انتخابی برای حذف وجود ندارد ", "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }

        }


     private void button2_Click_1(object sender, EventArgs e)
     { 

         byte[] imageData = Class_mft.ReadFile(textBox4.Text);

         textBox15.Text =Class_mft.binaryToHexString(imageData);

     }

     private void radioButton2_CheckedChanged(object sender, EventArgs e)
     {
         
         groupBox7.Enabled = false;
         label25.Enabled = false;

         label26.Enabled = true;
         groupBox9.Enabled = true;


         textBox17.Text = "";
         textBox18.Text = "";
         textBox19.Text = "";
         textBox20.Text = "";


          

         SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N'' ");

         Clear_ViewMoeshekhasatePersonel();
      


     }



     public void Clear_ViewMoeshekhasatePersonel() {

         textBox_2.Clear();
         textBox_3.Clear();
         textBox_4.Clear();
         maskedTextBox1.Clear();
         textBox_5.Clear();
         textBox_6.Clear();
         textBox_7.Clear();
         textBox_11.Clear();
         textBox_9.Clear();
         textBox_10.Clear();
         textBox_8.Clear();
         textBox_12.Clear();
         //  comboBox1.Clear();
         //   comboBox2.DataBindings.Clear();
         textBox_1.Clear();
         pictureBox1.Image = null;
     }


     private void radioButton1_CheckedChanged(object sender, EventArgs e)
     {
         

         groupBox9.Enabled = false;
         label25.Enabled = true;

         label26.Enabled = false;
         groupBox7.Enabled = true;

         textBox15.Text = "";
         textBox13.Text = "";


     

         SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N''");

         Clear_ViewMoeshekhasatePersonel();
     }

   
     private void button6_Click_2(object sender, EventArgs e)
     {
         if (textBox13.Text != "" & textBox15.Text != "")
         {

             

             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where نام = N'" + textBox15.Text + "' and فامیلی  = N'" + textBox13.Text + "'");

             
         }

         else
         {

              
             MsgBox.ShowMessage(this.Handle.ToInt32(), " برای جستجو سبک 2 ، باید نام و فامیلی هر دو نوشته شوند", "توجه", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

         }

     
     }


     private void textBox17_TextChanged(object sender, EventArgs e)
     {
         if (textBox17.Text != "")
         {
             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت like N'%" + textBox17.Text + "%'");
         }
         else
         {

             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N'' ");
             Clear_ViewMoeshekhasatePersonel();
         }

 

      
     }

     private void textBox18_TextChanged(object sender, EventArgs e)
     {
         if (textBox18.Text != "")
         {
             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_ملی like N'%" + textBox18.Text + "%'");
         }
         else
         {

             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N'' ");
             Clear_ViewMoeshekhasatePersonel();
         }


      
     }

     private void textBox20_TextChanged(object sender, EventArgs e)
     {
         if (textBox20.Text != "")
         {
             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where نام like N'%" + textBox20.Text + "%'");
         }
         else {

             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N'' ");
             Clear_ViewMoeshekhasatePersonel();
         }

        
               
     }

     private void textBox19_TextChanged(object sender, EventArgs e)
     {
         if (textBox19.Text != "")
         {
             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where فامیلی like N'%" + textBox19.Text + "%'");
      
         }
         else
         {

             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel where کد_عضویت = N'' ");
             Clear_ViewMoeshekhasatePersonel();
         }


        
     }

  
    

     private void textBox17_Enter(object sender, EventArgs e)
     {
         textBox18.Text = "";
         textBox19.Text = "";

         textBox20.Text = "";
         
     }

     private void textBox18_Enter(object sender, EventArgs e)
     {
         textBox17.Text = "";

         textBox19.Text = "";
         textBox20.Text = "";

     }


     private void textBox19_Enter(object sender, EventArgs e)
     {
         textBox17.Text = "";
         textBox18.Text = "";

         textBox20.Text = "";

     }





     private void textBox20_Enter(object sender, EventArgs e)
     {

         textBox17.Text = "";
         textBox18.Text = "";
         textBox19.Text = "";


     }



     private void button7_Click(object sender, EventArgs e)
     {
                          
         SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس  from Personel ");
        
     }

     private void button8_Click(object sender, EventArgs e)
     {
         if (textBox_1.Text != "")
         {
             button5.Visible = true;
              
             button8.Visible = false;
             dataGridView1.Enabled = false;

             groupBox7.Enabled = false;


             Enable_TextBox_Combobax();
         }

         else

         {
             MsgBox.ShowMessage(this.Handle.ToInt32(), " هیچ سطری انتخاب نشده است", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
             

         }
     }


        
       
    }
}


