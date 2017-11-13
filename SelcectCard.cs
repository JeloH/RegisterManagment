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
    public partial class SelcectCard : Form
    {
       
        cldbSql cmdsql = new cldbSql();

  
        public SelcectCard()
        {
            InitializeComponent();

            Transparent_Label();
   
        }
       
        private void PreviewCarsSefareshi_Load(object sender, EventArgs e)
        {




            ViewCard("select cardDesign.nameDesign,cardDesign.bgcolor,cardDesign.fontcolor,cardDesign.img,ser.logo,ser.Name_Company  from cardDesign,ser,SelectCard where cardDesign.nameDesign=SelectCard.nameDesign");

        //  cbx1_cbx2_databinding("select cardDesign.nameDesign,cardDesign.bgcolor,cardDesign.fontcolor,cardDesign.img,ser.logo,ser.Name_Company  from cardDesign,ser,SelectCard where cardDesign.nameDesign=SelectCard.nameDesign");   
        }
 
         
      
         

    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                panel1.BackColor = Color.WhiteSmoke;
                panel1.BackgroundImage = null;
                
               ViewCard("select cardDesign.nameDesign,cardDesign.bgcolor,cardDesign.fontcolor,cardDesign.img,ser.logo,ser.Name_Company  from cardDesign,ser where cardDesign.nameDesign='" + comboBox1.Text + "'");
              // cbx1_cbx2_databinding("select * from cardDesign");
        
            }
            
            //SearchDB("select cardDesign.nameDesign,cardDesign.bgcolor,cardDesign.fontcolor,cardDesign.img from cardDesign,SelectCard  where cardDesign.nameDesign='"+comboBox1.Text+"'");

        }



        public void ViewCard(string strCodeSql)
        {

            try{

            string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection CN = new SqlConnection(str1);
    

            CN.Open();
            // DateTime.ParseExact(tarikh, "yyyy/MM/dd", null).ToString("yyyy/MM/dd")


            SqlCommand SqlCom = new SqlCommand(strCodeSql, CN);
            SqlDataReader reader = SqlCom.ExecuteReader();

            byte[] img_by = null;

            while (reader.Read())
            {

                label1.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());

                label3.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                //label4.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                label5.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                label6.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                label7.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                label8.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                label9.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                label10.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                //label11.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                label12.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());

                label13.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());

                label15.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());

                label14.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());
                label20.ForeColor = System.Drawing.ColorTranslator.FromHtml(reader["fontcolor"].ToString());

                label15.Text = reader["Name_Company"].ToString();

             //   pictureBox2.Image = Image.FromStream(new MemoryStream((byte[])reader["logo"]));

                if (reader["bgcolor"].ToString() != "")
                {

                    panel1.BackColor = System.Drawing.ColorTranslator.FromHtml(reader["bgcolor"].ToString());


                }


                else
                {

                    img_by = (byte[])reader["img"];

                    panel1.BackgroundImage = Image.FromStream(new MemoryStream((byte[])reader["img"]));

                }

            }
          
            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }


        }

 

        private void button2_Click_1(object sender, EventArgs e)
        {
           
            try{

           
                cldbSql.CallDB("delete from  SelectCard");


           // cldbSql.CallDB("insert into SelectCard(nameDesign)values('" + comboBox1.Text + "')");

 

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                SqlConnection CN = new SqlConnection(str1);

                string qry = "insert into SelectCard(nameDesign)values(@c1)";

            

                SqlCommand SqlCom = new SqlCommand(qry, CN);

                SqlCom.Parameters.Add(new SqlParameter("@c1", (object)comboBox1.Text));
              
                CN.Open();

                SqlCom.ExecuteNonQuery();

                MsgBox.ShowMessage(this.Handle.ToInt32(), "انتخاب سبک کارت شما با موفقیت انجام شد", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                
                CN.Close();

           
          
            }

            catch (Exception ex)
            {

              //  MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
      
       
        
        }




        public void cbx1_cbx2_databinding(string strCodeSql)
        { 
        
            try{


                 string str1 = "";
            str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
            SqlConnection CN = new SqlConnection(str1);




            CN.Open();
            // DateTime.ParseExact(tarikh, "yyyy/MM/dd", null).ToString("yyyy/MM/dd")


            SqlCommand SqlCom = new SqlCommand(strCodeSql, CN);
            SqlDataAdapter da = new SqlDataAdapter(SqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);


            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.DisplayMember = "nameDesign";

            //comboBox2.DataSource = ds.Tables[0].DefaultView;
         //   comboBox2.DisplayMember = "nameDesign";


          //  comboBox3.DataSource = ds.Tables[0].DefaultView;
          //  comboBox3.DisplayMember = "nameDesign";

            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }

        }



        private void button4_Click_1(object sender, EventArgs e)
        {
         //   cldbSql.CallDB("delete from  cardDesign where nameDesign <> '123' " );
          //  cldbSql.CallDB("delete from  cardDesign,SelectCard");


            //اول حذف می کند و بعد دوبار
                                                            
            cbx1_cbx2_databinding("select * from cardDesign,SelectCard");
          
            panel1.BackgroundImage = null;
           ViewCard("select cardDesign.nameDesign,cardDesign.bgcolor,cardDesign.fontcolor,cardDesign.img,ser.logo,ser.Name_Company  from cardDesign,ser,SelectCard where cardDesign.nameDesign='" + comboBox1.Text + "'");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();

         

        }



        public void Transparent_Label()
        {


            label1.Parent = panel1;
            // label2.Parent = panel1;
            label3.Parent = panel1;
            //label4.Parent = panel1;
            label5.Parent = panel1;
            label6.Parent = panel1;
            label7.Parent = panel1;
            label8.Parent = panel1;
            label9.Parent = panel1;
            label10.Parent = panel1;
            //label11.Parent = panel1;
            label12.Parent = panel1;
            label13.Parent = panel1;
            label14.Parent = panel1;
            label15.Parent = panel1;
            //label16.Parent = panel1;

            label20.Parent = panel1;
       


            label1.BackColor = Color.Transparent;
            //  label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            //label4.BackColor = Color.Transparent;
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

            label20.BackColor = Color.Transparent;
       


        }



        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
          //  panel1.BackColor = null;
      //      panel1. = null;


            cbx1_cbx2_databinding("select * from cardDesign");

            if (comboBox1.Text == "")
            {

                
                MsgBox.ShowMessage(this.Handle.ToInt32()," هیچ سبکی وجود ندارد || شما با ید به قسمت ایجاد سبک کارت مراجعه نمایید و سبکی را ایجاد و ذخیره نمایید", " ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }

            else
            {
                button5.Enabled = false;

               // groupBox4.Enabled = true;

                button2.Enabled = true;

             //   groupBox6.Enabled = true;

            }
        }



            
    }
}
