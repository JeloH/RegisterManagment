using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Applictaion_Ozviat
{
    class datetime
    {
        public string day()
        {
            string x;
            x = DateTime.Now.DayOfWeek.ToString();
            switch (x.ToLower())
            {

                case ("saturday"):
                    {
                        x = "شنبه";
                        break;
                    }
                case ("sunday"):
                    {
                        x = "یکشنبه";
                        break;
                    }
                case ("monday"):
                    {
                        x = "دوشنبه";
                        break;
                    }
                case ("tuesday"):
                    {
                        x = "سه شنبه";
                        break;
                    }
                case ("wednesday"):
                    {
                        x = "چهارشنبه";
                        break;
                    }
                case ("thursday"):
                    {
                        x = "پنج شنبه";
                        break;
                    }
                case ("friday"):
                    {
                        x = "جمعه";
                        break;
                    }
            }
            return x;
        }

        //**************************************************************

        public string daycount()
        {
            string x;
            PersianCalendar x1 = new PersianCalendar();
            x = x1.GetDayOfMonth(DateTime.Now).ToString();
            return x;
        }

        //**************************************************************


   

        
        public string month()
        {
            string x;
            PersianCalendar x1 = new PersianCalendar();
            x = x1.GetMonth(DateTime.Now).ToString();
            switch (x)
            {
                case "1": x = "01";
                    break;
                case "2": x = "02";
                    break;
                case "3": x = "03";
                    break;
                case "4": x = "04";
                    break;
                case "5": x = "05";
                    break;
                case "6": x = "06";
                    break;
                case "7": x = "07";
                    break;
                case "8": x = "08";
                    break;
                case "9": x = "09";
                    break;
                case "10": x = "10";
                    break;
                case "11": x = "11";
                    break;
                case "12": x = "12";
                    break;
                default:
                    break;
            }
            return x;          
        }

        //**************************************************************

        public string year()
        {
            string x;
            PersianCalendar x1 = new PersianCalendar();
            x = x1.GetYear(DateTime.Now).ToString();
            return x;
        }

    }
}
