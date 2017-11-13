using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace Applictaion_Ozviat
{
    public partial class EditYaddsht : Form
    {
        cldbSql cmdsql = new cldbSql();
        
               CurrencyManager cm;
        
        public EditYaddsht()
        {
            InitializeComponent();

            
        
        }

        private void EditYaddsht_Load(object sender, EventArgs e)
        {
            SearchDB("select شماره,تاریخ,موضوع,متن,تصویر from Yaddasht");
        }


        public void SearchDB(string st) {

            try{

            DataBindingClear();

            DataView dv;
            dv = cmdsql.vt(st);
            dataGridView1.DataSource = dv;

            dataGridView1.Columns["تصویر"].Visible = false;
          //  dataGridView1.Columns["تاریخ"].DefaultCellStyle.Format = "yyyy/MM/dd";

            DataBindingAdd(dv);

            cm = (CurrencyManager)BindingContext[dv];

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
        }




        public void DataBindingClear()
        {
            textBox1.DataBindings.Clear();
            
            maskedTextBox1.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();


        }



        public void DataBindingAdd(DataView dv)
        {

            textBox1.DataBindings.Add("Text", dv, "شماره");

           

          //  Binding b = new Binding("Text", dv, "تاریخ", true);
          //  b.FormatString = "yyyy/MM/dd";
          
            maskedTextBox1.DataBindings.Add("Text", dv, "تاریخ");

            textBox3.DataBindings.Add("Text", dv, "موضوع");

            textBox4.DataBindings.Add("Text", dv, "متن");

           //     b.FormatString = "yyyy/MM/dd hh:mm tt";

          
            //textBox4.DataBindings.Add("Text", dv, "آدرس_عکس");
          
            pictureBox1.DataBindings.Add("image", dv, "تصویر", true);
        }


        public void Disable_TextBox_ComboBox()
        {
          //  textBox1.Enabled = false;

            maskedTextBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            button3.Enabled = false;

        }



        public void Enable_TextBox_ComboBox()
        {
            //textBox1.Enabled = true;

            maskedTextBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

            button3.Enabled = true;

        }





        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox6.Text != "")
            {
                SearchDB("select * from Yaddasht where شماره like '%" + textBox2.Text + "%' ");

            }
            else
            {
                SearchDB("select * from Yaddasht where شماره = '' ");

            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
         
            if (textBox6.Text != "")
            {
                SearchDB("select * from Yaddasht where موضوع like '%" + textBox5.Text + "%' ");

            }
            else
            {
                SearchDB("select * from Yaddasht where موضوع = N'' ");


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {



                if (MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا عملیات حذف انجام شود ؟", "حذف ", "بله", "خیر", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes)
                {



                    try
                    {

                        string str1 = "";
                        str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                        SqlConnection con = new SqlConnection(str1);
                        SqlCommand com = con.CreateCommand();
                        com.CommandText = "delete from Yaddasht where  شماره=N'" + textBox1.Text + "'";

                        com.CommandType = CommandType.Text;

                        DataSet ds = new DataSet();

                        SqlDataAdapter da = new SqlDataAdapter(com);

                        SqlCommandBuilder comb = new SqlCommandBuilder(da);

                        da.Fill(ds);



                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        maskedTextBox1.Text = "";
                        textBox5.Text = "";


                        cm.RemoveAt(cm.Position);


                    }
                    catch (Exception)
                    {


                        MsgBox.ShowMessage(this.Handle.ToInt32(), "دیگر رکوردی برای حذف وجود ندارد ", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


                    }


                }


            }

            else
            {
                MsgBox.ShowMessage(this.Handle.ToInt32(), "رکوردی برای حذف وجود ندارد", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
           

            }

        }



        public void UpdatePicturePersonel()
        {
            //به خاطر این نوشته شده تا زمانی که آدرس عکس  جدید داده شد عملیات بروزرسانی انجام شود if
            //اگر نباشد خطا بوجود می آید if 

            if (textBox6.Text != "")
            {
                try{

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection CN = new SqlConnection(str1);

                string qry = "update Yaddasht set آدرس_تصویر=@Address_aks,تصویر=@aks where شماره=N'" + textBox1.Text + "'  ";




                SqlCommand cmd = new SqlCommand(qry, CN);



                byte[] imageData = Class_mft.ReadFile(textBox6.Text);

                cmd.Parameters.Add("@aks", SqlDbType.VarBinary).Value = imageData;//برای به روز رسانی یا برای نماش عکس نیاز به وجود آدرس عکس نمی باشد همان فیلد باینری کافی می باشد
                cmd.Parameters.Add("@Address_aks", SqlDbType.NVarChar).Value = textBox6.Text;//



                CN.Open();

                cmd.ExecuteNonQuery();

                CN.Close();


                }
                catch (Exception ex)
                {

                    MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }


            }


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
                 
                     MsgBox.ShowMessage(this.Handle.ToInt32(), "روز تاریخ عضویت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }




                if (mah_int >= 13 || mah_int == 00)
                {

                    bf = false;
                     
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "ماه تاریخ عضویت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            
                }



                if (sall_int <= 999 || sall_int == 0000)
                {

                    bf = false;
                     
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "سال تاریخ عضویت را صحیح وارد نمایید", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }

            }
            return bf;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            try{

            if (textBox1.Text != "")
            {



                if (BarrasiTarikh() == false)
                {//"1391/03/04"


                    MsgBox.ShowMessage(this.Handle.ToInt32(), " تاریخ یادداشت را صحیح وارد نمایید . مثلا :" + " " + "1391/03/28", "!! توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         



                }
                else
                {


                    if (pictureBox1.Image != null)
                    {
                        cldbSql.CallDB("Update Yaddasht set تاریخ='" + maskedTextBox1.Text + "' ,موضوع='" + textBox3.Text + "',متن='" + textBox4.Text + "' ,آدرس_تصویر='" + textBox6.Text + "'  where شماره=N'" + textBox1.Text + "' ");
                        UpdatePicturePersonel();
                        cm.EndCurrentEdit();
                    }
                    else if (pictureBox1.Image == null)
                    {

                        cldbSql.CallDB("Update Yaddasht set تاریخ='" + maskedTextBox1.Text + "' ,موضوع='" + textBox3.Text + "',متن='" + textBox4.Text + "',آدرس_تصویر='" + textBox6.Text + "'   where شماره=N'" + textBox1.Text + "' ");
                        cm.EndCurrentEdit();


                    }

                    
                    button1.Visible = false;
                    button6.Visible = true;

                    groupBox1.Enabled = true;


                    dataGridView1.Enabled = true;

                    Disable_TextBox_ComboBox();

                }

            }

            else if (textBox1.Text == "")
            {

                 
                MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ یادادشتی برای ذخیره انتخاب نشده است"," ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }


            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            SearchDB("select * from Yaddasht");

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

                textBox6.Text = dlg.FileName;

            }

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button6.Visible = false;

            groupBox1.Enabled = false;


            dataGridView1.Enabled = false;

            Enable_TextBox_ComboBox();

        }
   

        
    }
}
