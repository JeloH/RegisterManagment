using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Applictaion_Ozviat
{
    public partial class SearchParvandrFanni : Form
    {

        cldbSql cmdsql=new cldbSql();


        public SearchParvandrFanni()
        {
            InitializeComponent();
            comboBox21.MaxLength = 2;
            comboBox22.MaxLength = 2;

            comboBox3.SelectedIndex = comboBox3.FindStringExact("میزان_تحصیلات");
  

        }

        
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           // this.dataGridView1.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";
      //      this.dataGridView1.Columns[3].DefaultCellStyle.Format = "yyyy/MM/dd";
        }

        private void SearchParvandrFanni_Load(object sender, EventArgs e)
        {
            try{
            
            DataView dv;

            dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'  from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت ");

            dataGridView1.DataSource = dv;

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

       
        }

      

 
    


  

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
         
            try{

            groupBox2.Enabled = true;
            label25.Enabled = true;

            groupBox9.Enabled = false;
            label26.Enabled = false;

            groupBox4.Enabled = false;
            label5.Enabled = false;

 


            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            DataView dv;
            dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址' from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");
            dataGridView1.DataSource = dv;

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


      
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try{

            groupBox2.Enabled = false;
            label25.Enabled = false;

            groupBox9.Enabled = true;
            label26.Enabled = true;

            groupBox4.Enabled = false;
            label5.Enabled = false;


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox5.Text = "";


            comboBox21.Text = "";
            comboBox22.Text = "";
            textBox23.Text = "";


            DataView dv;
            dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址' from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");
            dataGridView1.DataSource = dv;

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try{

            groupBox2.Enabled = false;
            label25.Enabled = false;

            groupBox9.Enabled = false;
            label26.Enabled = false;

            groupBox4.Enabled = true;
            label5.Enabled = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox4.Text = "";
            textBox6.Text = "";

            comboBox21.Text = "";
            comboBox22.Text = "";
            textBox23.Text = "";


            DataView dv;
            dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'  from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");
            dataGridView1.DataSource = dv;
            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

      

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try{

            if (textBox1.Text != "")
            {

                DataView dv;
                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'  from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.فامیلی like N'%" + textBox1.Text + "%' ");
                dataGridView1.DataSource = dv;

            }
            else
            {


                DataView dv;
                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址' from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");
                dataGridView1.DataSource = dv;
            }


            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try{

            if (textBox2.Text != "")
            {


                DataView dv;
                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'   from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_ملی like N'%" + textBox2.Text + "%' ");
                dataGridView1.DataSource = dv;

            }
            else
            {


                DataView dv;
                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址' from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");
                dataGridView1.DataSource = dv;
            }

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


     
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try{

            if (textBox3.Text != "")
            {


                DataView dv;
                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'  from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت like N'%" + textBox3.Text + "%' ");
                dataGridView1.DataSource = dv;
            
            }
            else
            {


                DataView dv;
                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'   from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");
                dataGridView1.DataSource = dv;
            }

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{


            if (textBox6.Text != "" & textBox4.Text != "")
            {
                DataView dv;

                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'  from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and   Personel.نام = N'" + textBox6.Text + "' and Personel.فامیلی  = N'" + textBox4.Text + "' ");

                dataGridView1.DataSource = dv;

              }

            else
            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), " برای جستجو سبک 2 ، باید نام و فامیلی هر دو نوشته شوند", "توجه", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
            }

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }



        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try{

            if (textBox5.Text != "")
            {



                DataView dv;
                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'  from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and " + comboBox3.Text + " like N'%" + textBox5.Text + "%' ");
                dataGridView1.DataSource = dv;
            }
            else
            {


                DataView dv;
                dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'   from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");
                dataGridView1.DataSource = dv;
            }

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }



        }

       
        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{

            DataView dv;
            dv = cmdsql.vt("select  Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Sabt_ozv.تاریخ_عضویت,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت and  Sabt_ozv.تاریخ_عضویت like N'" + textBox23.Text + "-" + comboBox22.Text + "-" + comboBox21.Text + "'");// 1391-01-06
            dataGridView1.DataSource = dv;
        
            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }


        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{

            DataView dv;
            dv = cmdsql.vt("select  Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Sabt_ozv.تاریخ_عضویت,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت and  Sabt_ozv.تاریخ_عضویت like N'" + textBox23.Text + "-" + comboBox22.Text + "-" + comboBox21.Text + "'");// 1391-01-06
            dataGridView1.DataSource = dv;

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }



        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            try{

            DataView dv;
            dv = cmdsql.vt("select  Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Sabt_ozv.تاریخ_عضویت,Personel.تاریخ_تولد,Personel.شماره_شناسنامه,Personel.کد_ملی,Personel.شهر_اقامت,Personel.مذهب,Personel.تابعیت,Personel.پست_الکترونیکی,Personel.تلفن_همراه,Personel.وضعیت_تاهل,Personel.آدرس from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت and  Sabt_ozv.تاریخ_عضویت like N'" + textBox23.Text + "-" + comboBox22.Text + "-" + comboBox21.Text + "'");// 1391-01-06
            dataGridView1.DataSource = dv;

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

        private void comboBox21_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox22_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
           
            comboBox21.Text = "";
            comboBox22.Text = "";
            textBox23.Text = "";


        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
           
            comboBox21.Text = "";
            comboBox22.Text = "";
            textBox23.Text = "";


        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";

            comboBox21.Text = "";
            comboBox22.Text = "";
            textBox23.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{

            DataView dv;
            dv = cmdsql.vt("select Personel.کد_عضویت  as 'Id_',Personel.نام as 'First_Name_名字',Personel.فامیلی as 'Family_姓氏',Personel.نام_پدر as 'Father_父亲姓名',Personel.تاریخ_تولد as '出生日期_birth',Personel.شماره_شناسنامه as 'Identification_number_识别号码',Personel.کد_ملی as 'National Id',Personel.شهر_اقامت as 'City_市',Personel.مذهب as'religion_宗教',Personel.تابعیت as 'nationality_国籍',Personel.پست_الکترونیکی as 'Email_电邮',Personel.تلفن_همراه as 'PhoneNumber_电话号码',Personel.وضعیت_تاهل as 'MaritalStatus_婚姻状况', Personel.آدرس  as 'Address_地址'  from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت ");
            dataGridView1.DataSource = dv;

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    
   
        
    }
}
