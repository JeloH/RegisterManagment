using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;
/*

 * یه نام خدا
 * 
 *  این نرم افزار  برای انجام خدمات ثبت نام موسسه هاو کانون های فرهنگی/ مذهبی / علمی طراحی شده می باشد 
 *  
 *  Hjelovdar@gmail.com
*/

namespace Applictaion_Ozviat
{
    public partial class Main : Form
    {

        string Report_SefarehiCard_or_FixCard = "is_card_Empty_Select_Card_or";


        
        public static string E_Moshakh = "1", E_Parvande = "1", E_Report = "1", E_Sabt = "1", E_SMS = "1", E_Mail = "1";

        datetime datetime = new datetime();

        public static string Name_company = "1";

        public Main()
        {

            InitializeComponent();

          
        }




        private static string str;



        public static string Str
        {
            get { return Main.str; }
            set { Main.str = value; }
        }

        public static string s20;

        public static string S20
        {
            get { return s20; }
            set { s20 = value; }



        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void جدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPersonal ap = new AddPersonal();
          
          //  ap.FormClosing+= (s1,e1)
          //  {
          ////  
          //      this.جدیدToolStripMenuItem.Enabled=true;
            
          //  } 
          //      this.جدیدToolStripMenuItem.Enabled=false;
            
            ap.MdiParent = this;
            ap.Show();
        }

        private void جToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchPersonal s1 = new SearchPersonal();
         
            s1.MdiParent = this;
            s1.Show();
        }

        private void مشخصاتاعضاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPersoal er = new EditPersoal();


