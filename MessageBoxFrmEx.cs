using System;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Applictaion_Ozviat
{
    /// <summary>
    /// 对话框，能够相对于父窗体居中，不显示使用DllImport 使用从窗体继承 实现
    /// </summary>
    public class  MessageBoxFrmEx
    {
        /// <summary>
        /// 从窗体类继承的对话框类
        /// </summary>
        private class  MessageBoxFrm : System.Windows.Forms.Form
        {

            #region 字段

            private IWin32Window _BoxOwner = null;

            private MessageBoxOptions opt;

            public MessageBoxOptions Opt
            {
                get { return opt; }
                set { opt = value; }
            }

            private  MessageBoxButtons _BoxButtons =  MessageBoxButtons.OK;

            private  MessageBoxDefaultButton _BoxDefaultButton =  MessageBoxDefaultButton.Button1;

            private  MessageBoxIcon _BoxIcon =  MessageBoxIcon.None;

            private Bitmap _BoxIconBmp = null;

            private string _BoxCaption = string.Empty;

            private string _BoxText = string.Empty;

            private bool _CanClose = false;

            #endregion

            #region  属性

            /// <summary>
            /// 父窗体
            /// </summary>
            public IWin32Window BoxOwner
            {
                get { return _BoxOwner; }
                set
                {
                    _BoxOwner = value;
                    if (_BoxOwner == null)
                    {
                        StartPosition = FormStartPosition.CenterScreen;
                    }
                    else
                    {
                        StartPosition = FormStartPosition.CenterParent;
                    }

                }
            }


            /// <summary>
            /// 对话框上显示的按钮
            /// </summary>
            public  MessageBoxButtons BoxButtons
            {
                get { return _BoxButtons; }
                set { _BoxButtons = value; }
            }

            /// <summary>
            /// 默认选中的那个按钮
            /// </summary>
            public  MessageBoxDefaultButton BoxDefaultButton
            {
                get { return _BoxDefaultButton; }
                set { _BoxDefaultButton = value; }
            }

            /// <summary>
            /// 对话框上显示的图标
            /// </summary>
            public  MessageBoxIcon BoxIcon
            {
                get { return _BoxIcon; }
                set
                {
                    _BoxIcon = value;
                    System.Drawing.Icon bmp = null;
                    if (BoxIcon ==  MessageBoxIcon.Asterisk)
                    {
                        bmp = SystemIcons.Asterisk;
                    }
                    else if (BoxIcon ==  MessageBoxIcon.Hand)
                    {
                        bmp = SystemIcons.Hand;
                    }
                    else if (BoxIcon ==  MessageBoxIcon.Information)
                    {
                        bmp = SystemIcons.Information;
                    }
                    else if (BoxIcon ==  MessageBoxIcon.Question)
                    {
                        bmp = SystemIcons.Question;
                    }
                    else if (BoxIcon ==  MessageBoxIcon.Exclamation || BoxIcon ==  MessageBoxIcon.Warning)
                    {
                        bmp = SystemIcons.Exclamation;
                    }
                    else if (BoxIcon ==  MessageBoxIcon.Stop || BoxIcon ==  MessageBoxIcon.Error)
                    {
                        bmp = SystemIcons.Warning;
                    }
                    else
                    {
                        bmp = null;
                    }

                    if (bmp != null)
                        _BoxIconBmp = bmp.ToBitmap();
                    else
                        _BoxIconBmp = null;
                }
            }

            /// <summary>
            /// 对话框显示的标题
            /// </summary>
            public string BoxCaption
            {
                get { return _BoxCaption; }
                set
                {
                    _BoxCaption = value;
                    this.Text = _BoxCaption;
                }
            }

            /// <summary>
            /// 对话框显示的文本
            /// </summary>
            public string BoxText
            {
                get { return _BoxText; }
                set { _BoxText = value; }
            }
            #endregion

            #region 构造函数

            public  MessageBoxFrm()
                : base()
            {
            }

            public  MessageBoxFrm(IWin32Window owner, string text)
                : base()
            {
                BoxOwner = owner;
                BoxText = text;
            }

            public  MessageBoxFrm(IWin32Window owner, string text, string caption)
                : base()
            {
                BoxOwner = owner;
                BoxText = text;
                BoxCaption = caption;
            }

            public  MessageBoxFrm(IWin32Window owner, string text, string caption,  MessageBoxButtons buttons,  MessageBoxIcon icon,  MessageBoxDefaultButton defaultbutton)
                : base()
            {
                BoxOwner = owner;
                BoxCaption = caption;
                BoxText = text;
                BoxButtons = buttons;
                BoxDefaultButton = defaultbutton;
                BoxIcon = icon;
            }


            public MessageBoxFrm(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton, MessageBoxOptions option)
                : base()
            {
                BoxOwner = owner;
                BoxCaption = caption;
                BoxText = text;
                BoxButtons = buttons;
                BoxDefaultButton = defaultbutton;
                BoxIcon = icon;
                opt = option;
            }


            #endregion

            #region 重载

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnLoad(EventArgs e)
            {
                _AdjustSize();

                base.OnLoad(e);

                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Icon = null;

                this.RightToLeft = RightToLeft.Yes;

                _PlaySound();
                _PlaceButtons();

            }

            /// <summary>
            /// 在对话框上 画按钮 画文本
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                this.RightToLeft = RightToLeft.Yes;

                Graphics g = e.Graphics;

                int xpos = 0;
                int ypos = 20;

                if (_BoxIconBmp != null)
                {
                    g.DrawImage(_BoxIconBmp, new Point(15, 15));
                    xpos = 60;
                }
                g.DrawString(BoxText, new Font(FontFamily.GenericSansSerif, 8), new SolidBrush(Color.Black), new PointF(xpos, ypos));

            }

            /// <summary>
            /// 屏蔽通过单击窗体关闭按钮关闭窗体
            /// </summary>
            /// <param name="e"></param>
            protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
            {
                e.Cancel = !_CanClose;
                base.OnClosing(e);
                if (this.Owner != null)
                {
                    this.Owner.Show();
                }
            }

        

            #region 没用？ 在按钮的 Text里 加入&大写字母后 自动关联Alt快捷键？

            //protected override void OnKeyDown(KeyEventArgs e)
            //{
            //    base.OnKeyDown(e);

            //    if (e.Control)
            //    {
            //        switch (e.KeyCode)
            //        {
            //            case Keys.A:
            //                if (BoxButtons == MessageBoxButtons.AbortRetryIgnore)
            //                {
            //                    this.DialogResult = DialogResult.Abort;
            //                }
            //                break;
            //            case Keys.R:
            //                if (BoxButtons == MessageBoxButtons.RetryCancel || BoxButtons == MessageBoxButtons.AbortRetryIgnore)
            //                {
            //                    this.DialogResult = DialogResult.Retry;
            //                }
            //                break;
            //            case Keys.Y:
            //                if (BoxButtons == MessageBoxButtons.YesNo || BoxButtons == MessageBoxButtons.YesNoCancel)
            //                {
            //                    this.DialogResult = DialogResult.Yes;
            //                }
            //                break;
            //            case Keys.N:
            //                if (BoxButtons == MessageBoxButtons.YesNo || BoxButtons == MessageBoxButtons.YesNoCancel)
            //                {
            //                    this.DialogResult = DialogResult.No;
            //                }
            //                break;
            //            case Keys.C:
            //                if (BoxButtons == MessageBoxButtons.OKCancel || BoxButtons == MessageBoxButtons.RetryCancel || BoxButtons == MessageBoxButtons.YesNoCancel)
            //                {
            //                    this.DialogResult = DialogResult.Cancel;
            //                }
            //                break;
            //            case Keys.I:
            //                if (BoxButtons == MessageBoxButtons.AbortRetryIgnore)
            //                {
            //                    this.DialogResult = DialogResult.Ignore;
            //                }
            //                break;
            //            case Keys.O:
            //                if (BoxButtons == MessageBoxButtons.OK || BoxButtons == MessageBoxButtons.OKCancel)
            //                {
            //                    this.DialogResult = DialogResult.OK;
            //                }
            //                break;
            //            default: break;
            //        }
            //    }

            //}
            #endregion


            #endregion

            #region 私有方法

            /// <summary>
            /// 根据是否要显示图标 标题栏文字长度 内容长度 调整对话框大小
            /// </summary>
            private void _AdjustSize()
            {
                int width = 0;
                int height = 0;


                if (string.IsNullOrEmpty(_BoxText) && string.IsNullOrEmpty(_BoxCaption))
                {

                }
                else
                {
                    Graphics g = this.CreateGraphics();
                    Font ft = new Font(FontFamily.GenericSansSerif, 12);
                    SizeF size1 = g.MeasureString(BoxCaption, ft);
                    SizeF size2 = g.MeasureString(BoxText, ft);
                    width = (int)(size1.Width > width + size2.Width ? size1.Width : width + size2.Width);
                    height = (int)size2.Height;
                    g.Dispose();
                    g = null;
                }

                if (BoxIcon != MessageBoxIcon.None)
                {
                    width += 60;
                }
                height = height > 25 ? height : 25;

                if (BoxButtons == MessageBoxButtons.OK)
                {

                }
                else if (BoxButtons == MessageBoxButtons.OKCancel || BoxButtons == MessageBoxButtons.RetryCancel
                    || BoxButtons == MessageBoxButtons.YesNo)
                {
                    width = width > 180 ? width : 180;
                }
                else if (BoxButtons == MessageBoxButtons.AbortRetryIgnore || BoxButtons == MessageBoxButtons.YesNoCancel)
                {
                    width = width > 260 ? width : 260;
                }

                height += 35 + 15 + 15 + 30 + 5; //标题栏高 35px 受图标影响 上空15pc  下空15px 按钮栏高度30px 底部边框5px
                width += 5 + 25 + 5;            //做边框5px 受图标影响左空25px 右边框5px
                this.Width = width;
                this.Height = height;
            }
            
            
            private void _PlaceButtons()
            {
                Button button1 = null;
                Button button2 = null;
                Button button3 = null;

                switch (BoxButtons)
                {
                    case  MessageBoxButtons.AbortRetryIgnore:
                        button1 = new Button();
                        button1.Text = "终止(&A)";
                        button1.Height = 20;
                        button1.DialogResult = DialogResult.Abort;
                        button2 = new Button();
                        button2.Height = 20;
                        button2.Text = "重试(&R)";
                        button2.DialogResult = DialogResult.Cancel;
                        button3 = new Button();
                        button3.Height = 20;
                        button3.Text = "忽略(&I)";
                        button3.DialogResult = DialogResult.Ignore;
                        break;
                    case  MessageBoxButtons.RetryCancel:
                        button1 = new Button();
                        button1.Text = "重试(&R)";
                        button1.Height = 20;
                        button1.DialogResult = DialogResult.Retry;
                        button2 = new Button();
                        button2.Text = "取消(&Y)";
                        button2.Height = 20;
                        button2.DialogResult = DialogResult.Cancel;
                        break;
                    case  MessageBoxButtons.YesNoCancel:
                        button1 = new Button();
                        button1.Text = "بله";
                        button1.Height = 20;
                        button1.DialogResult = DialogResult.Yes;
                        button2 = new Button();
                        button2.Text = "خیر";
                        button2.Height = 20;
                        button2.DialogResult = DialogResult.No;
                        button3 = new Button();
                        button3.Text = "بستن";
                        button3.Height = 20;
                        button3.DialogResult = DialogResult.Cancel;
                        break;
                    case  MessageBoxButtons.YesNo:
                        button1 = new Button();
                        button1.Text = "بله";
                        button1.Height = 20;
                        button1.DialogResult = DialogResult.Yes;
                        button2 = new Button();
                        button2.Text = "خیر";
                        button2.Height = 20;
                        button2.DialogResult = DialogResult.No;
                        break;
                    case  MessageBoxButtons.OKCancel:
                        button1 = new Button();
                        button1.Text = "تایید";
                        button1.Height = 20;
                        button1.DialogResult = DialogResult.OK;
                        button2 = new Button();
                        button2.Text = "بستن";
                        button2.Height = 20;
                        button2.DialogResult = DialogResult.Cancel;
                        break;
                    case  MessageBoxButtons.OK:
                    default:
                        button1 = new Button();
                        button1.Text = "تایید";
                        button1.Height = 20;
                        button1.DialogResult = DialogResult.OK;
                        break;
                }
                int ypos = this.Height - button1.Height - 30 - 10;
                /* 窗体高度 - 按钮高度 - 窗体标题栏高度 - 距底调节高度 */

                if (button3 != null)
                {
                    button1.Location = new Point((this.Width - (button1.Width + 5) * 3) / 2, ypos);
                    button2.Location = new Point(button1.Location.X + button1.Width + 5, ypos);
                    button3.Location = new Point(button2.Location.X + button2.Width + 5, ypos);

                    button1.Click += new EventHandler(Right_Close_Click);
                    button2.Click += new EventHandler(Right_Close_Click);
                    button3.Click += new EventHandler(Right_Close_Click);

                    this.CancelButton = button2;
                    this.Controls.Add(button2);
                    this.Controls.Add(button3);
                }
                else if (button2 != null)
                {
                    button1.Location = new Point((this.Width - (button1.Width + 5) * 2) / 2, ypos);
                    button2.Location = new Point(button1.Location.X + button1.Width + 5, ypos);

                    button1.Click += new EventHandler(Right_Close_Click);
                    button2.Click += new EventHandler(Right_Close_Click);

                    this.CancelButton = button2;
                    this.Controls.Add(button2);
                }
                else
                {
                    button1.Location = new Point((this.Width - button1.Width) / 2, ypos);

                    button1.Click += new EventHandler(Right_Close_Click);
                }

                this.AcceptButton = button1;
                this.Controls.Add(button1);

                if (BoxDefaultButton ==  MessageBoxDefaultButton.Button1)
                    button1.Focus();
                else if (BoxDefaultButton ==  MessageBoxDefaultButton.Button2)
                {

                    if (button2 == null)
                        button1.Focus();
                    else
                        button2.Focus();
                }
                else if (BoxDefaultButton ==  MessageBoxDefaultButton.Button3)
                {
                    if (button3 == null)
                        button1.Focus();
                    else
                        button3.Focus();
                }
            }

            /// <summary>
            /// 根据要显示的对话框类型，播放声音
            /// </summary>
            private void _PlaySound()
            {
                if (BoxIcon ==  MessageBoxIcon.Asterisk || BoxIcon ==  MessageBoxIcon.Information)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                }
                else if (BoxIcon ==  MessageBoxIcon.Error || BoxIcon ==  MessageBoxIcon.Stop || BoxIcon ==  MessageBoxIcon.Hand)
                {
                    System.Media.SystemSounds.Hand.Play();
                }
                else if (BoxIcon ==  MessageBoxIcon.Exclamation || BoxIcon ==  MessageBoxIcon.Warning)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                }
                else if (BoxIcon ==  MessageBoxIcon.Question)
                {
                    System.Media.SystemSounds.Question.Play();
                }

            }


            /// <summary>
            /// 屏蔽单击窗体关闭按钮关闭窗体
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Right_Close_Click(object sender, EventArgs e)
            {
                _CanClose = true;
            }

            #endregion

        }


        #region 字段

        #endregion

        #region 属性

        #endregion

        #region

        static  MessageBoxFrmEx()
        {
        }

        #endregion

        #region 公共方法

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return new  MessageBoxFrm(owner, text).ShowDialog();
        }

        public static DialogResult Show(string text)
        {
            return new  MessageBoxFrm(null, text).ShowDialog();
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return new  MessageBoxFrm(owner, text, caption).ShowDialog();
        }

        public static DialogResult Show(string text, string caption)
        {
            return new  MessageBoxFrm(null, text, caption).ShowDialog();
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption,  MessageBoxButtons buttons)
        {
            return new  MessageBoxFrm(owner, text, caption, buttons,  MessageBoxIcon.None,  MessageBoxDefaultButton.Button1).ShowDialog();
        }

        public static DialogResult Show(string text, string caption,  MessageBoxButtons buttons)
        {
            return new  MessageBoxFrm(null, text, caption, buttons,  MessageBoxIcon.None,  MessageBoxDefaultButton.Button1).ShowDialog();
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption,  MessageBoxButtons buttons,  MessageBoxIcon icon)
        {
            return new  MessageBoxFrm(owner, text, caption, buttons, icon,  MessageBoxDefaultButton.Button1).ShowDialog();
        }

        public static DialogResult Show(string text, string caption,  MessageBoxButtons buttons,  MessageBoxIcon icon)
        {
            return new  MessageBoxFrm(null, text, caption, buttons, icon,  MessageBoxDefaultButton.Button1).ShowDialog();
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption,  MessageBoxButtons buttons,  MessageBoxIcon icon,  MessageBoxDefaultButton defaultButton)
        {
            return new  MessageBoxFrm(owner, text, caption, buttons, icon, defaultButton).ShowDialog();
        }

        public static DialogResult Show(string text, string caption,  MessageBoxButtons buttons,  MessageBoxIcon icon,  MessageBoxDefaultButton defaultButton)
        {
            return new  MessageBoxFrm(null, text, caption, buttons, icon, defaultButton).ShowDialog();
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption,  MessageBoxButtons buttons,  MessageBoxIcon icon,  MessageBoxDefaultButton defaultButton,  MessageBoxOptions option)
        {
            return new MessageBoxFrm(null, text, caption, buttons, icon, defaultButton).ShowDialog();
        }

        public static DialogResult Show(string text, string caption,  MessageBoxButtons buttons,  MessageBoxIcon icon,  MessageBoxDefaultButton defaultButton,  MessageBoxOptions option)
        {

            return new MessageBoxFrm(null, text, caption, buttons, icon, defaultButton,option).ShowDialog();
        }

        #endregion

        #region 私有方法

        #endregion

    }

}
