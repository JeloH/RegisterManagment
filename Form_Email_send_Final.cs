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

using System.Net;
using System.Net.Mail;



namespace Applictaion_Ozviat
{
    public partial class Form_Email_send_Final : Form
    {

        Form_Email_Send_MultiSelect f_e_d_m = null;
        
        ListBox l1 = new ListBox();
        ListBox l2 = new ListBox();
        ListBox l3 = new ListBox();
        ListBox l4 = new ListBox();

        Main m1 = new Main();

        public int Tedade_Amadeh_Ersalha = 0;

        public int Tedade_Ersal_Shodeha = 0;
        


        public Form_Email_send_Final(Form_Email_Send_MultiSelect f_e_d_multi)
        {
            this.f_e_d_m = f_e_d_multi;

            InitializeComponent();





            dataDBtoListBox1();

            
                progressBar1.Maximum = l1.Items.Count +2 ;

                label4.Text = l1.Items.Count.ToString(); //تعداد ارسال ها



        }

        private void Form_Email_send_Final_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();


            Control.CheckForIllegalCrossThreadCalls = false;
  

        }



        public void dataDBtoListBox1()
        {



            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection con = new SqlConnection(str1);

            con.Open();
          //کسانی که انتخای شده اند و دارای ایمیل یا رایانامه باشند 
            string str = "select * from Personel where چکباکس='true'and  پست_الکترونیکی !='' ";
            // SqlDataAdapter da = new SqlDataAdapter(s1, con);
            //  DataTable dt = new DataTable();

            SqlDataReader dr;


            //  string  str = "select c_fname||' '||c_lname||':'||Candidate_id as NAME from CANDIDATE ORDER BY C_FNAME";
            SqlCommand cmd = new SqlCommand(str, con);
            //con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                l1.Items.Add(dr["پست_الکترونیکی"].ToString());                
               
                l2.Items.Add(dr["پست_الکترونیکی"].ToString() + "   ||   " + dr["نام"].ToString()+" " + dr["فامیلی"].ToString() + "    ||    " + dr["کد_عضویت"].ToString());

                l4.Items.Add(dr["کد_عضویت"].ToString());                
             
            }
            con.Close();

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                for (int i = 0; (i <= l1.Items.Count - 1); i++)
                {
                    if ((backgroundWorker1.CancellationPending == true))
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {

                        MailMessage mail = new MailMessage();
                        MailAddress mailAddress = new MailAddress(Class1.AddressSender);
                        mail.To.Add(l1.Items[i].ToString());
                        mail.From = mailAddress;

                        mail.Subject = f_e_d_m.textBox2_subject.Text;
                        mail.Body = f_e_d_m.textBox4_MsgTxT.Text;

                        string sendEmailsFrom = Class1.user;
                        string sendEmailsFromPassword = Class1.password;
                        // string sendEmailsFrom = "h20@irvb.ir";
                        //   string sendEmailsFromPassword = "11336699";
                        NetworkCredential credentials = new NetworkCredential(sendEmailsFrom, sendEmailsFromPassword);


                        SmtpClient mailClient = new SmtpClient(Class1.SmtpMaileServer, int.Parse(Class1.Port));
                        mailClient.Credentials = credentials;
                        mailClient.EnableSsl = Class1.True_False_SSL;
                        mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;


                        if (f_e_d_m.textBox3_attach.Text != "")
                        {

                            mail.Attachments.Add(new Attachment(@f_e_d_m.textBox3_attach.Text));

                        }


                        mailClient.Send(mail);

                        cldbSql.CallDB("insert into send_email(فرستنده,گیرنده,موضوع,تاریخ_ارسال,فایل_پیوست,متن_پیام,us,کد_عضویت)values( '" + Class1.AddressSender + "', '" + l1.Items[i].ToString() + "' ,'" + f_e_d_m.textBox2_subject.Text + "','" + f_e_d_m.textBox5_Tarikh.Text + "' , '" + f_e_d_m.textBox3_attach.Text + "' , '" + f_e_d_m.textBox4_MsgTxT.Text + "'  ,'" + m1.label11.Text + "' ,  '" + int.Parse(l4.Items[i].ToString()) + "' )");

                        l3.Items.Insert(i, i);
                        Tedade_Ersal_Shodeha = i + 1;
                        label5.Text = Tedade_Ersal_Shodeha.ToString();

                        listBox1.Items.Insert(i, "  ارسال پیام انجام شد --->" + l2.Items[i].ToString());

                        // MessageBox.Show(SmtpDeliveryMethod.Network.ToString());

                        System.Threading.Thread.Sleep(500);
                        backgroundWorker1.ReportProgress((i));

                    }

                }

