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
    public partial class Form_Email_MultiSelect : Form
    {

      

        cldbSql cmdsql = new cldbSql();

        DataSet ds;
        SqlDataAdapter da;
        DataView dv;
        CurrencyManager cm;

        SqlConnection con;
        SqlCommand com;
        SqlCommandBuilder comb;

        Form_Email_Send_MultiSelect f_e_s_m = null;


        public Form_Email_MultiSelect(Form_Email_Send_MultiSelect f_e_send_m)
        {
            this.f_e_s_m = f_e_send_m;

            InitializeComponent();

            comboBox1.SelectedIndex = comboBox1.FindStringExact("فرهنگی");
            comboBox3.SelectedIndex = comboBox3.FindStringExact("فامیلی");
      
      

        }

        private void Form_Email_MultiSelect_Load(object sender, EventArgs e)
        {
            SearchDB("select Personel.چکباکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,Personel.پست_الکترونیکی  from Personel where پست_الکترونیکی !='' ");
        }



        public void SearchDB(string str)
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





           
           //     MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


           


        }


        public void saveEditDB()
        {
           


                dataGridView1.EndEdit();

                cm.EndCurrentEdit();

                da.Update(ds.Tables[0]);

           


        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            saveEditDB();
            SearchDB("select Personel.چکباکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,Personel.پست_الکترونیکی  from Personel where پست_الکترونیکی !='' ");
    
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

             
                if (textBox5.Text != "")
                {



                    saveEditDB();
                    SearchDB("select Personel.چکباکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,Personel.پست_الکترونیکی  from Personel where  پست_الکترونیکی !='' and " + comboBox3.Text + " like N'%" + textBox5.Text + "%' ");
                    
                }
                else
                {
                    saveEditDB();
                    SearchDB("select Personel.چکباکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,Personel.پست_الکترونیکی  from Personel where کد_عضویت = N'' ");
           

               }

        

        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveEditDB();
            SearchDB("select Personel.چکباکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,Personel.پست_الکترونیکی  from Personel,faal where Personel.کد_عضویت=faal.کد_عضویت and   Personel.پست_الکترونیکی !='' and faal.موضوع_فعالیت  = N'" + comboBox1.Text + "' ");
                
        }

        private void button15_Click(object sender, EventArgs e)
        {

            saveEditDB();
            
            // این کد اضافه می شود تا هنگامی که یک انتخای صورت گرفته است پیام ذخیره نمایش داده شود
            // در غیر اینصورت close
             
                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection con = new SqlConnection(str1);

                con.Open();
                //جلوگیری از تکرار کد_ملی

                SqlDataAdapter da = new SqlDataAdapter("select * from Personel where چکباکس='true' and  پست_الکترونیکی !='' ", con);
                DataTable dt = new DataTable();




                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {

                    this.Close();

                    }

                    else
                    {


                        DialogResult dr = MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا انتخاب ها ذخیره شوند ؟", " ذخیره انتخاب ها", "بله", "خیر", "انصراف", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                        if (dr == DialogResult.Yes)
                        {
                            saveEditDB();

                            f_e_s_m.ViewGiandegan(" select Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,Personel.پست_الکترونیکی  from Personel where پست_الکترونیکی !='' and چکباکس='true' ");

                            this.Close();

                        }

                        else if (dr == DialogResult.No)
                        {
                            cldbSql.CallDB("update Personel set چکباکس= 'false'");
                            this.Close();
                        }

                        else if (dr == DialogResult.Cancel)
                        {

                        }


                    }

                
            }
             

        private void button2_Click(object sender, EventArgs e)
        {
           saveEditDB();

            cldbSql.CallDB("update Personel set  چکباکس= 'true' where  پست_الکترونیکی !=''  ");

            SearchDB("select Personel.چکباکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,Personel.پست_الکترونیکی  from Personel where  پست_الکترونیکی !='' ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveEditDB();

            cldbSql.CallDB("update Personel set چکباکس= 'false'where  پست_الکترونیکی !='' ");

            SearchDB("select Personel.چکباکس,Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.کد_ملی,Personel.پست_الکترونیکی  from Personel  where  پست_الکترونیکی !=''  ");

        }


    }
}
