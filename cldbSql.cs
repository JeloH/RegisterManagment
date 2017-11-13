using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


 
using System.Windows.Forms;


namespace Applictaion_Ozviat
{
    class cldbSql
    {
        
     
     public SqlConnection con;
     public SqlDataAdapter da;
     public DataView dv;
     public DataSet ds;


     Form f1 = new Form();
        private static string cmdAccess5;

        public static string CmdAccess5
        {
            get { return cldbSql.cmdAccess5; }
            set { cldbSql.cmdAccess5 = value; }
        }



   
        public static void CallDB(string strCodeSql)
        {
            Form f1 = new Form();
            SqlConnection con = new SqlConnection();
     
          
            try
            {

                //  string s3 = "Data Source=.;Initial Catalog=db2;Integrated Security=true;";
                //string s3 = @"provider=microsoft.jet.oledb.4.0;" + @"data source=..\\Debug\\db\\db2.mdb";


                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                con = new SqlConnection(str1);



                SqlCommand cmd = new SqlCommand(strCodeSql, con);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception er)
            {
                 MsgBox.ShowMessage(f1.Handle.ToInt32(), er.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }
            


        }

 


        

       



        public DataView vt (string strd){


            try
            {

                string str1 = "";
                str1 = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
                con = new SqlConnection(str1);
                SqlCommand com = con.CreateCommand();
                com.CommandText = strd;
                com.CommandType = CommandType.Text;
                con.Open();
                ds = new DataSet();

                da = new SqlDataAdapter(com);

                SqlCommandBuilder comb = new SqlCommandBuilder(da);

                da.Fill(ds);
                dv = new DataView(ds.Tables[0]);
                con.Close();

            }

            catch(Exception ex){

                MsgBox.ShowMessage(f1.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
            }

            return dv;
    }




    }
}