using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

using System.Windows.Forms;

namespace Applictaion_Ozviat
{
    class clSMS
    {


        private static string lngStr;

        public static string LngStr
        {
            get { return clSMS.lngStr; }
            set { clSMS.lngStr = value; }
        }



        public static string msg_SMS(string tel, string msg, string NumPart)
        {
            string finalMsg = "", p1 = "";
            string w3 = getMessageToPdu_16bit(msg);
            string e1 = "", e2 = "";

            e1 = w3.Substring(0, 2);
            e2 = w3.Substring(2);

            p1 += t1_getNumberToPdu(tel);
            p1 += e1;//"8B";
            p1 += t3_AdadeSabet();
            p1 += t4_Random_Number_16bit();
            finalMsg += p1 + NumPart;  // "0201";
            finalMsg += e2;   //(part1);

            int AtCommadLength = ((finalMsg.Length - 18) / 2) + 7;//brkhatere multipart boudanesh , ezafe shodane 7 byte 

            // Form1 f=new Form1();
            //  f.textBox6.Text=tmpLength+"";
            LngStr = Convert.ToString(AtCommadLength);
            return finalMsg;

        }



        public static string t1_getNumberToPdu(string Dest_Number)//·¢ثح؛¯ت‎
        {
            string str;
            string Smsc_Number = "";

            //shomre ferstande markazi   or  شماره فرستنده مرکز
            string pdu = "";
            pdu += "02910011000C";// 07 -->(Tedad shan 989366203922) , 91 -->(internation  کد بین المللی یا) , code(+98) <---> 89

            char[] tmpSmscNumber = (Smsc_Number).ToCharArray();
            for (int i = 0; i < tmpSmscNumber.Length; i += 2)
            {
                pdu += tmpSmscNumber[i + 1].ToString();
                pdu += tmpSmscNumber[i].ToString();
            }
            pdu += "91";


            //shomre girande or شماره گیرنده
            char[] tmpDestNumber = (Dest_Number).ToCharArray();
            for (int i = 0; i < tmpDestNumber.Length; i += 2)
            {
                pdu += tmpDestNumber[i + 1].ToString();
                pdu += tmpDestNumber[i].ToString();
            }
            pdu += "0008FF";

            int tmpLength = (pdu.Length - 18) / 2;
            //     label1.Text = Convert.ToString(tmpLength + 1);
            str = pdu;

            return str;
        }



        public static string getMessageToPdu_16bit(string srvContent)
        {


                Encoding encodingUTF = System.Text.Encoding.BigEndianUnicode;
                string s = null;
                byte[] encodedBytes = encodingUTF.GetBytes(srvContent);
                for (int i = 0; i < encodedBytes.Length; i++)
                {
                    s += BitConverter.ToString(encodedBytes, i, 1);
                }
                s = String.Format("{0:X2}{1}", s.Length / 2, s);


            return s;
        }




        public static string t2_Tedad_ByteMessage()
        {

            return lngStr;
        }


        public static string t3_AdadeSabet()
        {

            return "060804";
        }



        public static string t4_Random_Number_16bit()
        {
            string s;

            int Reference = System.Convert.ToInt32(VBMath.Rnd(1) * 65536); //16bit Reference Number 'See 3GPP Document
            s = Strings.Format(Reference, "X4"); ;

            return s;
        }


    }
}
