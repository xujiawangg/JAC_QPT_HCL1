﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MsgBox
{

    /****************************************************************
    * 
    *           Author：苦笑
    *             Blog: http://www.cnblogs.com/Keep-Silence-/
    *             Date: 2013-2-22
    *
    *****************************************************************/


    /// <summary>
    /// 仿QQ效果的MessageBox
    /// </summary>
    public class QQMessageBox : Form
    {

        #region Field

        private Image _msgBoxIcon;

        #endregion

        public enum MyIcon
        {
            Error,
            Explorer,
            Find,
            Information,
            Mail,
            Media,
            Print,
            Question,
            RecycleBinEmpty,
            RecycleBinFull,
            Stop,
            User,
            Warning,
            OK
        }
        public enum MyButtons
        {
            AbortRetryIgnore,
            OK,
            OKCancel,
            RetryCancel,
            YesNo,
            YesNoCancel
        }

        #region Constructor

        public QQMessageBox(string msgText, string caption, MyIcon msgBoxIcon, MyButtons msgBoxButtons)
        {
            this.MessageText = msgText;
            this.Text = caption;
            LoadMsgBoxIcon(msgBoxIcon);
            LoadMsgBoxButtons(msgBoxButtons);
            InitializeComponent();
        }
        
        #endregion

        #region Properites

        public string MessageText { get; set; }

        internal Rectangle MessageTextRect
        {
            get { return new Rectangle(38 + 40 + 6, 55, 220, 50); }
        }

        internal static Image MsgBoxBackgroundImg { get; set; }

        #endregion

        #region Override

        protected override void OnPaint(PaintEventArgs e)
        {


            //draw background image
            if (MsgBoxBackgroundImg != null)
            {
                if (MsgBoxBackgroundImg.Width > ClientSize.Width && MsgBoxBackgroundImg.Height > ClientSize.Height)
                {
                    e.Graphics.DrawImage(
                        MsgBoxBackgroundImg,
                        ClientRectangle,
                        new Rectangle(0, 0, ClientSize.Width, ClientSize.Height),
                        GraphicsUnit.Pixel);
                }
                else
                {
                    e.Graphics.DrawImage(
                        MsgBoxBackgroundImg,
                        ClientRectangle,
                        new Rectangle(0, 0, MsgBoxBackgroundImg.Width, MsgBoxBackgroundImg.Height),
                        GraphicsUnit.Pixel);
                }
            }

            //draw alpha part
            DrawAlphaPart(this, e.Graphics);

            //draw icon
            e.Graphics.DrawImage(_msgBoxIcon, new Rectangle(30, 48, 40, 40));

            //draw message text
            DrawMessageText(e.Graphics);

            base.OnPaint(e);
        }

        #endregion

        #region Public

        /// <summary>
        /// 显示QQMessageBox消息框
        /// </summary>
        /// <param name="owner">父窗体,默认为null,设置此参数可更改消息框的背景图与父窗体一致</param>
        /// <param name="msgText">提示文本</param>
        /// <param name="caption">消息框的标题</param>
        /// <param name="msgBoxIcon">消息框的图标枚举</param>
        /// <param name="msgBoxButtons">消息框的按钮,此值可为MessageBoxButtons.OK,MessageBoxButtons.OKCancelMessageBoxButtons.RetryCancel</param>
        public static DialogResult Show(
            Form owner = null,
            string msgText = "请输入提示信息",
            string caption = "提示",
            MyIcon msgBoxIcon = MyIcon.Information,
            MyButtons msgBoxButtons = MyButtons.OK)
        {
            using (QQMessageBox msgBox = new QQMessageBox(msgText, caption, msgBoxIcon, msgBoxButtons))
            {
                if (owner != null)
                {
                    msgBox.StartPosition = FormStartPosition.CenterParent;
                    if (owner.BackgroundImage != null)
                    {
                        //使用父窗体的背景图片
                        MsgBoxBackgroundImg = owner.BackgroundImage;
                    }
                    if (owner.Icon != null)
                    {
                        msgBox.Icon = owner.Icon;
                    }
                }
                else
                {
                    msgBox.StartPosition = FormStartPosition.CenterScreen;
                }
                msgBox.ShowDialog();
                return msgBox.DialogResult;
            }
            
        }

        #endregion

        #region Private

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // QQMessageBox
            // 
            //this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(339, 154);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QQMessageBox";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        private void LoadMsgBoxIcon(MyIcon msgBoxIcon)
        {
            switch (msgBoxIcon)
            {
                case MyIcon.Error:
                    _msgBoxIcon = Image.FromFile(Application.StartupPath + "\\Resources\\Error.png");
                    break;
                case MyIcon.Information:
                    _msgBoxIcon = Image.FromFile(Application.StartupPath + "\\Resources\\Information.png");
                    break;
                case MyIcon.OK:
                    _msgBoxIcon = Image.FromFile(Application.StartupPath + "\\Resources\\Information.png");
                    break;
                case MyIcon.Question:
                    _msgBoxIcon = Image.FromFile(Application.StartupPath + "\\Resources\\Question.png");
                    break;
                case MyIcon.Warning:
                    _msgBoxIcon = Image.FromFile(Application.StartupPath + "\\Resources\\Warning.png");
                    break;
                default:
                    break;
            }
        }

        private void LoadMsgBoxButtons(MyButtons msgBoxButtons)
        {
            switch (msgBoxButtons)
            {
                case MyButtons.OK:
                    CreateOKButton();
                    break;
                case MyButtons.OKCancel:
                    CreateOKCancelButton();
                    break;
                case MyButtons.RetryCancel:
                    CreateRetryCancleButton();
                    break;
                default:
                    break;
            }
        }

        private void DrawMessageText(Graphics g)
        {
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.FormatFlags = StringFormatFlags.NoClip;
                stringFormat.Trimming = StringTrimming.EllipsisWord;

                using (Font msgTextFont = new Font("微软雅黑", 9))
                {
                    g.DrawString(MessageText, msgTextFont, Brushes.Black, MessageTextRect, stringFormat);
                }
            }
        }

        public void DrawAlphaPart(Form form, Graphics g)
        {
            Color[] colors = 
            {
               Color.FromArgb(0, Color.White),
               Color.FromArgb(225,Color.White),
               Color.FromArgb(240, Color.White)
            };

            float[] pos = 
            {
                0.0f,
                0.38f,
                1.0f                       
            };

            ColorBlend colorBlend = new ColorBlend(3);
            colorBlend.Colors = colors;
            colorBlend.Positions = pos;

            int bottomHeight = 35;  //底部未渐变部分的高度
            RectangleF destRect = new RectangleF(0, 0, form.Width, form.Height - bottomHeight);


            //绘制上部白色渐变层
            using (LinearGradientBrush lBrushUp = new LinearGradientBrush(destRect, Color.White, Color.Black, LinearGradientMode.Vertical))
            {
                lBrushUp.InterpolationColors = colorBlend;
                g.FillRectangle(lBrushUp, destRect);
            }

            //绘制中间白色分割条
            using (Pen whitePen = new Pen(Color.FromArgb(255, Color.White), 0.1f))
            {
                g.DrawLine(whitePen, new Point(0, form.Height - bottomHeight), new Point(form.Width, form.Height - bottomHeight));
            }

            //绘制下部白色固体画刷层
            using (SolidBrush sBrushDown = new SolidBrush(Color.FromArgb(205, Color.White)))
            {
                g.FillRectangle(sBrushDown, new Rectangle(0, form.Height - bottomHeight + 1, form.Width, form.Height - bottomHeight + 1));
            }
        }

        private void CreateOKButton()
        {//确定
            Button okBtn = new Button();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            okBtn.Font = new Font("微软雅黑", 9F);
            okBtn.Location = new Point(260, 125);
            okBtn.Name = "OKBtn";
            okBtn.Size = new Size(68, 23);
            okBtn.TabIndex = 0;
            okBtn.Text = "确定";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += new EventHandler(OKBtn_Click);
            this.Controls.Add(okBtn);
            this.AcceptButton = okBtn;
            this.ResumeLayout();
        }

        private void CreateOKCancelButton()
        { //确定 取消
            Button okBtn = new Button();
            Button cancelBtn = new Button();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            okBtn.Font = new Font("微软雅黑", 9F);
            okBtn.Location = new Point(179, 125);
            okBtn.Name = "OKBtn";
            okBtn.Size = new Size(68, 23);
            okBtn.TabIndex = 0;
            okBtn.Text = "确定";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += new EventHandler(OKBtn_Click);
            //
            //CancelBtn
            //
            cancelBtn.Font = new Font("微软雅黑", 9F);
            cancelBtn.Location = new Point(260, 125);
            cancelBtn.Name = "cancleBtn";
            cancelBtn.Size = new Size(68, 23);
            cancelBtn.TabIndex = 1;
            cancelBtn.Text = "取消";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += new EventHandler(CancelBtn_Click);
            this.Controls.Add(okBtn);
            this.Controls.Add(cancelBtn);
            this.AcceptButton = okBtn;
            this.ResumeLayout();
        }

        private void CreateRetryCancleButton()
        {//重试 取消
            Button retryBtn = new Button();
            Button cancelBtn = new Button();
            this.SuspendLayout();
            // 
            // retryBtn
            // 
            retryBtn.Font = new Font("微软雅黑", 9F);
            retryBtn.Location = new Point(179, 125);
            retryBtn.Name = "retryBtn";
            retryBtn.Size = new Size(68, 23);
            retryBtn.TabIndex = 0;
            retryBtn.Text = "重试";
            retryBtn.UseVisualStyleBackColor = true;
            retryBtn.Click += new EventHandler(RetryBtn_Click);
            //
            //CancelBtn
            //
            cancelBtn.Font = new Font("微软雅黑", 9F);
            cancelBtn.Location = new Point(260, 125);
            cancelBtn.Name = "cancleBtn";
            cancelBtn.Size = new Size(68, 23);
            cancelBtn.TabIndex = 1;
            cancelBtn.Text = "取消";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += new EventHandler(CancelBtn_Click);
            this.Controls.Add(retryBtn);
            this.Controls.Add(cancelBtn);
            this.AcceptButton = retryBtn;
            this.ResumeLayout();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RetryBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            this.Close();
        }

        #endregion

    }
}
