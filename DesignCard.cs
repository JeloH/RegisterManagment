using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Applictaion_Ozviat
{
    public partial class DesignCard : Form
    {
        cldbSql cmdsql = new cldbSql();
        DataView dv;
        SqlCommand SqlCom;

        SqlDataAdapter da = new SqlDataAdapter();
     
        SqlConnection con;
        


        Color fntcolor=Color.Black;

      public static string NameBackgroundColor="white" ;


      ArrayList a1 = new ArrayList();
            

string nameColorText="red";

public string NameColorText
{
  get { return nameColorText; }
  set { nameColorText = value; }
}


 
 
    
 public DesignCard()
        {
            InitializeComponent();
            Transparent_Label();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db20DataSet.Personel' table. You can move, or remove it, as needed.
            try{

            this.personelTableAdapter.Fill(this.db20DataSet.Personel);

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
           
      
        }

        
 

      

      
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
          
            try{


            colorDialog.AllowFullOpen = false;
            colorDialog.AnyColor = false;
          colorDialog.SolidColorOnly = false;
            colorDialog.ShowHelp = true;
        
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                //colorDialog.AnyColor = true;

                panel1.BackgroundImage = null;

                textBox1.Text = "";
                panel1.BackColor = colorDialog.Color;

              //  panel1.BringToFront();
                textBox20.Text = colorDialog.Color.Name;

                label17.Text = "Background_onlycolor";// برای مشخص بودن اینکه پشت زمینه زنگ یا تصویر

             //   textBox1.Text = colorDialog.Color.ToString();

             }


        }

        catch (Exception ex)
        {

            MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

        }
        }

     


   

      

      
         
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();
          
            try{
            
            if (dlgRes != DialogResult.Cancel)
            {
                panel1.BackColor = Color.WhiteSmoke;
                panel1.BackgroundImage = null;

              panel1.BackgroundImage = (Image.FromFile(dlg.FileName) ) ;

               // pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                 textBox1.Text = dlg.FileName;

                 textBox20.Text = "";

                 //textBox21.Text = "Transparent";

                 label17.Text = "Background_onlyImage";// برای مشخص بودن اینکه پشت زمینه زنگ یا تصویر



            }

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
     

           colorDialog.AllowFullOpen = false;
           colorDialog.AnyColor = false;
           colorDialog.SolidColorOnly = false;
            colorDialog.ShowHelp = true;
        
            try{

            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {

                colorDialog.SolidColorOnly = true;

                //fontDialog2 = fontDialog1.Font;
               // fontDialog3 = fontDialog1.Color;
                textBox21.Text = colorDialog.Color.Name;

                
                FontColor_Label_ha(colorDialog.Color);
               
              //  ht[300] = colorDialog.Color.GetBrightness().ToString();
                //دادن نام رنگ به صورت عددی و نتی و ....
                //label1.Text = "Color :" + cd.Color.Name;
                //label2.Text = "ARGB :" + cd.Color.ToArgb().ToString();//ARGB  
                //label3.Text = "Brightness :" + cd.Color.GetBrightness().ToString();//Brightness                label4.Text = "Hue :" + cd.Color.GetHue().ToString();//Hue                label5.Text = "Saturation :" + cd.Color.GetSaturation().ToString();//Saturation                label6.Text = "R:" +cd.Color.R+ " G:" +cd.Color.G +" B:"+cd.Color.B.ToString();//R-G-B component            }

              
                 
            }
           
              }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
                
            
          


        }





        public void FontColor_Label_ha(Color NameColor)
        
        {

            label3.ForeColor = NameColor;
            label4.ForeColor = NameColor;
            label5.ForeColor = NameColor;
            label6.ForeColor = NameColor;
            label7.ForeColor = NameColor;
            label8.ForeColor = NameColor;
            label9.ForeColor = NameColor;
            label10.ForeColor = NameColor;
            //label11.ForeColor = NameColor;
            label12.ForeColor = NameColor;
            label13.ForeColor = NameColor;
            label14.ForeColor = NameColor;
            label15.ForeColor = NameColor;

            //label19.ForeColor = NameColor;
            label20.ForeColor = NameColor;
            
               
            
        

        }
 
  


       

        public string Out_Name_Color(string name_color) {

            string Color_name = "White";

            if (name_color.StartsWith("f") == true)
            {




                if (name_color.Length >= 7)
                {
                    Color_name = "#" + name_color.Substring(2, 6);
                }



                else if (name_color.Length <= 6)
                {
                    Color_name = "#" + name_color;

                }




            }

            else
            {
                Color_name = name_color;

            }



            return Color_name;
        }


        public string l21_NameTextColor()
        {

            string NameTextColor = "black";


            if (textBox21.Text.StartsWith("f") == true)
            {
               

                if (textBox21.Text.Length >= 7)
                {
                    NameTextColor = "#" + textBox21.Text.Substring(2, 6);
                }



                else if (textBox21.Text.Length <= 6)
                {
                    NameTextColor = "#" + textBox21.Text;

                }




            }

            else
            {
                NameTextColor = textBox21.Text;

            }



            return NameTextColor;
        }

       
           

        public void SearchDB(string str)
        {
            try{

            DataBindingClear();

            
            dv = cmdsql.vt(str);

       //     dataGridView1.DataSource = dv;

            DataBindingAdd(dv);


            // DataBindingAdd(dv);

     //       cm = (CurrencyManager)BindingContext[dv];

            }
            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }



        public void DataBindingClear()
        {

            label8.DataBindings.Clear();
            label9.DataBindings.Clear();

            label10.DataBindings.Clear();

            //label11.DataBindings.Clear();
            label12.DataBindings.Clear();
            label15.DataBindings.Clear();     

          //  pictureBox1.DataBindings.Clear();
            //pictureBox2.DataBindings.Clear();
   
        }


        public void DataBindingAdd(DataView dv)
        {
            
            label8.DataBindings.Add("Text", dv, "کد_عضویت");
            label9.DataBindings.Add("Text", dv, "نام");

            label10.DataBindings.Add("Text", dv, "فامیلی");

            //label11.DataBindings.Add("Text", dv, "نوع_عضویت");
           // label12.DataBindings.Add("Text", dv, "تاریخ_عضویت");

            Binding b = new Binding("Text", dv, "تاریخ_عضویت", true);
            b.FormatString = "yyyy/MM/dd";
            //     b.FormatString = "yyyy/MM/dd hh:mm tt";

            label12.DataBindings.Add(b);
            label15.AutoSize = false;
            label15.DataBindings.Add("Text", dv, "Name_Company");
           
            //pictureBox1.DataBindings.Add("image", dv, "عکس", true);
            //pictureBox2.DataBindings.Add("image", dv, "logo",true);

        }




        private void button5_Click(object sender, EventArgs e)
        {
            
            try{

               string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                con = new SqlConnection(str1);

                con.Open();
                //جلوگیری از تکرار کد_ملی

                string s1 = " select nameDesign from cardDesign where nameDesign='" + textBox2.Text + "'  ";
                da = new SqlDataAdapter(s1, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {

                    //----------این کدملی اصلا وجود ندارد -------------------------------------

                   // byte[] imageData = Class_mft.ReadFile(textBox4.Text);
                  //  cldbSql.CallDB("update Personel set نام= N'" + textBox1.Text + "',فامیلی=N'" + textBox2.Text + "',نام_پدر=N'" + textBox3.Text + "',تاریخ_تولد=N'" + maskedTextBox1.Text + "',شماره_شناسنامه=N'" + textBox5.Text + "',کد_ملی=N'" + textBox6.Text + "',شهر_اقامت=N'" + textBox7.Text + "',مذهب=N'" + textBox8.Text + "',تابعیت=N'" + textBox9.Text + "',وضعیت_تاهل='" + comboBox1.Text + "',پست_الکترونیکی=N'" + textBox10.Text + "',تلفن_همراه=N'" + textBox11.Text + "',جنسیت=N'" + comboBox2.Text + "',آدرس=N'" + textBox12.Text + "' where کد_عضویت=N'" + textBox14.Text + "'  ");

                   // UpdatePicturePersonel();

                   // cm.EndCurrentEdit();

                  
                    MsgBox.ShowMessage(this.Handle.ToInt32(), "این نام سبک قبلا ثبت شده است نام دیگری وارد نمایید ", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
          
                  
                    textBox2.Text = "";


                    //-----------------------------------------------------------------------


                }


                else
                {
                    if (textBox2.Text == "") {

                    
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "نام کارت را وارد نمایید", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
          
                  
                    }


                    else if (textBox21.Text == "")
                    {
                       
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "رنگ متن فونت  را انتحاب کنید", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
          
                
                    }

                    else if (textBox1.Text == "" && textBox20.Text == "")
                    {
                      
                        MsgBox.ShowMessage(this.Handle.ToInt32(), "رنگ پشت زمینه یا تصویر پشت زمینه را مشخص نمایید", "!! توجه  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
          
                    }
                   
                    else if (textBox2.Text != "")
                    {


                        try
                        {



                            string str2 = "";
                            str2 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                            SqlConnection CN = new SqlConnection(str2);


                            if (label17.Text == "Background_onlyImage")
                            {
                                //در صورتی که پشت زمینه فقط رنگ باشد


                                string qry = "insert into cardDesign(nameDesign,bgcolor,fontcolor,Address_img,img) values(@c1,@c2,@c3,@c4,@c5)";


                                SqlCom = new SqlCommand(qry, CN);

                                byte[] imageData = Class_mft.ReadFile(textBox1.Text);


                                SqlCom.Parameters.Add(new SqlParameter("@c1", (object)textBox2.Text));
                                SqlCom.Parameters.Add(new SqlParameter("@c2", (object)Out_Name_Color(textBox20.Text)));
                                SqlCom.Parameters.Add(new SqlParameter("@c3", (object)Out_Name_Color(textBox21.Text)));
                                SqlCom.Parameters.Add(new SqlParameter("@c4", (object)textBox1.Text));//آدرس عکس
                                SqlCom.Parameters.Add(new SqlParameter("@c5", (object)imageData));
                            }

                            else if (label17.Text == "Background_onlycolor")
                            {


                                string qry = "insert into cardDesign(nameDesign,bgcolor,fontcolor,Address_img) values(@c1,@c2,@c3,@c4)";


                                SqlCom = new SqlCommand(qry, CN);

                                // درصورتی که پشت زمینه فقط تصویر باشد

                                SqlCom.Parameters.Add(new SqlParameter("@c1", (object)textBox2.Text));
                                SqlCom.Parameters.Add(new SqlParameter("@c2", (object)Out_Name_Color(textBox20.Text)));
                                SqlCom.Parameters.Add(new SqlParameter("@c3", (object)Out_Name_Color(textBox21.Text)));
                                SqlCom.Parameters.Add(new SqlParameter("@c4", (object)textBox1.Text));//آدرس عکس
                                //   SqlCom.Parameters.Add(new SqlParameter("@c5", (object)imageData));


                            }

                            CN.Open();

                            SqlCom.ExecuteNonQuery();

                            MsgBox.ShowMessage(this.Handle.ToInt32(), "سبک ایجاد شده با موفقیت ذخیره شد", "  ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
          
                      


                            CN.Close();

                        }
                        catch (Exception er)
                        {
 
                            MsgBox.ShowMessage(this.Handle.ToInt32(), er.Message.ToString(), "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
          
                        }

                          

                        textBox1.Text = "";
                        textBox2.Text = "";

                        textBox20.Text = "";
                        textBox21.Text = "";

                        panel1.BackColor = Color.WhiteSmoke;
                        panel1.BackgroundImage = null;



                        label3.ForeColor = Color.Black;
                        label4.ForeColor = Color.Black;
                        label5.ForeColor = Color.Black;
                        label6.ForeColor = Color.Black;
                        label7.ForeColor = Color.Black;
                        label8.ForeColor = Color.Black;
                        label9.ForeColor = Color.Black;
                        label10.ForeColor = Color.Black;
                        //label11.ForeColor = Color.Black;
                        label12.ForeColor = Color.Black;
                        label13.ForeColor = Color.Black;
                        label14.ForeColor = Color.Black;
                        label15.ForeColor = Color.Black;
            
               


                    }

                }


            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }



        public void Transparent_Label()
        {


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
            //   label14.Parent = panel1;
            label15.Parent = panel1;
            //label16.Parent = panel1;

            //label19.Parent = panel1;
            label20.Parent = panel1;



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
            label14.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            //label16.BackColor = Color.Transparent;

            //label19.BackColor = Color.Transparent;
            label20.BackColor = Color.Transparent;


        }

        private void button3_Click(object sender, EventArgs e)
        {

            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            //label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            
               
        }


}
      

}
 
    

