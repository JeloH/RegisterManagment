using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Net.Mail;
using System.ComponentModel;
using System.Windows.Forms;
using  System.Net;

using System.Globalization;
using System.Text.RegularExpressions;

namespace Applictaion_Ozviat
    
{


   public class Class_mft 
    {
       Form f1 = new Form();


    
       //  if (AddressFiltAttach != null)
       //{
       /*
           if (AddressFiltAttach.Count > 0)
           {
               foreach (Attachment attachment in AddressFiltAttach)
               {
                   msg.Attachments.Add(attachment);
               }
           }

     //  }*/

       public  void sendEmailMessage(string fromSend, string toSend, string subject, string MessageTxT, string SmptMailServer, string user, string password, bool True_False_SSL,string port,string  AddressFiltAttach)
       {

           


               MailMessage msg = new MailMessage();

               msg.From = new MailAddress(fromSend);
               msg.To.Add(new MailAddress(toSend));

              msg.SubjectEncoding = System.Text.Encoding.UTF8;
              msg.Subject = subject;

               msg.BodyEncoding = System.Text.Encoding.UTF8;            
               msg.Body = MessageTxT;

               SmtpClient smtp = new SmtpClient(SmptMailServer);
               smtp.Credentials = new System.Net.NetworkCredential(user, password);
               smtp.Port = int.Parse(port);
               smtp.EnableSsl = True_False_SSL;

               if (AddressFiltAttach != "")
               {
               
                   msg.Attachments.Add(new Attachment(@AddressFiltAttach));
               
               }

               try
               {
                   smtp.Send(msg);
                   MessageBox.Show("عملیات ارسال کامل انجام شد");

               }
               catch (Exception ex) { MessageBox.Show(ex.Message); }

               //MsgBox.ShowMessage(f1.Handle.ToInt32(), "عملیات ارسال کامل انجام شد", "ارسال رایانامه", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            
               msg.Dispose();

            


       
       }
          
        // ترجیحا در این نرمافزار از Gmail استفاده می شود
        public static void SendMessage(string from, string to, string subject, string MessageTxT, string user, string password, string strAtta)
        { 
            
            MailAddress From = new MailAddress("hjelovdar@gmail.com");

              //  MailAddress From = new MailAddress(from);

              MailAddress To = new MailAddress("hajelovdar@yahoo.com");
          //      MailAddress To = new MailAddress(to);

                MailMessage Message = new MailMessage(From, To);

             //   Message.Bcc = "hajelovdar@yahoo.com";
                Message.BodyEncoding = System.Text.Encoding.UTF8;  //or//
              
                Message.Body = "";

                Message.Subject = "";

                SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
              //   SmtpClient Client = new SmtpClient("mail.irvb.ir", 25);
             
         
                NetworkCredential Credential = new NetworkCredential(user, password);

                Client .Credentials = Credential ;

               Client .EnableSsl = true;
    
             //  Message.Attachments.Add(new Attachment(@strAtta));

              
                Client .Send(Message);

           //     Client .SendCompleted += new SendCompletedEventHandler(Client_SendCompleted);

                Message.Dispose();
           

        }



   
  

                void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {


            MsgBox.ShowMessage(f1.Handle.ToInt32(), "عملیات ارسال کامل انجام شد", "ارسال رایانامه" , "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            
                
                }




    public static byte[] ReadFile(string sPath)
    {
       // sPath = "96";
        //Initialize byte array with a null value initially.
        Form f1 = new Form();



        byte[] data = null;
 try{

            //Use FileInfo object to get file size.

            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
         
          }
            catch (Exception er)
            {
                 MsgBox.ShowMessage(f1.Handle.ToInt32(), er.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            


            }
        


        return data;
    }
    


        //بررسی و چک کردن نوشته از اینکه  حاما مقدار وارد شده قالب یک ایمیل را داشته باشد 
      
        public  bool BarrasiFieldEmail(string str)
        {

            string emailAddress = str ;

            bool functionReturnValue = false;
            //www.dotnetfunda.com
                string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
                Match emailAddressMatch = Regex.Match(emailAddress, pattern);
                if (emailAddressMatch.Success)
                {
                    functionReturnValue = true;
                }
                else
                {
                    functionReturnValue = false;
                   

                    MsgBox.ShowMessage(f1.Handle.ToInt32(), "رایانامه را صحیح و کامل وارد نمایید ", "توجه" , "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            

                }


                return functionReturnValue;
        }






        //  فایل مثثل تصویر را به صورت باینری می گیر و بعد به صورت هگزه(8 بیتی)  خروجی می دهد.
        //mitavan rouye textbox ham neshan dad

        public static string binaryToHexString(byte[] raw)     {

            // could also be an extension method   

            StringBuilder sb = new StringBuilder("0x", 2 + (raw.Length * 2)); 
            for (int i = 0; i < raw.Length; i++){     
                sb.Append(raw[i].ToString("X2")); 
            } 
            
            return sb.ToString();   
        
        }

       

     


    }
}


