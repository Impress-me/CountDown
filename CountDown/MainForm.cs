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
    public partial class MainForm : Form
    {

        MyTime time;
        bool isStart = false;
        InitialTime initialTime;

        public MyTime Time { get => time; set => time = value; }
        public InitialTime InitialTime { get => initialTime; set => initialTime = value; }
        public Label CountDownInterface1 { get => CountDownInterface; set => CountDownInterface = value; }
        public Button BtnStart1 { get => BtnStart; set => BtnStart = value; }
        public Timer CountDownTimer1 { get => CountDownTimer; set => CountDownTimer = value; }
        public bool IsStart { get => isStart; set => isStart = value; }

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            CountDownTimer.Interval = 1000;

            InitialTime = new InitialTime();
            time = new MyTime();
        }


        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            time.Tick();
            this.CountDownInterface.Text = time.GetCurrentTimeString();
            if(time.IsCountDownFinish())
            {
                this.CountDownTimer.Stop();
                MessageBox.Show("时间到");
                this.BtnStart.Text = "开始";
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if(initialTime.InitialMinute == 0 && initialTime.InitialSecond == 0)
            {
                MessageBox.Show("请输入倒计时长度");
                return;
            }

            if(!isStart)
            {
                CountDownTimer.Start();
                isStart = true;
                BtnStart.Text = "暂停";
            }
            else
            {
                CountDownTimer.Stop();
                isStart = false;
                BtnStart.Text = "开始";
            }
            
            
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            CountDownTimer.Stop();
            isStart = false;
            BtnStart.Text = "开始";
            time.Init(initialTime.InitialMinute, initialTime.InitialSecond);
            CountDownInterface.Text = initialTime.GetCurrentValueString();
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            Form settingForm = new SettingForm(this)
            {
                Owner = this
            };
            settingForm.ShowDialog();
            BtnStart.Focus();
            
        }
    }

    public class InitialTime
    {
        int initialMinute;
        int initialSecond;

        public InitialTime()
        {
            initialMinute = 0;
            initialSecond = 0;
        }

        public int InitialMinute { get => initialMinute; set => initialMinute = value; }
        public int InitialSecond { get => initialSecond; set => initialSecond = value; }

        public string GetCurrentValueString()
        {

            if (InitialMinute >= 10 && InitialSecond >= 10)
            {
                return Convert.ToString(InitialMinute) + ":" + Convert.ToString(InitialSecond);
            }
            else if (InitialMinute < 10 && InitialSecond >= 10)
            {
                return "0" + Convert.ToString(InitialMinute) + ":" + Convert.ToString(InitialSecond);
            }
            else if (InitialMinute >= 10 && InitialSecond < 10)
            {
                return Convert.ToString(InitialMinute) + ":" + "0" + Convert.ToString(InitialSecond);
            }
            else
            {
                return "0" + Convert.ToString(InitialMinute) + ":" + "0" + Convert.ToString(InitialSecond);
            }

        }
    }
}
