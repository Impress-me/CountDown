using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CountDown
{
    public partial class SettingForm : Form
    {
        MainForm mainForm;
        
        

        public SettingForm(MainForm form)
        {
            InitializeComponent();
            this.mainForm = form;
        }

        //确定键功能，将输入的数字保存到MyTime和InitialTime中，并显示在倒计时页面中
        private void BtnOK_Click(object sender, EventArgs e)
        {
            mainForm.CountDownTimer1.Stop();
            mainForm.IsStart = false;

            if(TextMinute.Text.Equals(""))
            {
                mainForm.InitialTime.InitialMinute = 0; 
            }
            else
            {
                mainForm.InitialTime.InitialMinute = Convert.ToInt32(TextMinute.Text);
            }
            if (TextSecond.Text.Equals(""))
            {
                mainForm.InitialTime.InitialSecond = 0;
            }
            else
            {
                mainForm.InitialTime.InitialSecond = Convert.ToInt32(TextSecond.Text);
            }

            mainForm.Time.Init(mainForm.InitialTime.InitialMinute, mainForm.InitialTime.InitialSecond);
            mainForm.CountDownInterface1.Text = mainForm.Time.GetCurrentTimeString();
            mainForm.BtnStart1.Text = "开始";
            
            this.Close();
        }

        //实现两个TextBox互通
        private void TextMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if(TextMinute.TextLength >= 2 && e.KeyChar != 8)
            {
                e.Handled = true;
                TextSecond.Focus();
                if (Char.IsDigit(e.KeyChar))
                {
                    TextSecond.Text = e.KeyChar.ToString();
                    TextSecond.Select(1, 0);//将光标设置到数字末尾
                }
            }
            
        }

        private void TextSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (TextSecond.TextLength >= 2 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if(e.KeyChar == 8 && TextSecond.Text.Equals(""))
            {
                TextMinute.Focus();
            }
        }

    }
}
