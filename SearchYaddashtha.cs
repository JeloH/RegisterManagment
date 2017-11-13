using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;


namespace Applictaion_Ozviat
{
    public partial class SearchYaddashtha : Form
    {

        cldbSql cmdsql = new cldbSql();
        CurrencyManager cm;


        public SearchYaddashtha()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {

                SearchDB("select شماره as 'Number-号', تاریخ as 'Date - 日期',موضوع as 'Subject - 主题', متن as 'Text - 文字', تصویر as 'Image - 图片' from Yaddasht where Number-号 like '%" + textBox1.Text + "%' ");
         
            }
            else
            {
                SearchDB("select شماره,تاریخ,موضوع,متن,تصویر from Yaddasht where شماره = N'' ");
         


            }
        }

        

        public void SearchDB(string st) {

           try{

            DataView dv;
            dv = cmdsql.vt(st);
            dataGridView1.DataSource = dv;

//            dataGridView1.Columns["تصویر"].Visible = false;
            dataGridView1.Columns["تاریخ"].DefaultCellStyle.Format = "yyyy/MM/dd";

          //  DataBindingAdd(dv);

            cm = (CurrencyManager)BindingContext[dv];

           }

           catch (Exception ex)
           {

               MsgBox.ShowMessage(this.Handle.ToInt32(), ex.Message.ToString(), "خطا", "تایید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

           }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchDB("select شماره,تاریخ,موضوع,متن,تصویر from Yaddasht where موضوع like '%" + textBox2.Text + "%' ");


            if (textBox1.Text != "")
            {

                SearchDB("select شماره,تاریخ,موضوع,متن,تصویر from Yaddasht where موضوع like '%" + textBox2.Text + "%' ");

            }
            else
            {
                SearchDB("select شماره,تاریخ,موضوع,متن,تصویر from Yaddasht where موضوع = N'' ");



            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchDB("select شماره,تاریخ,موضوع,متن,تصویر from Yaddasht ");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }


        
    }
}
