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
    public partial class Print_Cart_ozv : Form
    {
         cldbSql cmdsql = new cldbSql();

        string Report_SefarehiCard_or_FixCard = "is_card_Empty_Select_Card_or";

   
/*
        enum Type_report {


            Fix_report_Card = "..\\Debug\\rpt\\rpt4\\Fix_Report_Card.rdlc",


            Sefareshi_report_Card = "..\\Debug\\rpt\\rpt4\\Report_Card_Sefareshi.rdlc",

        };
 * */
        


        public Print_Cart_ozv()
        {

            
            
            
            InitializeComponent();

          
            Transparent_Label();
        }

        private void Print_Cart_ozv_Load(object sender, EventArgs e)
        {


            ViewCard();

         
         //   label2.Parent = PictureBox;
             
                //    ViewCard();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
               try
                {


                   if (textBox1.Text != "")
           
                   {

                       SelectPersonelPrintCard("select Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.عکس,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Personel.کد_عضویت like N'" + textBox1.Text + "' ");
                       //SearchDB("select Personel.کد_عضویت,Personel.نام,Personel.فامیلی,Personel.عکس,Sabt_ozv.تاریخ_عضویت,Sabt_ozv.نوع_عضویت from Personel,Sabt_ozv where Personel.کد_عضویت=Sabt_ozv.کد_عضویت  and Personel.کد_عضویت like N'" + textBox1.Text + "' ");

 
                   }
             
               }

                catch (Exception ex)
                {

                    
                    MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }

            
        }

        
       
 


 
 
 

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {




                if (textBox1.Text != "")
                {

                    //درصورتی که سبک کارت انتخاب شده وجود داشت یا به عبارتی حذف نشده اند
                    if (Report_SefarehiCard_or_FixCard == "is_select_card")
                    {


                        Report4 r = new Report4("..\\Debug\\rpt\\rpt4\\Report_Card_Sefareshi.rdlc", "select * from Personel,Sabt_ozv,ser,cardDesign,SelectCard where Personel.کد_عضویت=Sabt_ozv.کد_عضویت and cardDesign.nameDesign=SelectCard.nameDesign  and Personel.کد_عضویت = '" + int.Parse(label8.Text) + "' ");
                        r.ShowDialog();
                    }

                    //استفاده بکن Fix_Report_Card.rdlcدرصورتی که سبک کارت وجود ندارد از
                    //تغییر کند sql و همچنین کد 

                    else if (Report_SefarehiCard_or_FixCard == "is_card_Empty_Select_Card_or")
                    {

                        Report4 r = new Report4("..\\Debug\\rpt\\rpt4\\Fix_Report_Card.rdlc", "select * from Personel,Sabt_ozv,ser where Personel.کد_عضویت=Sabt_ozv.کد_عضویت   and Personel.کد_عضویت = '" + int.Parse(label8.Text) + "' ");
                        r.ShowDialog();

                    }

                }
                else
                {

                 
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "هیچ عضویتی نمایان نیست", " توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                }

            }

            catch(Exception ex)
            
            {

              
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

            }
           // Report3 r = new Report3("..\\Debug\\rpt\\rpt3\\Report_Card_style3_AbiGol_ba_logo.rdlc", "select * from Personel,Sabt_ozv,ser where Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت = '" + label6.Text + "' ");
           //  r.ShowDialog();

        }

      
        private void button4_Click(object sender, EventArgs e)
        {
            label15.AutoSize = false;
        }



   
        public void SelectPersonelPrintCard(string strCodeSql)
        {


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

                    MsgBox.ShowMessage(this.Handle.ToInt32(), "چنین شماره عضویتی وجود ندارد", " توجه ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                }

                else
                {

                    if (dt.Rows[0]["کد_عضویت"].ToString() != "")
                    {

                        button1.Enabled = true;
                        pictureBox1.Visible = true;

                        label8.Text = dt.Rows[0]["کد_عضویت"].ToString();

                        //   Binding b = new Binding("Text", dv, "تاریخ_عضویت", true);
                        //   b.FormatString = "yyyy/MM/dd";
                        //     b.FormatString = "yyyy/MM/dd hh:mm tt";

                        //label12.Text = DateTime.ParseExact(dt.Rows[0]["تاریخ_عضویت"].ToString(), "yyyy/MM/dd", null).ToString("yyyy/MM/dd");
                        label12.Text = dt.Rows[0]["تاریخ_عضویت"].ToString();

                      //  label12.Text = DateTime.ParseExact(label12.Text, "MM/dd/yyyy", null).ToString("yyyy/MM/dd");
                     
                       // textBox2 .Text = dt.Rows[0]["تاریخ_عضویت"].ToString();


                        // label11.Text = reader["نوع_عضویت"].ToString();

                        label9.Text = dt.Rows[0]["نام"].ToString();
                        label10.Text = dt.Rows[0]["فامیلی"].ToString();



                        pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0]["عکس"]));

                    }

                }

            }

            catch(Exception ex)
            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }
            
        }



        public void ViewCard() {
           
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BackgroundImage = null;

            
            try
            {

            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection con = new SqlConnection(str1);

            con.Open();
            //جلوگیری از تکرار کد_ملی

            string s1 = "select *  from cardDesign,ser,SelectCard where cardDesign.nameDesign=SelectCard.nameDesign ";
            SqlDataAdapter da = new SqlDataAdapter(s1, con);
            DataTable dt = new DataTable();

            byte[] img_by = null;


            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {

                //----------این کدملی اصلا وجود ندارد -------------------------------------
                Report_SefarehiCard_or_FixCard = "is_card_Empty_Select_Card_or";
 
                panel1.BackColor = Color.Aquamarine;// rdlc در صورتی که کارتی وجود نداشت پشت زمینه به رنگ با توجه به 

                label11.Visible = true;
                // Report_SefarehiCard_or_FixCard = "..\\Debug\\rpt\\rpt4\\Fix_Report_Card.rdlc";
                //  CodeSql_SefarehiCard_or_FixCard = "..\\Debug\\rpt\\rpt4\\Report_Card_Sefareshi.rdlc";
                 
                //-----------------------------------------------------------------------


            }


            else
            {
                

                Report_SefarehiCard_or_FixCard = "is_select_card";

                //    Report_SefarehiCard_or_FixCard = "..\\Debug\\rpt\\rpt4\\Report_Card_Sefareshi.rdlc";
                //CodeSql_SefarehiCard_or_FixCard = "..\\Debug\\rpt\\rpt4\\Report_Card_Sefareshi.rdlc";

                label1.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());

                label3.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());
                label4.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());
                label5.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());
                label6.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());
                label7.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());
                label8.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());
                label9.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());
                label10.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());
                //label11.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString();
                label12.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());

                label13.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());

                label15.ForeColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["fontcolor"].ToString());

                label15.Text = dt.Rows[0]["Name_Company"].ToString();

                pictureBox2.Image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0]["logo"]));

                if (dt.Rows[0]["bgcolor"].ToString() != "")
                {

                    panel1.BackColor = System.Drawing.ColorTranslator.FromHtml(dt.Rows[0]["bgcolor"].ToString());


                }


                else
                {

                    img_by = (byte[])dt.Rows[0]["img"];

                    panel1.BackgroundImage = Image.FromStream(new MemoryStream((byte[])dt.Rows[0]["img"]));

                }


            }
          
            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }



        }

    


        public void Transparent_Label() {


            label1.Parent = panel1;
           // label2.Parent = panel1;
            label3.Parent = panel1;
            label4.Parent = panel1;
            label5.Parent = panel1;
            label6.Parent = panel1;
            label7.Parent = panel1;
            label8.Parent = panel1;
            label9.Parent = panel1;
            label10.Parent = panel1;
            //label11.Parent = panel1;
            label12.Parent = panel1;
            label13.Parent = panel1;
          //  label14.Parent = panel1;
            label15.Parent = panel1;
            //label16.Parent = panel1;




            label1.BackColor = Color.Transparent;
          //  label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            //label11.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent;
            label13.BackColor = Color.Transparent;
            //label14.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            //label16.BackColor = Color.Transparent;




        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

    

    }
}