            er.MdiParent = this;
            er.Show();
        }

        private void پروندهفنیToolStripMenuItem_Click(object sender, EventArgs e)
        {//
            EditParvande ed2 = new EditParvande();
            ed2.MdiParent = this;
            ed2.Show();
        }

        private void خروجToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            E_Moshakh = "";
            E_Parvande = "";
            E_Report = "";
            E_Sabt = "";
            E_Mail = "";
            E_SMS = "";
            this.Close();

            login l = new login();
            l.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }





        private void Main_Load_1(object sender, EventArgs e)
        {
            try{
            

            string c="", m="", y="";

            timer1.Enabled = true;

            label1.Text = datetime.day();

            datetime dom = new datetime();
            c = dom.daycount();

            m = datetime.month();

            y = datetime.year();
            DateTime dt = DateTime.Now;
         //   System.DateTime _Now = DateAndTime.Now;


            // label17.Text = y + "/" + m + "/" + c;
            label17.Text = dt.ToLongDateString().ToString();

            label1.Text = dt.DayOfWeek.ToString();


            if (E_Report == "مجوز دارد")
            {
                گزارشگیریToolStripMenuItem2.Enabled = true;
                toolStripSplitButton2.Enabled = true;

            }
            else if (E_Report == "مجوز ندارد")
            {
                گزارشگیریToolStripMenuItem2.Enabled = false;
                toolStripSplitButton2.Enabled = false;

            }



            if (E_Parvande == "مجوز دارد")
            {
                پروندهفنیToolStripMenuItem.Enabled = true;
                پروندهفنیToolStripMenuItem1.Enabled = true;


            }
            else if (E_Parvande == "مجوز ندارد")
            {
                پروندهفنیToolStripMenuItem.Enabled = false;
                پروندهفنیToolStripMenuItem1.Enabled = false;

            }



            if (E_Moshakh == "مجوز دارد")
            {
                مشخصاتاعضاToolStripMenuItem.Enabled = true;
                مشخصاتاعضاToolStripMenuItem1.Enabled = true;

            }
            else if (E_Moshakh == "مجوز ندارد")
            {
                مشخصاتاعضاToolStripMenuItem.Enabled = false;
                مشخصاتاعضاToolStripMenuItem1.Enabled = false;

            }



            if (E_Sabt == "مجوز دارد")
            {
                جدیدToolStripMenuItem.Enabled = true;
                ToolStripButton5.Enabled = true;

            }
            else if (E_Sabt == "مجوز ندارد")
            {
                جدیدToolStripMenuItem.Enabled = false;
                ToolStripButton5.Enabled = false;

            }






            if (E_Mail == "مجوز دارد")
            {
                emailToolStripMenuItem.Enabled = true;
                ToolStripButton5.Enabled = true;

            }
            else if (E_Mail == "مجوز ندارد")
            {
                emailToolStripMenuItem.Enabled = false;
                ToolStripButton5.Enabled = false;

            }




            if (E_SMS == "مجوز دارد")
            {
                sMSToolStripMenuItem.Enabled = true;
                ToolStripButton5.Enabled = true;

            }
            else if (E_SMS == "مجوز ندارد")
            {
                sMSToolStripMenuItem.Enabled = false;
                ToolStripButton5.Enabled = false;

            }



            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }


        }



        private void ایجادکاربرجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {



            AddUser_M f5 = new AddUser_M();  
            f5.MdiParent = this;
            f5.Show();
        }



        private void ToolStripButton5_ButtonClick(object sender, EventArgs e)
        {
            AddPersonal ap2 = new AddPersonal();
     
            ap2.MdiParent = this;
            ap2.Show();
        }

        private void مشخصاتاعضاToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditPersoal er2 = new EditPersoal();

           
            
            er2.MdiParent = this;
            er2.Show();
        }


        private void toolStripSplitButton5_ButtonClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        private void ویرایشکاربرToolStripMenuItem_Click(object sender, EventArgs e)
        {


            EditUser m_e_u = new EditUser();
            m_e_u.MdiParent = this;
            m_e_u.Show();


        }

        private void اپراتورToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditUser e5 = new EditUser();

               e5.MdiParent = this;
             e5.Show();
        }

        private void اجازهدسترسیبهاپراتورToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            MUserAccess f8 = new MUserAccess();

     
          f8.MdiParent = this;
          f8.Show();
        }

        private void اعضاToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchPersonal s = new SearchPersonal();
          
            s.MdiParent = this;
            s.Show();
        }



        private void پروندهاعضاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchParvandrFanni sf = new SearchParvandrFanni();

         
            sf.MdiParent = this;
            sf.Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
      
            label18.Text = DateTime.Now.ToLongTimeString();

        }



        
        private void لیستکلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpt1_Parv_Fardi rmf = new rpt1_Parv_Fardi();
  

            rmf.MdiParent = this;
            rmf.Show();

        }



        private void گزارشپیشرفتهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.MdiParent = this;
            f7.Show();
        }

        private void چاپکارتعضویتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void پشتبانگیریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup b = new Backup();
          
            b.MdiParent = this;
            b.Show();

        }

        private void بازیابیDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreDB rt = new RestoreDB();
           
            rt.MdiParent = this;
            rt.Show();

        }


        private void فرمارسالToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Form_Email_Send_Taki em = new Form_Email_Send_Taki();
           
         //   em.MdiParent = this;
        //    em.Show();


        }




        private void تنظیماتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Tanzimat_email tem = new Tanzimat_email();
          
            tem.MdiParent = this;
            tem.Show();
        }
         
       
        private void ویرایشکاربرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UEditUser f6 = new UEditUser(label11.Text);
           
            f6.MdiParent = this;
            f6.Show();

        }

     

        private void sMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_SMS fsms = new Form_SMS();
            fsms.MdiParent = this;
            fsms.Show();

        }

        private void یکعضوخاصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpt1_Parv_Fardi rpt1 = new rpt1_Parv_Fardi();
            
       
            rpt1.MdiParent = this;
            rpt1.Show();
        }

        private void لیستکلاعضاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report r = new Report("..\\Debug\\rpt\\rpt2\\Report_ListKol.rdlc", "select * from Personel,ser");
            r.MdiParent = this;
            r.Show();
        }
 


        public void PrintCart_KolPersonel()
        {
            try{

            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection CN = new SqlConnection(str1);



            CN.Open();

            try
            {


                string TarikheOzviat = "";
                string NonvehOzviat = "";


                SqlCommand objCmd = new SqlCommand("Select * from Personel,Sabt_ozv,ser where Personel.کد_عضویت=Sabt_ozv.کد_عضویت ", CN);
                SqlDataReader reader = objCmd.ExecuteReader();


                while (reader.Read())
                {

                    TarikheOzviat = reader["تاریخ_عضویت"].ToString();
                    NonvehOzviat = reader["نوع_عضویت"].ToString();


                }


                Report3 r = new Report3("..\\Debug\\rpt\\rpt3\\Report1.rdlc", "Select * from Personel,Sabt_ozv,ser where Personel.کد_عضویت=Sabt_ozv.کد_عضویت ");
                r.ShowDialog();

            }
            catch (Exception ex)
            {
                
                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }
            finally
            {
                CN.Close();
            }


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }


        }

        private void کلاعضاToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Report r = new Report("..\\Debug\\rpt\\rpt1\\Report_MoshakhasatFardi_ListKol.rdlc", "select * from Personel,ser  ");
            //r.MdiParent = this;
            r.ShowDialog();
        }

        private void کلاعضاToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Report r = new Report("..\\Debug\\rpt\\rpt1\\Report_ParvandFanni_ListKol.rdlc", "select * from Personel,Sabt_ozv,tah,shoghl,faal,ser where Personel.کد_عضویت=Sabt_ozv.کد_عضویت and Personel.کد_عضویت=tah.کد_عضویت and Personel.کد_عضویت=shoghl.کد_عضویت and Personel.کد_عضویت=faal.کد_عضویت ");

            r.ShowDialog();

        }

        private void یکعضوخاصToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rpt2_Parv_Fanni f2 = new rpt2_Parv_Fanni();
           
            f2.MdiParent = this;
            f2.Show();
        }

      



        public void View_Report()
        {

            try{

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
           SqlConnection     con = new SqlConnection(str1);

                con.Open();
                

                string s1 = "select *  from cardDesign,ser,SelectCard where cardDesign.nameDesign=SelectCard.nameDesign ";
              SqlDataAdapter  da = new SqlDataAdapter(s1, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {

                    //----------  هیچ کارتی انتخاب نشده است-------------------------------------
                    Report_SefarehiCard_or_FixCard = "is_card_Empty_Select_Card_or";
                    //-----------------------------------------------------------------------


                }


                else
                {
                    // کارت انتخاب شده است 

                    Report_SefarehiCard_or_FixCard = "is_select_card"; 

                
                }


            }
            catch (Exception)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);


            }




        }

        private void انتخابسبککارتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelcectCard s = new SelcectCard();
            s.MdiParent = this;
            s.Show();
        }

        private void ایجادسبککارتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignCard s = new DesignCard();
            s.MdiParent = this;
            s.Show();
        }

        private void حذفسبککارتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteStyleCard dsc = new DeleteStyleCard();
            dsc.MdiParent = this;
            dsc.Show();

        }

        private void یکعضوخاصToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Print_Cart_ozv p_cart = new Print_Cart_ozv();

            p_cart.MdiParent = this;
            p_cart.Show();


        }

        private void کلاعضاToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            View_Report();

            try
            {






                //درصورتی که سبک کارت انتخاب شده وجود داشت یا به عبارتی حذف نشده اند
                if (Report_SefarehiCard_or_FixCard == "is_select_card")
                {


                    Report4 r = new Report4("..\\Debug\\rpt\\rpt4\\Report_Card_Sefareshi_kol.rdlc", "select * from Personel,Sabt_ozv,ser,cardDesign,SelectCard where Personel.کد_عضویت=Sabt_ozv.کد_عضویت and cardDesign.nameDesign=SelectCard.nameDesign");
                    r.ShowDialog();
                }

                //استفاده بکن Fix_Report_Card.rdlcدرصورتی که سبک کارت وجود ندارد از
                //تغییر کند sql و همچنین کد 

                if (Report_SefarehiCard_or_FixCard == "is_card_Empty_Select_Card_or")
                {
                     MsgBox.ShowMessage(this.Handle.ToInt32(),  "شما هیچ سبکی را برای  کارت انتخاب نکرده اید نرمافزار این کارت سبز را برای چاپ کارت عضویت شما در نظر گرفته است" , "   ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                    Report4 r = new Report4("..\\Debug\\rpt\\rpt4\\Fix_Report_Card.rdlc", "select * from Personel,Sabt_ozv,ser where Personel.کد_عضویت=Sabt_ozv.کد_عضویت");
                    r.ShowDialog();

                }


            }

            catch (Exception ex)
            {

                 MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }

        }

        private void تنظیماتToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Report r = new Report("..\\Debug\\rpt\\rpt1\\Report_ListKol.rdlc", "select * from Personel,ser  ");
            //r.MdiParent = this;
            r.ShowDialog();
      
        }

        private void گزارشگیریاختیاریToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
   
        }

    

        private void ثبتToolStripMenuItem_Click(object sender, EventArgs e)
        {


            AddYaddasht yaddasht = new AddYaddasht();
            yaddasht.MdiParent = this;
            yaddasht.Show();
        }

        private void ویرایشToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            EditYaddsht edit_yaddasht = new EditYaddsht();
            edit_yaddasht.MdiParent = this;
            edit_yaddasht.Show();
        }

        private void جستجوToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SearchYaddashtha search_yaddsht = new SearchYaddashtha();
            search_yaddsht.MdiParent = this;
            search_yaddsht.Show();
     
        }

        private void یکیادداشتخاصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print_Yaddasht prt_yaddsht = new Print_Yaddasht();
            prt_yaddsht.MdiParent = this;
            prt_yaddsht.Show();
     
        }

        private void تمامیادداشتهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report6 r = new Report6("..\\Debug\\rpt\\rpt6\\Print_Yaddasht_Yes_Img.rdlc", "select * from Yaddasht,ser");
            r.ShowDialog();
                
        }

        private void تکیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Email_Send_Taki fek = new Form_Email_Send_Taki();

            fek.MdiParent = this;

            fek.Show();

        }

        private void انتخابوارسالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Email_Send_MultiSelect fmt = new Form_Email_Send_MultiSelect();

            fmt.MdiParent = this;

            fmt.Show();

        }

        private void مشاهدهارسالهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Email_View_Send_email F_E_V_S_e = new Form_Email_View_Send_email();
            F_E_V_S_e.ShowDialog();
        }

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        
      
      
        
         





    }
}
