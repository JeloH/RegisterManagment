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
    public partial class DeleteStyleCard : Form
    {

         cldbSql cmdsql = new cldbSql();

        public DeleteStyleCard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try{

            if (comboBox1.Text != "")
            {
                //MessageBoxFrmEx.Show("آیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شودآیا عملیات حذف انجام شود؟", "حذف اعضا", MessageBoxButtons.YesNo);


                if (MsgBox.ShowMessage(this.Handle.ToInt32(), "آیا عملیات حذف انجام شود ؟", "حذف اعضا", "بله", "خیر", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes)
                {

                    cldbSql.CallDB("delete from  cardDesign where  nameDesign= '" + comboBox1.Text + "'");

                    cldbSql.CallDB("delete from  SelectCard where  nameDesign= '" + comboBox1.Text + "'");


                    //اول حذف می کند و بعد دوبار لیست سبک های ایجاد شده را  رور کامبوباکس نشان بده

                    cbx1_cbx2_databinding("select * from cardDesign");

                }
            }

              }
                catch (Exception)
                {
 
                     MsgBox.ShowMessage(this.Handle.ToInt32(), "دیگر انتخابی برای حذف وجود ندارد ", "خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
         
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

             // SqlCom.ExecuteNonQuery(); // تعداد سسطرها

            DataSet ds = new DataSet();
            da.Fill(ds);


            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.DisplayMember = "nameDesign";


            }

            catch (Exception ex)
            {

                MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), " خطا ", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
            //  comboBox3.DataSource = ds.Tables[0].DefaultView;
            //  comboBox3.DisplayMember = "nameDesign";

        }

        private void DeleteStyleCard_Load(object sender, EventArgs e)
        {
            //Combobox1 اعمال بر روی
            cbx1_cbx2_databinding("select * from cardDesign");
       
        }
    
    
    }
}
