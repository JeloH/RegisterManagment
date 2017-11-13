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

    
    public partial class AddYaddasht : Form
    {

       // cldbSql cld_s = new cldbSql();
        
        string tarikh_G = "";
        SqlCommand SqlCom;


        public AddYaddasht()
        {
            InitializeComponent();
            
            comboBox12.MaxLength = 2;
            comboBox13.MaxLength = 2;

            textBox2.MaxLength = 4;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void BarrasiTarikh() {

            if (comboBox13.Text != "" & comboBox12.Text != "" & textBox2.Text != "")
            {


                if (comboBox13.Text != "")
                {
                    int num1 = int.Parse(comboBox13.Text);

                    if (num1 >= 32 || comboBox13.Text == "00" || comboBox13.Text == "0")
                    {

 
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ یادداشت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                        comboBox13.Text = "";

                    }

                }






                //برای اینکه عدد بزرگتر از 12 ماه وارد نشودو  ..و.و



                if (comboBox12.Text != "")
                {
                    int num2 = int.Parse(comboBox12.Text);

                    if (num2 >= 13 || comboBox12.Text == "00" || comboBox12.Text == "0")
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ یادداشت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                        comboBox12.Text = "";

                    }
                }



                if (textBox2.Text != "")
                {
                    int num3 = int.Parse(textBox2.Text);
                    if (num3 <= 999 || textBox2.Text == "0000" || textBox2.Text == "000" || textBox2.Text == "00" || textBox2.Text == "0")
                    {

                        MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ یادداشت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                         textBox2.Text = "";

                    }

                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                errorProvider1.Clear();


                //------------------------------------------بررسی تاریخ وارد شده--------------------------------------

                BarrasiTarikh();

                //--------------------------------------------------------------------------------




                //--------------------------تنظیم تاریخ یادداشت ---------------------


                //------------------------------------------------------

                if (comboBox13.Text == "") errorProvider1.SetError(comboBox13, "  روز تاریخ را وارد کنيد");
                else if (comboBox12.Text == "") errorProvider1.SetError(comboBox12, "  ماه تاریخ را وارد کنيد");
                else if (textBox2.Text == "") errorProvider1.SetError(textBox2, "  سال تاریخ را وارد کنيد");



                else if (textBox3.Text == "") errorProvider1.SetError(textBox3, "موضوع را وا وارد نمایید");


                else if (textBox4.Text == "") errorProvider1.SetError(textBox4, " متن را وا وارد نمایید");



                else
                {


                    insertYaddasht();



                    textBox1.Text = "";

                    textBox3.Text = "";
                    textBox4.Text = "";

                    pictureBox1.Image = null;

                }

            
             }
                catch (Exception ex)
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }
            
            
            
        }






        public void insertYaddasht() {


            try
            {


                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection CN = new SqlConnection(str1);




                //--------------------------------------------------------------
                string str_rouz_G = "", str_mah_G = "", str_sal_G = "";

                str_rouz_G = comboBox13.Text;
                str_mah_G = comboBox12.Text;
                str_sal_G = textBox2.Text;

                tarikh_G = str_sal_G + "/" + str_mah_G + "/" + str_rouz_G;

                //----------------------------------------------------



                if (textBox1.Text != "")
                {
                    // اگر تصویر انتخاب شده است

                    string qry = "insert into Yaddasht(تاریخ,موضوع,متن,تصویر,آدرس_تصویر)Values(@c1,@c2,@c3,@c4,@c5)";

                    SqlCom = new SqlCommand(qry, CN);

                    byte[] imageData = Class_mft.ReadFile(textBox1.Text);
                    SqlCom.Parameters.Add(new SqlParameter("@c1", (object)tarikh_G));
                    SqlCom.Parameters.Add(new SqlParameter("@c2", (object)textBox3.Text));
                    SqlCom.Parameters.Add(new SqlParameter("@c3", (object)textBox4.Text));

                    SqlCom.Parameters.Add(new SqlParameter("@c4", (object)imageData));


                    SqlCom.Parameters.Add(new SqlParameter("@c5", (object)textBox1.Text));


                }
                else
                {
                    //اگر تصویر انتخاب نشده باشد  

                    string qry = "insert into Yaddasht(تاریخ,موضوع,متن)Values(@c1,@c2,@c3)";

                    SqlCom = new SqlCommand(qry, CN);

                    SqlCom.Parameters.Add(new SqlParameter("@c1", (object)tarikh_G));
                    SqlCom.Parameters.Add(new SqlParameter("@c2", (object)textBox3.Text));
                    SqlCom.Parameters.Add(new SqlParameter("@c3", (object)textBox4.Text));

                    //  SqlCom.Parameters.Add(new SqlParameter("@c4", (object)imageData));


                }


                CN.Open();

                SqlCom.ExecuteNonQuery();

                MsgBox.ShowMessage(this.Handle.ToInt32(), "عملیات ثبت با موفقیت انجام شد", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         


                CN.Close();

            }
            catch (Exception er)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }

            finally {

           
                MaxNumberYaddasht();
            }

        }






        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();

            try{

            if (dlgRes != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = dlg.FileName;

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                textBox1.Text = dlg.FileName;

            }

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }

        private void AddYaddasht_Load(object sender, EventArgs e)
        {
            MaxNumberYaddasht();
        }

        public void MaxNumberYaddasht() {

            try{

            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection CN = new SqlConnection(str1);

            CN.Open();

            SqlCommand cmd = new SqlCommand("select max(شماره) as آخرین_شماره from Yaddasht", CN);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {


                textBox5.Text = dr["آخرین_شماره"].ToString();
            
            
            }

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }

        private void comboBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar.ToString()) >= 0) { 
          
                
                    e.Handled=false;
                
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
    }
}
