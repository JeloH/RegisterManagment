

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices; 
using System.Text;
 
public delegate int CallBack_WinProc(int uMsg , int wParam, int lParam);
public delegate int CallBack_EnumWinProc(int hWnd, int lParam);

namespace Applictaion_Ozviat
{
    /// <summary>
    /// Summary description for MessageBox.
    /// </summary>
    public class MsgBox
    {
        public MsgBox()
        {
        }
                                                                                                                                                                                                                                                                                  
        [DllImport("user32.dll")]
        static extern int GetWindowLong(int hwnd, int nIndex);
 
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();
 
        [DllImport("user32.dll")]
        static extern int SetWindowsHookEx(int idHook, CallBack_WinProc lpfn, int hmod, int dwThreadId);
     
        [DllImport("user32.dll")]
        static extern int UnhookWindowsHookEx(int hHook);
 
        [DllImport("user32.dll",CharSet = CharSet.Auto)]
        static extern int SetWindowText(int hwnd, string lpString);
         
        [DllImport("user32.dll")]
        static extern int EnumChildWindows(int hWndParent,CallBack_EnumWinProc lpEnumFunc, int lParam);
 
        [DllImport("user32.dll")]
        static extern int GetClassName(int hwnd ,StringBuilder lpClassName,int nMaxCount);
         
        static int TopCount;
        static int ButtonCount;
         
        private const int GWL_HINSTANCE = (-6);
        private const int HCBT_ACTIVATE = 5;
        private const int WH_CBT = 5;
 
        private static int hHook;
 
        static string strCaption1;
        static string strCaption2;
        static string strCaption3;

 
 

        public static DialogResult ShowMessage(int hParent, string Prompt ,string Title, string Caption1, string Caption2, string Caption3, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton DefaultButton, MessageBoxOptions options)
        {
            int hInst;
            int Thread;
            TopCount = 0;
            ButtonCount = 0;
             
            strCaption1 = Caption1;
            strCaption2 = Caption2;
            strCaption3 = Caption3;
                                                                                     
            if (Title == "")
                Title = Application.ProductName;
             
            CallBack_WinProc myWndProc = new CallBack_WinProc(WinProc);
             
            hInst = GetWindowLong(hParent, GWL_HINSTANCE);
            Thread = GetCurrentThreadId();
            hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread);
                 
            return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options);
         }
 
        private static int WinProc(int uMsg, int wParam, int lParam)
        {
            CallBack_EnumWinProc myEnumProc = new CallBack_EnumWinProc(EnumWinProc);
         
            if (uMsg == HCBT_ACTIVATE)
            {
                EnumChildWindows(wParam, myEnumProc, 0);
                UnhookWindowsHookEx(hHook);
            }
 
            return 0;
        }
 
        private static int EnumWinProc(int hWnd, int lParam)
        {      
            StringBuilder strBuffer = new StringBuilder(256);
            TopCount += 1;
             
            GetClassName(hWnd, strBuffer, strBuffer.Capacity);
            string ss = strBuffer.ToString();
 
            if (ss.ToUpper().StartsWith("BUTTON"))
            {
                ButtonCount += 1;
                switch (ButtonCount)
                {
                    case 1:
                        SetWindowText(hWnd, strCaption1);
                        break;
                    case 2:
                        SetWindowText(hWnd, strCaption2);
                        break;
                    case 3:
                        SetWindowText(hWnd, strCaption3);
                        break;
                }
            }
            return 1;
        }
    }
}