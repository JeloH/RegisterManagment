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
    public partial class Form2 : Form
    {


         string Hidden_Image_True_OR_False = "true";//تصویر اعضا پیش تنظم آن قابل نمایش نیست

        string[] SelectNameField;

        cldbSql cmdsql = new cldbSql();

        DataSet ds;
        SqlDataAdapter da;
        DataView dv;
        CurrencyManager cm;
 
        SqlConnection con;
        SqlCommand com;
        SqlCommandBuilder comb;



        public Form2()
        {
            InitializeComponent();
            //  label3.Parent = pictureBox1;
            //   label3.BackColor = Color.Transparent;
            //
            //   pictureBox2.Parent = pictureBox1;
            //pictureBox2.BackColor = Color.Transparent;

            comboBox_12.MaxLength = 2;
            comboBox_13.MaxLength = 2;
            textBox2.MaxLength = 4;

            comboBox1.SelectedIndex = comboBox1.FindStringExact("بله");
        }

        public void BarrasiTarikh()
        {







            //------------------------------------------بررسی تاریخ وارد شده--------------------------------------


            if (comboBox_13.Text != "")
            {
                int num1 = int.Parse(comboBox_13.Text);

                if (num1 >= 32 || comboBox_13.Text == "00" || comboBox_13.Text == "0")
                {
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ گزارش را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                     comboBox_13.Text = "";

                }

            }






            //برای اینکه عدد بزرگتر از 12 ماه وارد نشودو  ..و.و



            if (comboBox_12.Text != "")
            {
                int num2 = int.Parse(comboBox_12.Text);

                if (num2 >= 13 || comboBox_12.Text == "00" || comboBox_12.Text == "0")
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ گزارش را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
 
                    comboBox_12.Text = "";

                }
            }



            if (textBox2.Text != "")
            {
                int num3 = int.Parse(textBox2.Text);
                if (num3 <= 999 || textBox2.Text == "0000" || textBox2.Text == "000" || textBox2.Text == "00" || textBox2.Text == "0")
                {


                    MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ گزارش را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    textBox2.Text = "";

                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            try{


            BarrasiTarikh();

            if (comboBox_13.Text == "")
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), " روز تاریخ  را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else if (comboBox_12.Text == "")
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), " ماه تاریخ  را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else if (textBox2.Text == "")
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), " سال تاریخ  را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else if (textBox_NameGozaresh.Text == "")
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), " عنوان گزارش را وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }



            else
            {
                //--------------------------------------------------------------------------------


                if (comboBox2.Text == "" & comboBox3.Text == "" & comboBox4.Text == "" & comboBox5.Text == "" & comboBox6.Text == "" & comboBox7.Text == "" & comboBox8.Text == "")
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), " هیچ فیلدی انتخاب نشده است ", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                }


                else
                {

                    //---------------

                    //--------------------------تنظیم تاریخ گزارش---------------------

                    string str_rouz_G = "", str_mah_G = "", str_sal_G = "";

                    str_rouz_G = comboBox_13.Text;
                    str_mah_G = comboBox_12.Text;
                    str_sal_G = textBox2.Text;

                    string tarikh_G = str_sal_G + "/" + str_mah_G + "/" + str_rouz_G;

                    //------------------------------------------------------





                    saveEditDB();

                    //cldbSql.CallDB("update Personel set چکباکس='true' where چکباکس='true'");
                    //string c2=" select * from Personel,ser where  Personel.چکباکس='true'";

                    string ColumnField2 = "0", ColumnField3 = "", ColumnField4 = "", ColumnField5 = "", ColumnField6 = "", ColumnField7 = "", ColumnField8 = "", ColumnField9 = "", ColumnField10 = "", ColumnField11 = "", ColumnField12 = "", ColumnField13 = "", ColumnField14 = "";

                    ColumnField2 = comboBox2.Text;
                    ColumnField3 = comboBox3.Text;
                    ColumnField4 = comboBox4.Text;
                    ColumnField5 = comboBox5.Text;
                    ColumnField6 = comboBox6.Text;
                    ColumnField7 = comboBox7.Text;
                    ColumnField8 = comboBox8.Text;

                    ColumnField9 = comboBox9.Text;
                    ColumnField10 = comboBox10.Text;
                    ColumnField11 = comboBox11.Text;
                    ColumnField12 = comboBox12.Text;
                    ColumnField13 = comboBox13.Text;
                    ColumnField14 = comboBox14.Text;


                    //  if (ColumnField1 == "انتخاب کنید") ColumnField1 = " ";
                    if (ColumnField2 == "" || ColumnField2 == "[--- بدون انتخاب---]") ColumnField2 = " ";
                    if (ColumnField3 == "" || ColumnField3 == "[--- بدون انتخاب---]") ColumnField3 = " ";
                    if (ColumnField4 == "" || ColumnField4 == "[--- بدون انتخاب---]") ColumnField4 = " ";
                    if (ColumnField5 == "" || ColumnField5 == "[--- بدون انتخاب---]") ColumnField5 = " ";
                    if (ColumnField6 == "" || ColumnField6 == "[--- بدون انتخاب---]") ColumnField6 = " ";
                    if (ColumnField7 == "" || ColumnField7 == "[--- بدون انتخاب---]") ColumnField7 = " ";
                    if (ColumnField8 == "" || ColumnField8 == "[--- بدون انتخاب---]") ColumnField8 = " ";
                    if (ColumnField9 == "" || ColumnField9 == "[--- بدون انتخاب---]") ColumnField9 = " ";
                    if (ColumnField10 == "" || ColumnField10 == "[--- بدون انتخاب---]") ColumnField10 = " ";
                    if (ColumnField11 == "" || ColumnField11 == "[--- بدون انتخاب---]") ColumnField11 = " ";
                    if (ColumnField12 == "" || ColumnField12 == "[--- بدون انتخاب---]") ColumnField12 = " ";
                    if (ColumnField13 == "" || ColumnField13 == "[--- بدون انتخاب---]") ColumnField13 = " ";
                    if (ColumnField14 == "" || ColumnField14 == "[--- بدون انتخاب---]") ColumnField14 = " ";


                    if (comboBox1.Text == "بله") Hidden_Image_True_OR_False = "false";
                    if (comboBox1.Text == "خیر") Hidden_Image_True_OR_False = "true";

                    SelectNameField = new string[] { ColumnField2, ColumnField3, ColumnField4, ColumnField5, ColumnField6, ColumnField7, ColumnField8, ColumnField9, ColumnField10, ColumnField11, ColumnField12, ColumnField13, ColumnField14};

                    if (comboBox2.Text != "" & comboBox9.Text == "" & comboBox12.Text == "")
                    {
                        Report5 r = new Report5("..\\Debug\\rpt\\rpt5\\Report_Ekhtryari_8Column.rdlc", " select * from Personel,tah,shoghl,faal,Sabt_ozv,ser where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Personel.چکباکس='true'", textBox_NameGozaresh.Text, tarikh_G, SelectNameField, Hidden_Image_True_OR_False);
                        r.ShowDialog();
                    }

                    if (comboBox9.Text != "" & comboBox12.Text == "")
                    {
                        Report5 r = new Report5("..\\Debug\\rpt\\rpt5\\Report_Ekhtryari_12Column.rdlc", " select * from Personel,tah,shoghl,faal,Sabt_ozv,ser where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Personel.چکباکس='true'", textBox_NameGozaresh.Text, tarikh_G, SelectNameField, Hidden_Image_True_OR_False);
                        r.ShowDialog();
                    }


                    if (comboBox12.Text != "" )
                    {
                        Report5 r = new Report5("..\\Debug\\rpt\\rpt5\\Report_Ekhtryari_14Column.rdlc", " select * from Personel,tah,shoghl,faal,Sabt_ozv,ser where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Personel.چکباکس='true'", textBox_NameGozaresh.Text, tarikh_G, SelectNameField, Hidden_Image_True_OR_False);
                        r.ShowDialog();
                    }

                }

            }


            }
            catch (Exception er)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }


        }



        private void Form2_Load(object sender, EventArgs e)
        {
            selectLoad("select  Personel.چکباکس as 'Check box',Personel.کد_عضویت as 'ID',Personel.نام as 'Name',Personel.فامیلی as 'family',Personel.نام_پدر as 'father',Personel.تاریخ_تولد as 'Date of birth',Personel.شماره_شناسنامه as 'idy_id',Personel.کد_ملی as 'Natinal ID',Personel.شهر_اقامت as 'City - 市',Personel.مذهب as 'Religion',Personel.تابعیت as 'National 国民',Personel.پست_الکترونیکی as 'E-mail',Personel.تلفن_همراه as 'Phone Number',Personel.وضعیت_تاهل as 'marital status',Personel.آدرس 'address - 地址' from Personel");
            
            cldbSql.CallDB("update Personel set چکباکس= 'false' "); // 



        }

 

        public void selectLoad(string str)
        {

            try
            {

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                con = new SqlConnection(str1);
                com = con.CreateCommand();

                //برای انجام عمایات بروزرسانی باید حتما کاید اصلی هم باشد

                com.CommandText = str;
                com.CommandType = CommandType.Text;

                ds = new DataSet();

                da = new SqlDataAdapter(com);

                comb = new SqlCommandBuilder(da);

                da.Fill(ds);
                dv = new DataView(ds.Tables[0]);
                //dataGridView1.DataSource = ds;
                //dataGridView1.DataMember = ds.Tables[0].TableName;

                dataGridView1.DataSource = dv;


                cm = (CurrencyManager)BindingContext[dv];





            }
            catch (Exception)
            {
                
                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

            }


        }
        public void saveEditDB()
        {
            try{

            dataGridView1.EndEdit();

            cm.EndCurrentEdit();

            da.Update(ds.Tables[0]);

               }
                catch (Exception er)
                {
 
                    MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                }

        }




        private void button3_Click(object sender, EventArgs e)
        {

            saveEditDB();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            saveEditDB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Close();

        //    comboBox2.SelectedText.Remove(0);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            if (textBox1.Text != "")
            {
                saveEditDB();

                selectLoad("select  Personel.چکباکس as 'Check box',Personel.کد_عضویت as 'ID',Personel.نام as 'Name',Personel.فامیلی as 'family',Personel.نام_پدر as 'father',Personel.تاریخ_تولد as 'Date of birth',Personel.شماره_شناسنامه as 'idy_id',Personel.کد_ملی as 'Natinal ID',Personel.شهر_اقامت as 'City - 市',Personel.مذهب as 'Religion',Personel.تابعیت as 'National 国民',Personel.پست_الکترونیکی as 'E-mail',Personel.تلفن_همراه as 'Phone Number',Personel.وضعیت_تاهل as 'marital status',Personel.آدرس 'address - 地址'   from Personel where کد_عضویت like N'%" + textBox1.Text + "%'");
          
            }
            else
            {
                saveEditDB();
                selectLoad("select  Personel.چکباکس as 'Check box',Personel.کد_عضویت as 'ID',Personel.نام as 'Name',Personel.فامیلی as 'family',Personel.نام_پدر as 'father',Personel.تاریخ_تولد as 'Date of birth',Personel.شماره_شناسنامه as 'idy_id',Personel.کد_ملی as 'Natinal ID',Personel.شهر_اقامت as 'City - 市',Personel.مذهب as 'Religion',Personel.تابعیت as 'National 国民',Personel.پست_الکترونیکی as 'E-mail',Personel.تلفن_همراه as 'Phone Number',Personel.وضعیت_تاهل as 'marital status',Personel.آدرس 'address - 地址'   from Personel where کد_عضویت = N''");
          
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           


            if (textBox3.Text != "")
            {
                saveEditDB();

                selectLoad("select select  Personel.چکباکس as 'Check box',Personel.کد_عضویت as 'ID',Personel.نام as 'Name',Personel.فامیلی as 'family',Personel.نام_پدر as 'father',Personel.تاریخ_تولد as 'Date of birth',Personel.شماره_شناسنامه as 'idy_id',Personel.کد_ملی as 'Natinal ID',Personel.شهر_اقامت as 'City - 市',Personel.مذهب as 'Religion',Personel.تابعیت as 'National 国民',Personel.پست_الکترونیکی as 'E-mail',Personel.تلفن_همراه as 'Phone Number',Personel.وضعیت_تاهل as 'marital status',Personel.آدرس 'address - 地址'   from Personel where کد_ملی like N'%" + textBox3.Text + "%'");

            }
            else
            {

                saveEditDB();

                selectLoad("select select  Personel.چکباکس as 'Check box',Personel.کد_عضویت as 'ID',Personel.نام as 'Name',Personel.فامیلی as 'family',Personel.نام_پدر as 'father',Personel.تاریخ_تولد as 'Date of birth',Personel.شماره_شناسنامه as 'idy_id',Personel.کد_ملی as 'Natinal ID',Personel.شهر_اقامت as 'City - 市',Personel.مذهب as 'Religion',Personel.تابعیت as 'National 国民',Personel.پست_الکترونیکی as 'E-mail',Personel.تلفن_همراه as 'Phone Number',Personel.وضعیت_تاهل as 'marital status',Personel.آدرس 'address - 地址'   from Personel where کد_ملی = N'' ");


            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           

            if (textBox4.Text != "")
            {
                saveEditDB();

                selectLoad("select  Personel.چکباکس as 'Check box',Personel.کد_عضویت as 'ID',Personel.نام as 'Name',Personel.فامیلی as 'family',Personel.نام_پدر as 'father',Personel.تاریخ_تولد as 'Date of birth',Personel.شماره_شناسنامه as 'idy_id',Personel.کد_ملی as 'Natinal ID',Personel.شهر_اقامت as 'City - 市',Personel.مذهب as 'Religion',Personel.تابعیت as 'National 国民',Personel.پست_الکترونیکی as 'E-mail',Personel.تلفن_همراه as 'Phone Number',Personel.وضعیت_تاهل as 'marital status',Personel.آدرس 'address - 地址'   from Personel where فامیلی like N'%" + textBox4.Text + "%'");

            }
            else
            {
                saveEditDB();

                selectLoad("select  Personel.چکباکس as 'Check box',Personel.کد_عضویت as 'ID',Personel.نام as 'Name',Personel.فامیلی as 'family',Personel.نام_پدر as 'father',Personel.تاریخ_تولد as 'Date of birth',Personel.شماره_شناسنامه as 'idy_id',Personel.کد_ملی as 'Natinal ID',Personel.شهر_اقامت as 'City - 市',Personel.مذهب as 'Religion',Personel.تابعیت as 'National 国民',Personel.پست_الکترونیکی as 'E-mail',Personel.تلفن_همراه as 'Phone Number',Personel.وضعیت_تاهل as 'marital status',Personel.آدرس 'address - 地址'  from Personel where فامیلی = N''");

            }


        }

        private void comboBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("012345679\b".IndexOf(e.KeyChar.ToString()) >= 0)
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
            if ("012345679\b".IndexOf(e.KeyChar.ToString()) >= 0)
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
            if ("012345679\b".IndexOf(e.KeyChar.ToString()) >= 0)
            {


                e.Handled = false;
            }

            else
            {

                e.Handled = true;
            }
        }





        public void comboBox_Enable_FalseTrue()
        {

            if (comboBox2.Text == "[--- بدون انتخاب---]")
            {
                comboBox2.SelectedIndex = comboBox3.FindStringExact("");
                comboBox3.SelectedIndex = comboBox3.FindStringExact("");
                comboBox4.SelectedIndex = comboBox4.FindStringExact("");
                comboBox5.SelectedIndex = comboBox5.FindStringExact("");
                comboBox6.SelectedIndex = comboBox6.FindStringExact("");
                comboBox7.SelectedIndex = comboBox7.FindStringExact("");
                comboBox8.SelectedIndex = comboBox8.FindStringExact("");
                comboBox9.SelectedIndex = comboBox9.FindStringExact("");
                comboBox10.SelectedIndex = comboBox10.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");


                //comboBox2.Enabled = false;
                comboBox3.Enabled = false;               
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;

             }

           else if (comboBox3.Text == "[--- بدون انتخاب---]")
            {
                comboBox3.SelectedIndex = comboBox4.FindStringExact("");
                comboBox4.SelectedIndex = comboBox4.FindStringExact("");
                comboBox5.SelectedIndex = comboBox5.FindStringExact("");
                comboBox6.SelectedIndex = comboBox6.FindStringExact("");
                comboBox7.SelectedIndex = comboBox7.FindStringExact("");
                comboBox8.SelectedIndex = comboBox8.FindStringExact("");
                comboBox9.SelectedIndex = comboBox9.FindStringExact("");
                comboBox10.SelectedIndex = comboBox10.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");


              //  comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;

    
            }

            else if (comboBox4.Text == "[--- بدون انتخاب---]")
            {

                comboBox4.SelectedIndex = comboBox5.FindStringExact("");
                comboBox5.SelectedIndex = comboBox5.FindStringExact("");
                comboBox6.SelectedIndex = comboBox6.FindStringExact("");
                comboBox7.SelectedIndex = comboBox7.FindStringExact("");
                comboBox8.SelectedIndex = comboBox8.FindStringExact("");
                comboBox9.SelectedIndex = comboBox9.FindStringExact("");
                comboBox10.SelectedIndex = comboBox10.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");


              //  comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;
 
            }

            else if ( comboBox5.Text == "[--- بدون انتخاب---]")
            {

                comboBox5.SelectedIndex = comboBox6.FindStringExact("");
                comboBox6.SelectedIndex = comboBox6.FindStringExact("");
                comboBox7.SelectedIndex = comboBox7.FindStringExact("");
                comboBox8.SelectedIndex = comboBox8.FindStringExact("");
                comboBox9.SelectedIndex = comboBox9.FindStringExact("");
                comboBox10.SelectedIndex = comboBox10.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");




              //  comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;

            }

            else if ( comboBox6.Text == "[--- بدون انتخاب---]")
            {
                comboBox6.SelectedIndex = comboBox7.FindStringExact("");
                comboBox7.SelectedIndex = comboBox7.FindStringExact("");
                comboBox8.SelectedIndex = comboBox8.FindStringExact("");
                comboBox9.SelectedIndex = comboBox9.FindStringExact("");
                comboBox10.SelectedIndex = comboBox10.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");



               // comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;

         
            }

            else if ( comboBox7.Text == "[--- بدون انتخاب---]")
            {
                comboBox7.SelectedIndex = comboBox8.FindStringExact("");
                comboBox8.SelectedIndex = comboBox8.FindStringExact("");
                comboBox9.SelectedIndex = comboBox9.FindStringExact("");
                comboBox10.SelectedIndex = comboBox10.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");


              //  comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;

          
            }

            else if (comboBox8.Text == "[--- بدون انتخاب---]")
            {


                comboBox8.SelectedIndex = comboBox8.FindStringExact("");
                comboBox9.SelectedIndex = comboBox9.FindStringExact("");
                comboBox10.SelectedIndex = comboBox10.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");


               // comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;
 
            }

            else if ( comboBox9.Text == "[--- بدون انتخاب---]")
            {
                comboBox9.SelectedIndex = comboBox9.FindStringExact("");
                comboBox10.SelectedIndex = comboBox10.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");



             //   comboBox9.Enabled = false;
                comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;


            }

            else if ( comboBox10.Text == "[--- بدون انتخاب---]")
            {
                comboBox10.SelectedIndex = comboBox11.FindStringExact("");
                comboBox11.SelectedIndex = comboBox11.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");



             //   comboBox10.Enabled = false;
                comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;

 
             }

            else if ( comboBox11.Text == "[--- بدون انتخاب---]")
            {

                comboBox11.SelectedIndex = comboBox12.FindStringExact("");
                comboBox12.SelectedIndex = comboBox12.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");



              //  comboBox11.Enabled = false;
                comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;
       }

            else if (comboBox12.Text == "[--- بدون انتخاب---]")
            {


                comboBox12.SelectedIndex = comboBox13.FindStringExact("");
                comboBox13.SelectedIndex = comboBox13.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");


              //  comboBox12.Enabled = false;
                comboBox13.Enabled = false;
                comboBox14.Enabled = false;


         
            }

            else if (comboBox13.Text == "[--- بدون انتخاب---]")
            {

                comboBox13.SelectedIndex = comboBox14.FindStringExact("");
                comboBox14.SelectedIndex = comboBox14.FindStringExact("");

              //  comboBox13.Enabled = false;
                comboBox14.Enabled = false;


            }

            else if (comboBox14.Text == "[--- بدون انتخاب---]")
            {

                comboBox14.SelectedIndex = comboBox14.FindStringExact("");

               // comboBox14.Enabled = false;


            }
      





        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            
            if (comboBox2.Text != null && comboBox2.Text != "[--- بدون انتخاب---]")
            {

                comboBox3.Enabled = true;

            }

            else if (comboBox2.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();


            }




        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != null && comboBox3.Text != "[--- بدون انتخاب---]")
            {

                comboBox4.Enabled = true;

            }

            else if (comboBox3.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();


            }


        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text != null && comboBox4.Text != "[--- بدون انتخاب---]")
            {

                comboBox5.Enabled = true;

            }

            else if (comboBox4.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();

            }




        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != null && comboBox5.Text != "[--- بدون انتخاب---]")
            {

                comboBox6.Enabled = true;

            }

            else if (comboBox5.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();


            }



        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text != null && comboBox6.Text != "[--- بدون انتخاب---]")
            {

                comboBox7.Enabled = true;

            }

            else if (comboBox6.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();



            }


        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text != null && comboBox7.Text != "[--- بدون انتخاب---]")
            {

                comboBox8.Enabled = true;

            }

            else if (comboBox7.Text == "[--- بدون انتخاب---]")
            {
                comboBox_Enable_FalseTrue();



            }



        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text != null && comboBox8.Text != "[--- بدون انتخاب---]")
            {

                comboBox9.Enabled = true;

            }

            else if (comboBox8.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();

            }




        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.Text != null && comboBox9.Text != "[--- بدون انتخاب---]")
            {

                comboBox10.Enabled = true;

            }

            else if (comboBox9.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();

            }


        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text != null && comboBox10.Text != "[--- بدون انتخاب---]")
            {

                comboBox11.Enabled = true;

            }

            else if (comboBox10.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();
            }


        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text != null && comboBox11.Text != "[--- بدون انتخاب---]")
            {

                comboBox12.Enabled = true;

            }

            else if (comboBox11.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();

            }

        }





        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.Text != null && comboBox12.Text != "[--- بدون انتخاب---]")
            {

                comboBox13.Enabled = true;

            }

            else if (comboBox12.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();


            }


        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.Text != null && comboBox13.Text != "[--- بدون انتخاب---]")
            {

                comboBox14.Enabled = true;

            }

            else if (comboBox13.Text == "[--- بدون انتخاب---]")
            {

                comboBox_Enable_FalseTrue();

            }


        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.Text == null && comboBox14.Text == "[--- بدون انتخاب---]")
            {

                comboBox14.Enabled = false;
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataGridView1.Columns["تاریخ_تولد"].DefaultCellStyle.Format = "yyyy/MM/dd";

          
        }

      




    }





}