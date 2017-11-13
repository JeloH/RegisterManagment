using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 

using System.Net.Mail;
using System.Net;

using System.Data.SqlClient;

using System.Configuration;


namespace Applictaion_Ozviat
{
    public partial class Form_Email_Send_Taki : Form
    {

        Class_mft c1 = new Class_mft();


        Tanzimat_email tem2=new Tanzimat_email();
        


        public Form_Email_Send_Taki()
        {
            InitializeComponent();
            tem2.Tanzim_Email_set();
    
        }

        private void Form9_Load(object sender, EventArgs e)
        {
           
          
            Sendertxt1.Text = Class1.AddressSender;
          
             Control.CheckForIllegalCrossThreadCalls = false;
  

        }


        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgopenFile = new OpenFileDialog();
            dlgopenFile.Filter = "All Files (*.*)|*.*";

             dlgopenFile.Title = "Select File to Attach";
			
            dlgopenFile.ShowDialog();
            textBox1_Attach.Text = dlgopenFile.FileName;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Sendertxt1.Text == "") { MessageBox.Show(" تنظیمات ارسال پیام را انجام نشده است "); }

            else if (Resivtxt2.Text != "" && c1.BarrasiFieldEmail(Resivtxt2.Text) == false)
            {
                MessageBox.Show("رایانامه گیرنده را وارد نمایید");
                Resivtxt2.Text = "";
            }

            else
            {

               
                label2.Text = "در حال انجام عملیات ارسال... ";

                button1.Enabled = false;

               backgroundWorker1.RunWorkerAsync();
          
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            tem2 = new Tanzimat_email();
            tem2.ShowDialog();
            
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            // c1.sendEmailMessage(Class1.AddressSender, Resivtxt2.Text, Subjectxt3.Text, Messagetxt4.Text, Class1.SmtpMaileServer, Class1.user, Class1.password, Class1.True_False_SSL, Class1.Port, textBox1_Attach.Text);

         
                        MailMessage mail = new MailMessage();
                        MailAddress mailAddress = new MailAddress(Class1.AddressSender);
                        mail.To.Add(Resivtxt2.Text);
                        mail.From = mailAddress;

                        mail.Subject = Subjectxt3.Text;
                        mail.Body = Messagetxt4.Text;

                        string sendEmailsFrom = Class1.user;
                        string sendEmailsFromPassword = Class1.password;
                        // string sendEmailsFrom = "h20@irvb.ir";
                        //   string sendEmailsFromPassword = "11336699";
                        NetworkCredential credentials = new NetworkCredential(sendEmailsFrom, sendEmailsFromPassword);


                        SmtpClient mailClient = new SmtpClient(Class1.SmtpMaileServer, int.Parse(Class1.Port));
                       
                         mailClient.Credentials = credentials;
                       

                       mailClient.EnableSsl = Class1.True_False_SSL;
                      // mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                        if (textBox1_Attach.Text != "")
                        {

                            mail.Attachments.Add(new Attachment(@textBox1_Attach.Text));

                        }


                        try {

                            mailClient.Send(mail);
                           
                            label2.Text = " ";
                    

                            MessageBox.Show("ارسال با موفقیت انجام شد");
                         
                        }

                        catch (Exception ex)
                        {
                            label2.Text = " ";
                    

                            MessageBox.Show("ارسال با خطا مواجعه شد");
                      
                            MessageBox.Show(ex.Message);
                        }

            mail.Dispose();

            System.Threading.Thread.Sleep(2000);
           
     

          

                            
            }


   

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // label2.Text = " ";
            button1.Enabled = true;


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // this.Text = e.ProgressPercentage.ToString(); 
         //  this.progressBar1.Value = e.ProgressPercentage;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Tanzimat_email tm = new Tanzimat_email();
            tm.ShowDialog();
        }




        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "jjjj";
        }




        }


               }
    

