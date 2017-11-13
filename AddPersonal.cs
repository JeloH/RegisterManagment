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
    public partial class AddPersonal : Form
    {
        public AddPersonal()
        {
          
            InitializeComponent();

            comboBox21.MaxLength = 2;
            comboBox22.MaxLength = 2;

            comboBox4.MaxLength = 2;
            comboBox8.MaxLength = 2;


          
        }
 
        


        int t21 = 0;
        public int t21t = 0;
        public int z = 0;

        DataView dv;
        SqlConnection con;
        CurrencyManager cm;

        Class_mft clmft = new Class_mft();


        private void AddPersonal_Load(object sender, EventArgs e)
        {

          
            //  commdAccess("select * from Personel where کد_عضویت=(select max(کد_عضویت) from Personel)");

            commdAccess("select max(کد_عضویت)+1 as آخرین from Personel");
            //cm.Refresh();
             Disable_RightClick_Menu_Field();

        }




        public void commdAccess(string str)
        {

            try
            {

                string str1 = "";

                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection con = new SqlConnection(str1);
                SqlCommand com = new SqlCommand(str, con);


                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);



                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables[0].TableName;

                dv = new DataView(ds.Tables[0]);
                //dataGridView1.DataSource = dv;


                textBox21.DataBindings.Add("Text", dv, "آخرین");



                cm = (CurrencyManager)BindingContext[dv];
            }

            catch(Exception ex){

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            
            }
        }

        public void textKhali()
        {
            if (textBox21.Text == "")

            textBox21.Text = "1000000";//شروع شماره عضویت از عدد
          
        }


        public void BarrasiFieldTarikhi() {


            if (textBox21.Text != null)//اگر  فیلد شماره کدعضویت پر بود
            {




                //-------------------------------------------------برای بررسی تاریخ تولد--------

                //برای اینکه عدد بزرگتر از 31 روز وارد نشود..و.و

                if (comboBox21.Text != "")
                {
                    int num1 = int.Parse(comboBox21.Text);

                    if (num1 >= 32 || comboBox21.Text == "00" || comboBox21.Text == "0")
                    {


                           MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ تولد را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                        comboBox21.Text = "";

                    }

                }






                //برای اینکه عدد بزرگتر از 12 ماه وارد نشودو  ..و.و



                if (comboBox22.Text != "")
                {
                    int num2 = int.Parse(comboBox22.Text);

                    if (num2 >= 13 || comboBox22.Text == "00" || comboBox22.Text == "0")
                    {

 
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ تولد را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                        comboBox22.Text = "";

                    }
                }



                if (textBox23.Text != "")
                {
                    int num3 = int.Parse(textBox23.Text);
                    if (num3 <= 999 || textBox23.Text == "0000" || textBox23.Text == "000" || textBox23.Text == "00" || textBox23.Text == "0")
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ تولد را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                         textBox23.Text = "";

                    }

                }

                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------
                //-----------------------------------------------------------------------------------------

                //-------------------------------------------------برای بررسی تاریخ عضویت--------

                //برای اینکه عدد بزرگتر از 31 روز وارد نشود..و.و

                if (comboBox4.Text != "")
                {
                    int num1 = int.Parse(comboBox4.Text);

                    if (num1 >= 32 || comboBox4.Text == "00" || comboBox4.Text == "0")
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ عضویت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                         comboBox4.Text = "";

                    }

                }






                //برای اینکه عدد بزرگتر از 12 ماه وارد نشودو  ..و.و



                if (comboBox8.Text != "")
                {
                    int num2 = int.Parse(comboBox8.Text);

                    if (num2 >= 13 || comboBox8.Text == "00" || comboBox8.Text == "0")
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ عضویت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                         comboBox8.Text = "";

                    }
                }



                if (textBox10.Text != "")
                {
                    int num3 = int.Parse(textBox10.Text);
                    if (num3 <= 999 || textBox10.Text == "0000" || textBox10.Text == "000" || textBox10.Text == "00" || textBox10.Text == "0")
                    {


                        MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ عضویت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                         textBox10.Text = "";

                    }

                }

                //-----------------------------------------------------------------------------------------


            }
        }





        public bool BarrasiCodeMelli()
        {
          //  SqlConnection con;

            bool outNatige=false;

                 if (textBox6.Text.Length <= 9)
                {
                    outNatige = false;
                
                     //errorProvider1.SetError(textBox6, "10 عدد کدملی راصحیح وارد نمایید");
                    
                }
               
                 else if (textBox6.Text.Length == 10)
                {


                    try
                    {
                        string str1 = "";
                        str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                        con = new SqlConnection(str1);

                        con.Open();
                        //جلوگیری از تکرار کد_ملی
                        string s1 = "select کد_ملی from Personel where کد_ملی=N'" + textBox6.Text + "'";
                        SqlDataAdapter da = new SqlDataAdapter(s1, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {

 
                             MsgBox.ShowMessage(this.Handle.ToInt32(), "این کد ملی ثبت شده", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                            textBox6.Text = "";

                          //  errorProvider1.SetError(textBox6, " کد ملي را کامل و صحیح وارد کنيد");


                        }

                        else { outNatige = true; }


                    }
                    catch (Exception er)
                    {
                          
                         MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message, "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                    }
                    finally
                    {
                        con.Close();

                    }
                }

                 return outNatige;
        }



     

        

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {

                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";

                textBox17.Enabled = false;
                textBox18.Enabled = false;
                textBox19.Enabled = false;
                textBox20.Enabled = false;

            }

            if (comboBox6.Text == "" ){
              
                textBox14.Text = "";
                textBox15.Text = "";

                textBox14.Enabled = false;
                textBox15.Enabled = false;


            }
  

            string str_rouz = "", str_mah = "", str_sal = "";

            try{



             
                    textKhali();

                errorProvider1.Clear();


                BarrasiFieldTarikhi();
               
                if (textBox1.Text == "") errorProvider1.SetError(textBox1, " لطفا تمام خانه ها را تکميل کنيد");

                else if (textBox2.Text == "") errorProvider1.SetError(textBox2, " فاميلي را وارد کنيد");
                else if (textBox3.Text == "") errorProvider1.SetError(textBox3, " نام پدر را وارد کنيد");
                //    else if (maskedTextBox1.Text == "") errorProvider1.SetError(maskedTextBox1, " تاريخ تولد را وارد کنيد");

                else if (comboBox21.Text == "") errorProvider1.SetError(comboBox21, " روز تاريخ تولد را وارد کنيد");
                else if (comboBox22.Text == "") errorProvider1.SetError(comboBox22, " ماه تاريخ تولد را وارد کنيد");
                else if (textBox23.Text == "") errorProvider1.SetError(textBox23, " سال تاريخ تولد را وارد کنيد");

                else if (textBox5.Text == "") errorProvider1.SetError(textBox5, " شماره شناسنامه را وارد کنيد");


                    //-------------
                else if(BarrasiCodeMelli()==false){

                    errorProvider1.SetError(textBox6, "کد ملی 10 رقمی را صحیح وارد نمایید");
                
                } 
                    //-------------



                else if (textBox7.Text == "") errorProvider1.SetError(textBox7, " شهر محل اقامت را وارد کنيد");
                else if (textBox8.Text == "") errorProvider1.SetError(textBox8, " نام مذهب را وارد کنيد");
    

                else if (textBox9.Text!="" && clmft.BarrasiFieldEmail(textBox9.Text) == false)
                {
                  //  errorProvider1.SetError(textBox9, " پست الکترونيکي صحیح و کامل وارد نمایید");

                    textBox9.Text = "";
                }



                else if (textBox11.Text == "") errorProvider1.SetError(textBox11, "تابعيت را وارد کنيد");




                else if (textBox112.Text.StartsWith("0") == true)
                {
                    errorProvider1.SetError(label12, " شماره تلفن_همراه همراه را (بدون صفر) کامل و صحیح وارد کنيد");
                    //   BarrasiFieldTell();
                }
                else if (textBox112.Text.Length <= 2 || textBox113.Text.Length <= 2 || textBox114.Text.Length <= 3)
                {
                    errorProvider1.SetError(label12, " شماره تلفن_همراه همراه را کامل وارد کنيد");
                    //   BarrasiFieldTell();
                }






                else if (comboBox1.Text == "") errorProvider1.SetError(comboBox1, "وضعيت تاهل را مشخص کنيد");
                else if (comboBox5.Text == "") errorProvider1.SetError(comboBox5, "جنسیت را مشخص کنيد");


                else if (textBox4.Text == "") errorProvider1.SetError(textBox4, " آدرس را وارد  کنيد");
                else if (txtImagePath.Text == "") errorProvider1.SetError(pictureBox1, " عکس را وارد کنيد");

                else if (comboBox6.Text == "") errorProvider1.SetError(comboBox6, " ميزان تحصيلات را وارد کنيد");
                //  else if (textBox14.Text == "") errorProvider1.SetError(textBox14, "رشته تحصيلي را وارد کنيد");
                // else if (textBox15.Text == "") errorProvider1.SetError(textBox15, " نام دانشگاه را وارد کنيد");



                else if (comboBox7.Text == "") errorProvider1.SetError(comboBox7, " نوع شغل را وارد کنيد کنيد");
                // else if (textBox17.Text == "") errorProvider1.SetError(textBox17, " مدت شغل را وارد کنيد");
                //else if (textBox18.Text == "") errorProvider1.SetError(textBox18, " نوع مسئوايت را وارد کنيد");
                //else if (textBox19.Text == "") errorProvider1.SetError(textBox19, " ميزان درآمد را وارد کنيد");
                //else if (textBox20.Text == "") errorProvider1.SetError(textBox20, " نشاني محل کار را وارد کنيد");


              //  else if (textBox24.Text == "") errorProvider1.SetError(textBox24, " خلاصه ثوابق فعاليت را وارد کنيد");
                 else if (comboBox3.Text == "") errorProvider1.SetError(comboBox3, " موضوع پيشنهادي فعاليت را وارد کنيد");



                // else if (textBox26.Text == "") errorProvider1.SetError(textBox26, "هدف از عضويت را وارد کنيد");
                else if (comboBox2.Text == "") errorProvider1.SetError(comboBox2, " نوع عضويت را وارد کنيد");



                else if (comboBox4.Text == "") errorProvider1.SetError(comboBox4, "  روز تاریخ عضویت را وارد کنيد");
                else if (comboBox8.Text == "") errorProvider1.SetError(comboBox8, " ماه تاریخ عضویت را وارد کنيد");
                else if (textBox10.Text == "") errorProvider1.SetError(textBox10, " سال تاریخ عضویت را وارد کنيد");






                else

                    try
                    {

                        //  BarrasiFieldTell();
                        // BarrasiFieldEmail();

                        byte[] imageData = ReadFile(txtImagePath.Text);


                        //  textBox21.Text = t21t;
                        //t21 = int.Parse(textBox21.Text);
                        t21 = int.Parse(textBox21.Text);


                        str_rouz = comboBox4.Text;
                        str_mah = comboBox8.Text;
                        str_sal = textBox10.Text;

                        

                        string tarikh = str_sal + "/" + str_mah + "/" + str_rouz;


                        cm.Refresh();


                        //   dbAccess.CallDB("insert into Personel(کد_عضویت,عکس,آدرس_عکس,نام,فامیلی,نام_پدر,تاریخ_تولد,شماره_شناسنامه,کد_ملی,شهر_اقامت,مذهب,تابعیت,وضعیت_تاهل,پست_الکترونیکی,تلفن_همراه,آدرس)values('" + t21 + "','" + (object)imageData + "','" + (object)txtImagePath.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox11.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "','" + textBox12.Text + "','" + textBox4.Text + "')");

                        Prs(t21);

                        cldbSql.CallDB("insert into tah(کد_عضویت,میزان_تحصیلات,رشته_تحصیلی,گرایش_تحصیلی,دانشگاه)values(N'" + t21 + "',N'" + comboBox6.Text + "',N'" + textBox14.Text + "',N'" + textBox12.Text + "',N'" + textBox15.Text + "')");

                        cldbSql.CallDB("insert into faal(کد_عضویت,موضوع_فعالیت,خلاصه_سوابق)values(N'" + t21 + "',N'" + comboBox3.Text + "',N'" + textBox24.Text + "')");
                        cldbSql.CallDB("insert into Sabt_ozv(کد_عضویت,تاریخ_عضویت,هدف_عضویت,نوع_عضویت)values(N'" + t21 + "',N'" + tarikh + "',N'" + textBox26.Text + "',N'" + comboBox2.Text + "')");
                        cldbSql.CallDB("insert into shoghl(کد_عضویت,نوع_شغل,مدت_شغل,عنوان_شغل,میزان_درآمد,نشانی_محل_کار)values(N'" + t21 + "',N'" + comboBox7.Text + "',N'" + textBox17.Text + "',N'" + textBox18.Text + "',N'" + textBox19.Text + "',N'" + textBox20.Text + "')");

                        
                        t21 = t21 + 1;


                        textBox21.Text = t21 + "";





                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        //  maskedTextBox1.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        comboBox6.Text = "";
                        textBox11.Text = "";
                        textBox114.Text = "";
                        textBox4.Text = "";
                        textBox14.Text = "";
                        textBox15.Text = "";
                        comboBox7.Text = "";
                        textBox17.Text = "";
                        textBox18.Text = "";
                        textBox19.Text = "";
                        textBox20.Text = "";
                        textBox24.Text = "";
                        textBox26.Text = "";
                        //    maskedTextBox2.Text = "";
                        pictureBox1.Image = null;
                        txtImagePath.Text = "";

                        //    comboBox4.Text = "";
                        //  comboBox8.Text = "";
                        //  textBox10.Text = "";



                        comboBox1.Text = "";
                        comboBox3.Text = "";
                        comboBox2.Text = "";
                        comboBox5.Text = "";

                        comboBox21.Text = "";
                        comboBox22.Text = "";
                        textBox23.Text = "";


                        textBox112.Text = "";
                        textBox113.Text = "";


                    }
                    catch (Exception)
                    {
                         
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "دکمه تایید را کلیک کنید تا کد عضویت فعال شود", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                        textBox21.Text = "100000";


                    }
          




            
            }
            catch (Exception er)
            {
                 
                 MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message, "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
              
            }
           
        }

 
         private void button1_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
           

            byte[] data = null;

            try{
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
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
            return data;
        }

     

        // StringBuilder path;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private void selectButton_Click(object sender, EventArgs e)
        {

        }

   


   


        public void Prs(int t21)
        {

            try{


            string str_Tell_Number="",str_3aval = "", str_3Vasat = "", str_4akhar = "";

            str_3aval = textBox112.Text;
            str_3Vasat = textBox113.Text;
            str_4akhar = textBox114.Text;

            str_Tell_Number = "0"+str_3aval + str_3Vasat + str_4akhar;


            string str_rouz = "", str_mah = "", str_sal = "";

            str_rouz = comboBox21.Text;
            str_mah = comboBox22.Text;
            str_sal = textBox23.Text;

            string tarikh = str_sal + "/" + str_mah + "/" + str_rouz;



            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection CN = new SqlConnection(str1);

            string qry = "insert into Personel (کد_عضویت,نام, فامیلی,نام_پدر,تاریخ_تولد,شماره_شناسنامه,کد_ملی,شهر_اقامت,مذهب,تابعیت,پست_الکترونیکی,تلفن_همراه,وضعیت_تاهل,جنسیت,آدرس,آدرس_عکس,عکس) values(@کد_عضویت,@نام,@فامیلی,@نام_پدر,@تاریخ_تولد,@شماره_شناسنامه,@کد_ملی,@شهر_اقامت,@مذهب,@تابعیت,@پست_الکترونیکی,@تلفن_همراه,@وضعیت_تاهل,@جنسیت,@آدرس,@آدرس_عکس,@عکس)";

            byte[] imageData = ReadFile(txtImagePath.Text);

          

                // DateTime.ParseExact(tarikh, "yyyy/MM/dd", null).ToString("yyyy/MM/dd")

                SqlCommand SqlCom = new SqlCommand(qry, CN);
                SqlCom.Parameters.Add(new SqlParameter("@کد_عضویت", t21));
                SqlCom.Parameters.Add(new SqlParameter("@نام", (object)textBox1.Text));
                SqlCom.Parameters.Add(new SqlParameter("@فامیلی", (object)textBox2.Text));
                SqlCom.Parameters.Add(new SqlParameter("@نام_پدر", (object)textBox3.Text));
                SqlCom.Parameters.Add(new SqlParameter("@تاریخ_تولد", (object)tarikh));
                SqlCom.Parameters.Add(new SqlParameter("@شماره_شناسنامه", (object)textBox5.Text));
                SqlCom.Parameters.Add(new SqlParameter("@کد_ملی", (object)textBox6.Text));
                SqlCom.Parameters.Add(new SqlParameter("@شهر_اقامت", (object)textBox7.Text));
                SqlCom.Parameters.Add(new SqlParameter("@مذهب", (object)textBox8.Text));
                SqlCom.Parameters.Add(new SqlParameter("@پست_الکترونیکی", (object)textBox9.Text));
                SqlCom.Parameters.Add(new SqlParameter("@تابعیت", (object)textBox11.Text));
                SqlCom.Parameters.Add(new SqlParameter("@تلفن_همراه", (object)str_Tell_Number));
                SqlCom.Parameters.Add(new SqlParameter("@وضعیت_تاهل", (object)comboBox1.Text));
                SqlCom.Parameters.Add(new SqlParameter("@جنسیت", (object)comboBox5.Text));
                SqlCom.Parameters.Add(new SqlParameter("@آدرس", (object)textBox4.Text));
                SqlCom.Parameters.Add(new SqlParameter("@آدرس_عکس", (object)txtImagePath.Text));
                SqlCom.Parameters.Add(new SqlParameter("@عکس", (object)imageData));

                CN.Open();
                SqlCom.ExecuteNonQuery();
                CN.Close();
            }
            catch (Exception er)
            {

                   MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message, "!! خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }
          

        }

     


 

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  می باشد  یاعددهشت  BackSpace معادل "\b"
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
          
            //باعث می شود هیچ نوشته ای به جز عدد وارد نشود

            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }



        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //باعث می شود هیچ نوشته ای  به جز عدد وارد نشود

            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
            comboBox8.MaxLength = 2;
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            comboBox4.MaxLength = 2;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

     
        
        private void comboBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            //باعث می شود هیچ نوشته ای  به جز عدد وارد نشود

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

            //باعث می شود هیچ نوشته ای  به جز عدد وارد نشود

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

   

        private void textBox6_KeyPress_1(object sender, KeyPressEventArgs e)
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







        public void Disable_RightClick_Menu_Field() {


            // غیر فعال کردن راست کلیک

            comboBox1.ContextMenu = new ContextMenu();
            comboBox2.ContextMenu = new ContextMenu();
            comboBox4.ContextMenu = new ContextMenu();
            comboBox5.ContextMenu = new ContextMenu();
            comboBox6.ContextMenu = new ContextMenu();

             comboBox2.ContextMenu = new ContextMenu();
            comboBox5.ContextMenu = new ContextMenu();
            comboBox6.ContextMenu = new ContextMenu();
            comboBox7.ContextMenu = new ContextMenu();
            comboBox8.ContextMenu = new ContextMenu();

      //      comboBox3.ContextMenu = new ContextMenu();

            textBox012.ContextMenu = new ContextMenu();
            textBox112.ContextMenu = new ContextMenu();
            textBox113.ContextMenu = new ContextMenu();
            textBox114.ContextMenu = new ContextMenu();


            textBox10.ContextMenu = new ContextMenu();

            textBox23.ContextMenu = new ContextMenu();

        
        
        }




        public void BarrasiFieldTellMobile() {


            if (textBox114.Text.Length <= 10) {


                textBox114.Text = "";

                 
                MsgBox.ShowMessage(this.Handle.ToInt32(), "شماره تلفن_همراه را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }
        
        
        
        }
       

        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
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
            //  یعنی BackSpace "/b"
            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

    

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();

            try{
        
            string strFileName = string.Empty;
            dlg.Filter = @"JPEG(*.jpg) |*.jpg";
            dlg.FilterIndex = 1;
            dlg.Title = "اضافه کردن تصویر";


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


        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            //این فیلد باعث می شود که کاربر هیچ نوشته ای را به فیلد مقطع تحصلی اضافه کند

            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "/b"
            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void textBox112_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox113_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox114_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "\b"
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }

        }

        private void textBox012_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  یعنی BackSpace "\b"
            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "نامشخص" || comboBox6.Text == "کم سواد" || comboBox6.Text == "ابتدایی" || comboBox6.Text == "راهنمایی" || comboBox6.Text == "دبیرستان" || comboBox6.Text == "غیره" || comboBox6.Text == "دیپلم" || comboBox6.Text == "حوزوی")
            {

                textBox14.Text = "------";
                textBox12.Text = "------";
                textBox15.Text = "------";

                textBox14.Enabled = false;
                textBox12.Enabled = false;
                textBox15.Enabled = false;
 
            
            }


            if (comboBox6.Text == "کاردانی" || comboBox6.Text == "کارشناسی" || comboBox6.Text == "کارشناسی ارشد" || comboBox6.Text == "دکترا" )
            {
                textBox14.Text = "";
                textBox12.Text = "";
                textBox15.Text = "";

                textBox14.Enabled = true;
                textBox12.Enabled = true;               
                textBox15.Enabled = true;


            }


        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox7.Text == "نامشخص" || comboBox7.Text == "دانشجو" || comboBox7.Text == "محصل")
            {

                textBox17.Text = "------";
                textBox18.Text = "------";
                textBox19.Text = "------";
                textBox20.Text = "------";

                textBox17.Enabled = false;
                textBox18.Enabled = false;
                textBox19.Enabled = false;
                textBox20.Enabled = false;

            }


            if (comboBox7.Text == "مشاغل آزاد" || comboBox7.Text == "مشاغل دولتی" || comboBox7.Text == "غیره")
            {

                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";

                textBox17.Enabled = true;
                textBox18.Enabled = true;
                textBox19.Enabled = true;
                textBox20.Enabled = true;

            }




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

     
 

 



    }

}

     