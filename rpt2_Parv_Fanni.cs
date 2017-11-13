using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Applictaion_Ozviat
{
    public partial class rpt2_Parv_Fanni : Form
    {

        SqlDataAdapter da = new SqlDataAdapter();
        cldbSql cmdsql = new cldbSql();
        CurrencyManager cm;



        public rpt2_Parv_Fanni()
        {
            InitializeComponent();
        }









        public void SearchDB(string str)
        {

            try{

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

            //---

            textBox9.DataBindings.Clear();
            textBox10.DataBindings.Clear();
            textBox11.DataBindings.Clear();
            //---

            textBox12.DataBindings.Clear();
            textBox13.DataBindings.Clear();
            textBox14.DataBindings.Clear();
            textBox15.DataBindings.Clear();
            textBox16.DataBindings.Clear();
            //------

            textBox17.DataBindings.Clear();
            textBox18.DataBindings.Clear();
            //------

            textBox19.DataBindings.Clear();
            textBox20.DataBindings.Clear();
            textBox21.DataBindings.Clear();

            textBox22.DataBindings.Clear();
            textBox23.DataBindings.Clear();

            pictureBox1.DataBindings.Clear();
        }


        public void DataBindingAdd(DataView dv)
        {
            textBox5.DataBindings.Add("Text", dv, "کد_عضویت");

            textBox6.DataBindings.Add("Text", dv, "نام");
            textBox7.DataBindings.Add("Text", dv, "فامیلی");
            textBox8.DataBindings.Add("Text", dv, "نام_پدر");
            textBox9.DataBindings.Add("Text", dv, "شماره_شناسنامه");

            //--------

            textBox10.DataBindings.Add("Text", dv, "میزان_تحصیلات");
            textBox11.DataBindings.Add("Text", dv, "رشته_تحصیلی");
            textBox12.DataBindings.Add("Text", dv, "گرایش_تحصیلی");

            textBox13.DataBindings.Add("Text", dv, "دانشگاه");

            //--------

            textBox14.DataBindings.Add("Text", dv, "نوع_شغل");
            textBox15.DataBindings.Add("Text", dv, "مدت_شغل");
            textBox16.DataBindings.Add("Text", dv, "عنوان_شغل");
            textBox17.DataBindings.Add("Text", dv, "میزان_درآمد");
            textBox18.DataBindings.Add("Text", dv, "نشانی_محل_کار");
            //--------

            textBox19.DataBindings.Add("Text", dv, "خلاصه_سوابق");
            textBox20.DataBindings.Add("Text", dv, "موضوع_فعالیت");
            //--------

         
            Binding b = new Binding("Text", dv, "تاریخ_عضویت", true);
            b.FormatString = "yyyy/MM/dd";
            //     b.FormatString = "yyyy/MM/dd hh:mm tt";

            textBox21.DataBindings.Add(b);


            textBox22.DataBindings.Add("Text", dv, "هدف_عضویت");
            textBox23.DataBindings.Add("Text", dv, "نوع_عضویت");


            pictureBox1.DataBindings.Add("image", dv, "عکس", true);


        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت like N'%" + textBox1.Text + "%'  ");



        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_ملی like N'%" + textBox2.Text + "%'  ");

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.نام like N'%" + textBox3.Text + "%'  ");

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.نام like N'%" + textBox4.Text + "%'  ");

            }
            else
            {

                SearchDB(" select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت = N'' ");
                Clear_ViewMoeshekhasatePersonel();
             }
            
        
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {


                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.فامیلی like N'%" + textBox3.Text + "%'  ");
            }
            else
            {

                SearchDB(" select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت = N'' ");
                Clear_ViewMoeshekhasatePersonel();
             
            }
         
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (textBox24.Text != "")
            {


                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت like N'%" + textBox24.Text + "%'  ");
            }
            else
            {

                SearchDB(" select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت = N'' ");
                Clear_ViewMoeshekhasatePersonel();
             
            } 
            
            
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            if (textBox25.Text != "")
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_ملی like N'%" + textBox25.Text + "%'  ");

            }
            else
            {

                SearchDB(" select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت = N'' ");
                Clear_ViewMoeshekhasatePersonel();
             
            }
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" & textBox1.Text != "")
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.نام_پدر ,Personel.شماره_شناسنامه, tah.میزان_تحصیلات,tah.رشته_تحصیلی,tah.گرایش_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.فامیلی  = N'" + textBox1.Text + "'  ");

            



            }

            else
            {

              
                MsgBox.ShowMessage(this.Handle.ToInt32(), " برای جستجو سبک 2 ، باید نام و فامیلی هر دو نوشته شوند", "توجه !! ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                Report r = new Report("..\\Debug\\rpt\\rpt1\\Report_ParvandFanni.rdlc", "select * from Personel,Sabt_ozv,tah,shoghl,faal,ser where Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت = '" + textBox5.Text + "'");
                r.ShowDialog();
            }
            else

            {

            
                MsgBox.ShowMessage(this.Handle.ToInt32(), " هیچ فردی انتخاب نشده است ", "توجه !! ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
     
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox8.Enabled = true;
            label25.Enabled = true;

            groupBox9.Enabled = false;
            label26.Enabled = false;


            textBox2.Text = "";
            textBox1.Text = "";
            

            SearchDB("select Personel.عکس,Personel.کد_عضویت as 'Id',Personel.نام as 'name_名称',Personel.فامیلی as 'Family_家庭',Personel.نام_پدر as 'Father_父亲',Personel.شماره_شناسنامه, tah.میزان_تحصیلات as 'Education_教育',tah.رشته_تحصیلی as 'Major_重大', tah.گرایش_تحصیلی as 'Sub Major',tah.دانشگاه as 'University 大学',shoghl.نوع_شغل as 'type of job _ 工作类型',shoghl.مدت_شغل as 'period of time',shoghl.عنوان_شغل as 'name of job',shoghl.میزان_درآمد as Income_ 收入,shoghl.نشانی_محل_کار as 'Address_ 地址', faal.موضوع_فعالیت as 'Name of Activity',from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت = N'' ");
            Clear_ViewMoeshekhasatePersonel();
               

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox8.Enabled = false;
            label25.Enabled = false;

            groupBox9.Enabled = true;
            label26.Enabled = true;

            textBox3.Text = "";
            textBox4.Text = "";
            textBox25.Text = "";
            textBox24.Text = "";

            SearchDB(" select Personel.عکس,Personel.کد_عضویت as 'Id',Personel.نام as 'name_名称',Personel.فامیلی as 'Family_家庭',Personel.نام_پدر as 'Father_父亲',Personel.شماره_شناسنامه, tah.میزان_تحصیلات as 'Education_教育',tah.رشته_تحصیلی as 'Major_重大', tah.گرایش_تحصیلی as 'Sub Major',tah.دانشگاه as 'University 大学',shoghl.نوع_شغل as 'type of job _ 工作类型',shoghl.مدت_شغل as 'period of time',shoghl.عنوان_شغل as 'name of job',shoghl.میزان_درآمد as Income_ 收入,shoghl.نشانی_محل_کار as 'Address_ 地址', faal.موضوع_فعالیت as 'Name of Activity' from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت = N'' ");
            Clear_ViewMoeshekhasatePersonel();
                 
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox25.Text = "";
            textBox24.Text = "";

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox25.Text = "";
            textBox24.Text = "";

        }

        private void textBox24_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox25.Text = "";
            textBox4.Text = "";

        }

        private void textBox25_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox24.Text = "";

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
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            pictureBox1.Image = null;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try{

            this.dataGridView1.Columns["تاریخ_عضویت"].DefaultCellStyle.Format = "yyyy/MM/dd";
     
               }

            catch (Exception ex)
            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchDB("select Personel.عکس,Personel.کد_عضویت as 'Id',Personel.نام as 'name_名称',Personel.فامیلی as 'Family_家庭',Personel.نام_پدر as 'Father_父亲',Personel.شماره_شناسنامه, tah.میزان_تحصیلات as 'Education_教育',tah.رشته_تحصیلی as 'Major_重大', tah.گرایش_تحصیلی as 'Sub Major',tah.دانشگاه as 'University 大学',shoghl.نوع_شغل as 'type of job _ 工作类型',shoghl.مدت_شغل as 'period of time',shoghl.عنوان_شغل as 'name of job',shoghl.میزان_درآمد as Income_ 收入,shoghl.نشانی_محل_کار as 'Address_ 地址', faal.موضوع_فعالیت as 'Name of Activity' from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت  ");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
 







    }

}