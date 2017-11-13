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


    public partial class Print_Yaddasht : Form
    {

        cldbSql cmdsql = new cldbSql();

        string Print_Yaddasht_NotImg_YesImg = "Yes_Img";

        public Print_Yaddasht()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {




                if (textBox1.Text != "")
                {

                    //درصورتی که سبک کارت انتخاب شده وجود داشت یا به عبارتی حذف نشده اند
                    if (Print_Yaddasht_NotImg_YesImg == "Yes_Img")
                    {


                        Report6 r = new Report6("..\\Debug\\rpt\\rpt6\\Print_Yaddasht_Not_Img.rdlc", "select * from Yaddasht,ser where  شماره like'" + textBox1.Text + "' ");
                        r.ShowDialog();
                    }

                    //استفاده بکن Fix_Report_Card.rdlcدرصورتی که سبک کارت وجود ندارد از
                    //تغییر کند sql و همچنین کد 

                    else if (Print_Yaddasht_NotImg_YesImg == "Not_Img")
                    {

                        Report6 r = new Report6("..\\Debug\\rpt\\rpt6\\Print_Yaddasht_Yes_Img.rdlc", "select * from Yaddasht,ser where  شماره like '" + textBox1.Text + "' ");
                        r.ShowDialog();

                    }

                }

                else
                {
                     MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ یادداشتی نمایان نیست ", "   ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
                }

            }

            catch (Exception ex)
            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
            }
        }
 
     
 


        public void SelectPersonelPrintCard(string strCodeSql)
        {

           // panel1.BackColor = Color.WhiteSmoke;
           // panel1.BackgroundImage = null;
           // byte[] img_by = null;

            try
            {

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection con = new SqlConnection(str1);

                con.Open();
                //جلوگیری از تکرار کد_ملی

                SqlDataAdapter da = new SqlDataAdapter(strCodeSql, con);
                DataTable dt = new DataTable();




                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {

                    //----------این کدملی اصلا وجود ندارد -------------------------------------
                    //  Report_SefarehiCard_or_FixCard = "is_card_Empty_Select_Card_or";

                    //   panel1.BackColor = Color.Aquamarine;// rdlc در صورتی که کارتی وجود نداشت پشت زمینه به رنگ با توجه به 

                    //   label11.Visible = true;
                    // Report_SefarehiCard_or_FixCard = "..\\Debug\\rpt\\rpt4\\Fix_Report_Card.rdlc";
                    //  CodeSql_SefarehiCard_or_FixCard = "..\\Debug\\rpt\\rpt4\\Report_Card_Sefareshi.rdlc";

                    //-----------------------------------------------------------------------

            //        button4.Enabled = false;

                    
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "چنین شماره یادداشتی وجود ندارد", "توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
                }


                else
                {

                    button4.Enabled = true;
            
                    Print_Yaddasht_NotImg_YesImg = "Yes_Img";

                    pictureBox1.Image = null;


                    textBox1.Text = dt.Rows[0]["شماره"].ToString();

                    textBox6.Text = String.Format("{0:dd/MM/yyy}", dt.Rows[0]["تاریخ"].ToString()).ToString();

                //    label12.Text = String.Format("{0:dd/MM/yyy}", dt.Rows[0]["تاریخ_عضویت"].ToString()).ToString();


                     textBox3.Text = dt.Rows[0]["موضوع"].ToString();

                    textBox4.Text = dt.Rows[0]["متن"].ToString();


                    if (dt.Rows[0]["تصویر"].ToString() != "")
                    {
                        Print_Yaddasht_NotImg_YesImg = "Not_Img";

                        pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0]["تصویر"]));

                    }


                }
            }

            catch (Exception ex)
            {
            
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString() ,"خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
            }
                
           

        }

       


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (textBox2.Text != "")
                {

                    SelectPersonelPrintCard("select * from Yaddasht,ser where  شماره like '" + textBox2.Text + "'");
            




                }

            }

            catch (Exception ex)
            {


                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


      //  Main m1 = new Main();

        private void label2_Click(object sender, EventArgs e)
        {
            

            SearchYaddashtha search_yaddsht = new SearchYaddashtha();
          //  search_yaddsht.MdiParent = m1;
            search_yaddsht.ShowDialog();
     
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
