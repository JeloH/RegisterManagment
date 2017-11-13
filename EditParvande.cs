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
    public partial class EditParvande : Form
    {




 

        
        cldbSql cmdsql = new cldbSql();
 
        CurrencyManager cm;
  



        public EditParvande()
        {
            InitializeComponent();
        }

    

        public void DataBindingClear() {

            comboBox5.DataBindings.Clear();
            textBox2.DataBindings.Clear();

            textBox18.DataBindings.Clear();
          

            textBox3.DataBindings.Clear();
           //---
            
            comboBox1.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            //------
            comboBox2.DataBindings.Clear();
            textBox8.DataBindings.Clear();

            //------

            textBox9.DataBindings.Clear();
            maskedTextBox1.DataBindings.Clear();
            comboBox3.DataBindings.Clear();

            textBox15.DataBindings.Clear();
            
            textBox12.DataBindings.Clear();
            textBox13.DataBindings.Clear();
            textBox14.DataBindings.Clear();

            textBox1.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
        

        }


        public void DataBindingAdd(DataView dv) {

            comboBox5.DataBindings.Add("Text", dv, "میزان_تحصیلات");  
            textBox2.DataBindings.Add("Text", dv, "رشته_تحصیلی");
          
            textBox18.DataBindings.Add("Text", dv, "گرایش_تحصیلی");

            textBox3.DataBindings.Add("Text", dv, "دانشگاه");
           
            //--------

            comboBox1.DataBindings.Add("Text", dv, "نوع_شغل");
            textBox4.DataBindings.Add("Text", dv, "مدت_شغل");
            textBox5.DataBindings.Add("Text", dv, "عنوان_شغل");
            textBox6.DataBindings.Add("Text", dv, "میزان_درآمد");
            textBox7.DataBindings.Add("Text", dv, "نشانی_محل_کار");
            //--------
           
            comboBox2.DataBindings.Add("Text", dv, "موضوع_فعالیت");
            textBox8.DataBindings.Add("Text", dv, "خلاصه_سوابق");
         
            //--------

            textBox9.DataBindings.Add("Text", dv, "هدف_عضویت");
       
            ///-------------------صحیح نشان دان تاریخ تولد روز/ماه/سال------------

            // maskedTextBox1.DataBindings.Add("Text", dv, "تاریخ_عضویت");

           // Binding b = new Binding("Text", dv, "تاریخ_عضویت", true);
           // b.FormatString = "yyyy/MM/dd";
           // b.FormatString = "yyyy/MM/dd hh:mm tt";


            maskedTextBox1.DataBindings.Add("Text", dv, "تاریخ_عضویت");

            ///--------------------------------------
             
         

     
          

          //  label27.Text.ToString( = st;

          



            comboBox3.DataBindings.Add("Text", dv, "نوع_عضویت");

            //---
            textBox15.DataBindings.Add("Text", dv, "کد_عضویت");

            textBox12.DataBindings.Add("Text", dv, "نام");
            textBox13.DataBindings.Add("Text", dv, "فامیلی");
            textBox14.DataBindings.Add("Text", dv, "کد_ملی");


            textBox1.DataBindings.Add("Text", dv, "آدرس_عکس");
            pictureBox1.DataBindings.Add("image", dv, "عکس",true);


        }





        public void SearchDB(string str) {

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
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }



        public void Disable_TextBox_ComboBox()
        {

            comboBox5.Enabled = false;
            textBox2.Enabled = false;

            textBox18.Enabled = false;


            textBox3.Enabled = false;
            //---

            comboBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            //------
            comboBox2.Enabled = false;
            textBox8.Enabled = false;

            //------

            textBox9.Enabled = false;
            maskedTextBox1.Enabled = false;
            comboBox3.Enabled = false;

            textBox15.Enabled = false;

            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;

            textBox1.Enabled = false;



        }


        public void Enable_TextBox_ComboBox()
        {

            comboBox5.Enabled = true;
          //  textBox2.Enabled = true;

          //  textBox18.Enabled = true;


           // textBox3.Enabled = true;
            //---

            comboBox1.Enabled = true;
           // textBox4.Enabled = true;
           // textBox5.Enabled = true;
          //  textBox6.Enabled = true;
          //  textBox7.Enabled = true;
            //------
            comboBox2.Enabled = true;
            textBox8.Enabled = true;

            //------

            textBox9.Enabled = true;
            maskedTextBox1.Enabled = true;
            comboBox3.Enabled = true;

            textBox15.Enabled = true;

            textBox12.Enabled = true;
            textBox13.Enabled = true;
            textBox14.Enabled = true;

            textBox1.Enabled = true;



        }



        public bool BarrasiTarikh()
        {

            int rouz_int, mah_int, sall_int;
            string temp, rouz, mah, sall;

            bool bf = true;

            temp = maskedTextBox1.Text;


            if (temp.Length != 10)
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


                if (rouz_int >= 32 || rouz_int == 00)
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


 
       
 

        private void label2_Click(object sender, EventArgs e)
        {
            SearchPersonal s1 = new SearchPersonal();
            s1.ShowDialog();
        }

     
 
      
        private void button3_Click(object sender, EventArgs e)
        {
            try{

            if (textBox15.Text != "")
            {
              
                if (BarrasiTarikh() == false)
                {//"1391/03/28"

                

                    MsgBox.ShowMessage(this.Handle.ToInt32(), " تاریخ عضویت را صحیح وارد نمایید . مثلا :" + " " + "1391/03/28", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                }
                else
                {

                    cldbSql.CallDB("update tah set میزان_تحصیلات= N'" + comboBox5.Text + "',رشته_تحصیلی=N'" + textBox2.Text + "',گرایش_تحصیلی=N'" + textBox18.Text + "',دانشگاه=N'" + textBox3.Text + "' where tah.کد_عضویت=N'" + textBox15.Text + "' ");

                    cldbSql.CallDB("update shoghl set نوع_شغل= N'" + comboBox1.Text + "',مدت_شغل=N'" + textBox4.Text + "',عنوان_شغل=N'" + textBox5.Text + "',میزان_درآمد=N'" + textBox6.Text + "',نشانی_محل_کار=N'" + textBox7.Text + "' where shoghl.کد_عضویت=N'" + textBox15.Text + "' ");


                    cldbSql.CallDB("update faal set موضوع_فعالیت= N'" + comboBox2.Text + "',خلاصه_سوابق=N'" + textBox8.Text + "'where faal.کد_عضویت=N'" + textBox15.Text + "' ");


                    cldbSql.CallDB("update Sabt_ozv set  هدف_عضویت=N'" + textBox9.Text + "',تاریخ_عضویت= N'" + maskedTextBox1.Text + "',نوع_عضویت=N'" + comboBox3.Text + "'where Sabt_ozv.کد_عضویت=N'" + textBox15.Text + "' ");

                    cm.EndCurrentEdit();

                    button4.Visible = true;
                    dataGridView1.Enabled = true;


                    groupBox8.Enabled = true;


                    Disable_TextBox_ComboBox();

                }
            }

            else
            {
 
                MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ سطری انتخاب نشده است", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);         
            
            }

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();


        }
 
      

    

        private void EditParvande_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db2DataSet.Sabt_ozv' table. You can move, or remove it, as needed.

            Disable_RightClick_Menu_Field();
 
        }

        
        private void button2_Click(object sender, EventArgs e)
        {

            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات,tah.گرایش_تحصیلی ,tah.رشته_تحصیلی  ,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت ");
                    
        
        }
 

   

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "نامشخص" || comboBox5.Text == "کم سواد" || comboBox5.Text == "ابتدایی" || comboBox5.Text == "راهنمایی" || comboBox5.Text == "دبیرستان" || comboBox5.Text == "غیره" || comboBox5.Text == "دیپلم" || comboBox5.Text == "حوزوی")
            {

                textBox2.Text = "";
                textBox3.Text = "";

                textBox2.Enabled = false;
                textBox3.Enabled = false;


            }


            if (comboBox5.Text == "کاردانی" || comboBox5.Text == "کارشناسی" || comboBox5.Text == "کارشناسی ارشد" || comboBox5.Text == "دکترا")
            {

                textBox2.Enabled = true;
                textBox3.Enabled = true;


            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "نامشخص" || comboBox1.Text == "دانشجو" || comboBox1.Text == "محصل")
            {

                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;

            }


            if (comboBox1.Text == "مشاغل آزاد" || comboBox1.Text == "مشاغل دولتی" || comboBox1.Text == "غیره")
            {

                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;

            }

        }




        public void Disable_RightClick_Menu_Field()
        {


            // غیر فعال کردن راست کلیک
 
            comboBox1.ContextMenu = new ContextMenu();
            comboBox5.ContextMenu = new ContextMenu();
            comboBox2.ContextMenu = new ContextMenu();

            comboBox3.ContextMenu = new ContextMenu();


            


        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //    هیچ نوشت ای را نمی توان وارد نمود
            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
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

            //    هیچ نوشت ای را نمی توان وارد نمود
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

            //    هیچ نوشت ای را نمی توان وارد نمود
            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            //    هیچ نوشت ای را نمی توان وارد نمود
            if ("".IndexOf(e.KeyChar.ToString()) >= 0)
            {

                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
       
    

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text != "")
            {


                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات  ,tah.گرایش_تحصیلی,tah.رشته_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.فامیلی like N'%" + textBox19.Text + "%' ");

            }

            else
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات,tah.گرایش_تحصیلی ,tah.رشته_تحصیلی  ,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and  Personel.کد_عضویت = N'' ");
                Clear_ViewMoeshekhasatePersonel();
            }

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            if (textBox21.Text != "")
            {
          
            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات ,tah.گرایش_تحصیلی ,tah.رشته_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_ملی like N'%" + textBox21.Text + "%' ");
                    
            }

         else
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات,tah.گرایش_تحصیلی ,tah.رشته_تحصیلی  ,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and  Personel.کد_عضویت = N'' ");
                Clear_ViewMoeshekhasatePersonel();
            }

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if(textBox20.Text !="") {
             
           SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات,tah.گرایش_تحصیلی ,tah.رشته_تحصیلی  ,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.نام like N'%" + textBox20.Text + "%' ");
            
               }
         else {

             SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات,tah.گرایش_تحصیلی ,tah.رشته_تحصیلی  ,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and  Personel.کد_عضویت = N'' ");
             Clear_ViewMoeshekhasatePersonel();
         }

        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (textBox10.Text != "" & textBox11.Text != "")
            {

                 

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات ,tah.گرایش_تحصیلی  ,tah.رشته_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.نام = N'" + textBox11.Text + "' and Personel.فامیلی  = N'" + textBox10.Text + "'");
            }

            else
            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), " برای جستجو سبک 2 ، باید نام و فامیلی هر دو نوشته شوند", " توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            groupBox8.Enabled = false;
            label1.Enabled = false;

            label26.Enabled = true;
            groupBox9.Enabled = true;
            //---------------------------------
    
            textBox17.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";


            //-------------------------------

            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات , tah.گرایش_تحصیلی  , tah.رشته_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");

            Clear_ViewMoeshekhasatePersonel();


        }



        public void Clear_ViewMoeshekhasatePersonel()
        {

            comboBox5.Text = "";
            textBox2.Clear();

            textBox18.Clear();


            textBox3.Clear();
            //---

            comboBox1.Text = "";
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            //------
            comboBox2.Text = "";
            textBox8.Clear();

            //------

            textBox9.Clear();
            maskedTextBox1.Clear();
            comboBox3.Text = "";

            textBox15.Clear();

            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();

            textBox1.Clear();


            pictureBox1.Image = null;
        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox8.Enabled = true;
            label1.Enabled = true;

            label26.Enabled = false;
            groupBox9.Enabled = false;

            //-------------------------------

            textBox11.Text = "";
            textBox10.Text = "";
       
            //-------------------------------

        

            SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات , tah.گرایش_تحصیلی  , tah.رشته_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت = N'' ");
            Clear_ViewMoeshekhasatePersonel();

        }




        private void textBox17_Enter(object sender, EventArgs e)
        {
            textBox19.Text = "";
            textBox20.Text = "";

            textBox21.Text = "";
        }

         
        private void textBox19_Enter(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox20.Text = "";

            textBox21.Text = "";
        }

        private void textBox20_Enter(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox19.Text = "";

            textBox21.Text = "";
        }


        private void textBox21_Enter(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox19.Text = "";

            textBox20.Text = "";
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

            if (textBox17.Text != "")
            {


                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات , tah.گرایش_تحصیلی  , tah.رشته_تحصیلی,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and Personel.کد_عضویت like N'%" + textBox17.Text + "%' ");

            }

            else
            {

                SearchDB("select Personel.عکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,tah.میزان_تحصیلات,tah.گرایش_تحصیلی ,tah.رشته_تحصیلی  ,tah.دانشگاه,shoghl.نوع_شغل,shoghl.مدت_شغل,shoghl.عنوان_شغل,shoghl.میزان_درآمد,shoghl.نشانی_محل_کار,faal.موضوع_فعالیت,faal.خلاصه_سوابق,Sabt_ozv.هدف_عضویت,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,tah,shoghl,faal,Sabt_ozv where Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت  and  Personel.کد_عضویت = N'' ");
                Clear_ViewMoeshekhasatePersonel();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox15.Text != "")
            {
                
                button3.Visible = true;
              
                button4.Visible = false;

                groupBox8.Enabled = false;

                dataGridView1.Enabled = false;

                Enable_TextBox_ComboBox();

            }

            else

            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), " هیچ سطری انتخاب نشده است", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        
        


        
     

        
       
    }
}
