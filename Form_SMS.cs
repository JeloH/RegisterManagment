using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;


namespace Applictaion_Ozviat
{
    public partial class Form_SMS : Form
    {
        DataSet ds;
        SqlDataAdapter da=null;
        DataView dv;
        CurrencyManager cm;

        SqlConnection con;
        
        SerialPort myport = new SerialPort();
        cldbSql cmdsql = new cldbSql();



      
        private static int lng2_Number;

        public static int Lng2_Number
        {
            get { return Form_SMS.lng2_Number; }
            set { Form_SMS.lng2_Number = value; }
        }

        public string cmdq_multi = "";
 
        public Form_SMS()
        {
            

            
        


            myport.BaudRate = 9600;
            myport.Parity = Parity.None;
            myport.StopBits = StopBits.One;
            myport.DataBits = 8;
            myport.ReadBufferSize = 10000;
            myport.ReadTimeout = 1000;
            myport.WriteBufferSize = 10000;
            myport.WriteTimeout = 10000;
            myport.RtsEnable = true;


            InitializeComponent();



 

             
        }






        private void button14_Click(object sender, EventArgs e)
        {
            
            
            string DeviceName;


            if (comboBox4.Text.Trim() != "")
            {
                try
                {
                    label12.Text = "";
                    myport.PortName = comboBox4.Text.Trim();
                    if (!myport.IsOpen)
                        myport.Open();
                    myport.DiscardOutBuffer();//خالی کردن بافر
                    myport.WriteLine("AT+cgmm\r");//دستور شناخت مدل دستگاه
                    Thread.Sleep(1000);
                    DeviceName = myport.ReadExisting();
                    if (DeviceName.Contains("ERROR"))
       
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "Device does not support this command or any other problem...", "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
                    else
                    {
                        //دستورات زیر برای بیرون کشیدن نام دستگاه از رشته خوانده شده از پورت هست
                        //(char)13 کاراکتر اینتر!
                        DeviceName = DeviceName.Remove(0, DeviceName.IndexOf((char)13)).Trim();
                        DeviceName = DeviceName.Substring(0, DeviceName.IndexOf((char)13));
                        
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "شناسایی با موفقیت انجام شد :" + Environment.NewLine + "Device Name:" + Environment.NewLine + DeviceName, "  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                        label12.Text = "نام دستگاه : " + DeviceName;
                        //button1.Enabled = true;
                    }
                    myport.DiscardOutBuffer();
                }
                catch (Exception ex)
                {
                     MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

                }
                finally
                {
                    //  myport.Close();
                }

            }


        }



        private void button11_Click(object sender, EventArgs e)
        {
            myport.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            button3.Enabled = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label11.Text = textMsg.Text.Length.ToString();
        }

         
        private void button2_Click(object sender, EventArgs e)
        {
            textMsg.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchDB("select count(*) as f from Personel where چکباکس='true'");
      
        }

        public void SearchDB(string str)
        {

            DataBindingClear();

            DataView dv;
            dv = cmdsql.vt(str);

            //dataGridView1.DataSource = dv;

            DataBindingAdd(dv);


            // DataBindingAdd(dv);

            cm = (CurrencyManager)BindingContext[dv];

        }


        public void DataBindingClear()
        {

          
        }


        public void DataBindingAdd(DataView dv)
        {
             
        }

        private void button15_Click(object sender, EventArgs e)
        {
      
            commdAccess("select count(*) as fg from Personel where چکباکس='true'");
            cm.Refresh();
      
          //  SearchDB("select count(*) as fg from Personel where چکباکس='true'");
        }

  
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            string msg1 = "";
            //   textPhoneMobile.Text = clSMS.LngStr;

            msg1 += clSMS.t1_getNumberToPdu(textPhoneMobile.Text);
            msg1 += clSMS.getMessageToPdu_16bit(textMsg.Text);

            char eof = Convert.ToChar(26);

            int d = msg1.Length;
            int lng2 = ((d - 18) / 2) + 6;

            if (!myport.IsOpen)
                myport.Open();



            //part1 = st.Substring(0, 66);
            // part2 = st.Substring(66, 66);
            //   part3 = st.Substring(132);

            myport.WriteLine("AT+CMGF=0" + (char)13);
            textBox1.Text = myport.ReadExisting().ToString();

            myport.WriteLine("AT+CMGS=" + lng2 + (char)13);
            myport.WriteLine(msg1 + eof);
            textBox1.Text = myport.ReadExisting().ToString();
            System.Threading.Thread.Sleep(10000);
            textBox1.Text = myport.ReadExisting().ToString(); ;
        
        }

 

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MsgBox.ShowMessage(this.Handle.ToInt32(), " عملیات ارسال پیام انجام شد", "  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            button3.Enabled = true;

        
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
         ////   saveEditDB();

           commdAccess("select کد_عضویت , نام , فامیلی , تلفن_همراه as [شماره همراه] from Personel where چکباکس='true'");

         ////   dbTolist();


           
        }


        public ListBox dbTolist()
        {
            int lng2;

            ListBox l1=new ListBox();

            l1.Items.Clear();

            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection con = new SqlConnection(str1);

            con.Open();

            string s1 = "select * from Personel where چکباکس='true'";
            SqlDataAdapter da = new SqlDataAdapter(s1, con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            //this.Text = ds.Tables[0].TableName.Length.ToString();

            lng2= dt.Rows.Count;

            if (dt.Rows.Count == 0)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), "خطا وجود دارد ...", "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         

            }
            else
            {
                 
                for (int i = 0; i <= lng2 - 1; i++)
                {
                    l1.Items.Insert(i, (dt.Rows[i]["تلفن_همراه"].ToString()));
                }

                con.Close();

            }

//            this.textBox4.Text = l1.Items.Count.ToString();



            return l1;
        }


        public void commdAccess(string str)
        {


            try
            {

                string str1 = "";

                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                con = new SqlConnection(str1);
                SqlCommand com = new SqlCommand(str, con);


                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);



                dv = new DataView(ds.Tables[0]);
         
                cm = (CurrencyManager)BindingContext[dv];
            }

            catch(Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }
        }

         

        public void saveEditDB() {

        //    dataGridView2.EndEdit();
          
            da.Update(ds.Tables[0]);
          
      
        }
        
    
        


        public void Send_SMS_Multi_select(string strNumberic,string strMessage) {
            

                string msg1 = "";
                //   textPhoneMobile.Text = clSMS.LngStr;
                msg1 += clSMS.t1_getNumberToPdu(strNumberic);
                msg1 += clSMS.getMessageToPdu_16bit(strMessage);

                char eof = Convert.ToChar(26);

                int d = msg1.Length;
                int lng2 = ((d - 18) / 2) + 6;

                if (!myport.IsOpen)
                    myport.Open();


                //part1 = st.Substring(0, 66);
                // part2 = st.Substring(66, 66);
                //   part3 = st.Substring(132);

                myport.WriteLine("AT+CMGF=0" + (char)13);
                //textBox1.Text = myport.ReadExisting().ToString();

                myport.WriteLine("AT+CMGS=" + lng2 + (char)13);
                myport.WriteLine(msg1 + eof);


        }






    }
}