               MessageBox.Show("عملیات ارسال پیام با موفقیت به پایان رسید");       

            }

            catch(Exception ex){

                if (InternetCS.IsConnectedToInternet() == true || InternetCS.Check_Connect_Internet() == true)
                {
                    MessageBox.Show(" اتصال به اینترنت برقرار نیست  یا  اتصال به اینترنت ضعیف است");
                }
            
                    MessageBox.Show(ex.Message.ToString());

                    MessageBox.Show("عملیات ارسال پیام با خطا مواجعه شد");

          
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // progressBar1.Value = progressBar1.Maximum;

            if (e.Cancelled)
            {
                //MessageBox.Show("عملیات ارسال نا تمام انجام شد ");
                button1.Enabled = false;
                button2.Enabled = true;
                progressBar1.Value = progressBar1.Maximum;
   
            }
            else
            {
               // MessageBox.Show("عملیات ارسال انجام و  به پایان رسید ");
                button1.Enabled = false;
                button2.Enabled = true;
                //  progressBar1.Value = 50;

                progressBar1.Value = progressBar1.Maximum;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progressBar1.Value = e.ProgressPercentage +2;
//            textBox1.Text =(e.ProgressPercentage).ToString();

         //   Tedade_Ersal_Shodeha = (e.ProgressPercentage+1);

         //   listBox1.Items.Insert(e.ProgressPercentage, "  ارسال پیام انجام شد --->" + l2.Items[e.ProgressPercentage].ToString());


    //   label5.Text = Tedade_Ersal_Shodeha.ToString(); // تعداد ارسال شده ها



        Tedade_Amadeh_Ersalha = int.Parse(label4.Text);    //تعداد آماده به ارسال 
      //  Tedade_Amadeh_Ersalha = Tedade_Amadeh_Ersalha - 1;

        Tedade_Amadeh_Ersalha = (l1.Items.Count)-(e.ProgressPercentage + 1);




        label4.Text = (Tedade_Amadeh_Ersalha).ToString() ; // تعداد آماده به ارسال

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا در نظر دارید که ارسال پیام انجام نشود ؟", " انصراف از ارسال", "بله", "خیر", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            if (dr == DialogResult.Yes)
            {
              
                this.Close();

            }

            else if (dr == DialogResult.No)
            {
          
            }

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

          //  MessageBox.Show("ارسال شد"+l1.Items.Count.ToString() + "پیام از" + l3.Items.Count.ToString());
            /*
            DialogResult dr = MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا گزارش ارسال ذخیره شود ؟", " ذخیره گزارش ارسال", "بله", "خیر", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            if (dr == DialogResult.Yes)
            {

                for (int i = 0; (i <= l1.Items.Count - 1); i++)
                {

                    cldbSql.CallDB("insert into send_email(فرستنده,گیرنده,موضوع,تاریخ_ارسال,وضعیت_ارسال,فایل_پیوست,متن_پیام)values( '000', '" + l1.Items[i].ToString() + "' ,'222','1390'  ,'52' , '455' , '542'  )");



                }

                this.Close();

            }

            else if (dr == DialogResult.No)
            {
                this.Close();
            }

            */


        }

 




    }
}
