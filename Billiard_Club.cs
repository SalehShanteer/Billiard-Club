using Billiard_Club.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billiard_Club
{
    public partial class frmMain : Form
    {

        private static Panel[] Tables = new Panel[8];

        private static int[] TimerCounter = new int[8];

        private static bool[] TimerEnable = new bool[8];

        private void DarkTheme()
        {
            pbSwitchTheme.Image = Resources.off_button;

            lblDateTimeMain.ForeColor = Color.White;
            gbPrice.ForeColor = Color.White;
            lblTimer1.ForeColor = Color.White;
            lblTimer2.ForeColor = Color.White;
            lblTimer3.ForeColor = Color.White;
            lblTimer4.ForeColor = Color.White;
            lblTimer5.ForeColor = Color.White;
            lblTimer6.ForeColor = Color.White;
            lblTimer7.ForeColor = Color.White;
            lblTimer8.ForeColor = Color.White;
            lblTimerTxt1.ForeColor = Color.White;
            lblTimerTxt2.ForeColor = Color.White;
            lblTimerTxt3.ForeColor = Color.White;
            lblTimerTxt4.ForeColor = Color.White;
            lblTimerTxt5.ForeColor = Color.White;
            lblTimerTxt6.ForeColor = Color.White;
            lblTimerTxt7.ForeColor = Color.White;
            lblTimerTxt8.ForeColor = Color.White;
            lblNametxt1.ForeColor = Color.White;
            lblNametxt2.ForeColor = Color.White;
            lblNametxt3.ForeColor = Color.White;
            lblNametxt4.ForeColor = Color.White;
            lblNametxt5.ForeColor = Color.White;
            lblNametxt6.ForeColor = Color.White;
            lblNametxt7.ForeColor = Color.White;
            lblNametxt8.ForeColor = Color.White;

            this.BackColor = Color.Black;
        }

        private void LightTheme()
        {
            pbSwitchTheme.Image = Resources.on_button;

            lblDateTimeMain.ForeColor = Color.Black;
            gbPrice.ForeColor = Color.Black;
            lblTimer1.ForeColor = Color.Black;
            lblTimer2.ForeColor = Color.Black;
            lblTimer3.ForeColor = Color.Black;
            lblTimer4.ForeColor = Color.Black;
            lblTimer5.ForeColor = Color.Black;
            lblTimer6.ForeColor = Color.Black;
            lblTimer7.ForeColor = Color.Black;
            lblTimer8.ForeColor = Color.Black;
            lblTimerTxt1.ForeColor = Color.Black;
            lblTimerTxt2.ForeColor = Color.Black;
            lblTimerTxt3.ForeColor = Color.Black;
            lblTimerTxt4.ForeColor = Color.Black;
            lblTimerTxt5.ForeColor = Color.Black;
            lblTimerTxt6.ForeColor = Color.Black;
            lblTimerTxt7.ForeColor = Color.Black;
            lblTimerTxt8.ForeColor = Color.Black;
            lblNametxt1.ForeColor = Color.Black;
            lblNametxt2.ForeColor = Color.Black;
            lblNametxt3.ForeColor = Color.Black;
            lblNametxt4.ForeColor = Color.Black;
            lblNametxt5.ForeColor = Color.Black;
            lblNametxt6.ForeColor = Color.Black;
            lblNametxt7.ForeColor = Color.Black;
            lblNametxt8.ForeColor = Color.Black;
           
            this.BackColor = Color.LightSkyBlue;
        }

        private void Reset()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    if (control.Tag == "ON")
                    {
                        control.Tag = "OFF";
                        ResetAllControlsInPanel((Panel)control);
                    }

                }
            }
            ResetTables();
            ResetTimers();
        }

        private void ResetAllControlsInPanel(Panel pnl)
        {
            pnl.Tag = "OFF";
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (ctrl.Text == "Resume")
                        ctrl.Text = "Pause";
                    btn.BackColor = Color.Gray;
                    btn.Enabled = false;
                }
                if (ctrl is PictureBox)
                {
                    if (ctrl.Name.Contains("pb"))
                        ctrl.BackColor = Color.Black;
                }

                if (ctrl is Label)
                { 
                    if (ctrl.Tag == "Name")
                        ctrl.Text = "";

                    if (ctrl.Tag == "Timer")
                        ctrl.Text = "00:00:00";
                }
            }
        }

        private void ResetTables()
        {
            Array.Clear(Tables, 0, Tables.Length);
            Tables[0] = pnlTable1;
            Tables[1] = pnlTable2;
            Tables[2] = pnlTable3;
            Tables[3] = pnlTable4;
            Tables[4] = pnlTable5;
            Tables[5] = pnlTable6;
            Tables[6] = pnlTable7;
            Tables[7] = pnlTable8;

        }

        private void ResetTimers()
        {
            //Reset Timer Counter 
            Array.Clear(TimerCounter, 0, TimerCounter.Length);
            TimerCounter[0] = 0;
            TimerCounter[1] = 0;
            TimerCounter[2] = 0;
            TimerCounter[3] = 0;
            TimerCounter[4] = 0;
            TimerCounter[5] = 0;
            TimerCounter[6] = 0;
            TimerCounter[7] = 0;
            //Reset Timer
            Array.Clear(TimerEnable, 0, TimerEnable.Length);
            TimerEnable[0] = false;
            TimerEnable[1] = false;
            TimerEnable[2] = false;
            TimerEnable[3] = false;
            TimerEnable[4] = false;
            TimerEnable[5] = false;
            TimerEnable[6] = false;
            TimerEnable[7] = false;
        }

        private bool FindEmptyTable(ref Panel Table)
        {
            foreach (Panel pnl in Tables)
            {
                if (pnl.Tag == "OFF")
                {
                    pnl.Tag = "ON";
                    Table = pnl;
                    return true;
                }
            }
            return false;
        }

        private void EnableButton(Button btn)
        {
            btn.Enabled = true;
            btn.BackColor = Color.CornflowerBlue;
        }

        private void DisableButton(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = Color.Gray;
        }

        private void AddToTable(Panel Table)
        {
            foreach (Control ctrl in Table.Controls)
            {
                if (ctrl.Tag == "Start" && ctrl is Button)
                    EnableButton((Button)ctrl);
                if (ctrl.Tag == "Name" && ctrl is Label)
                {
                    ctrl.Text = txtPlayerName.Text;
                    txtPlayerName.Clear();
                }
            }
        }

        private void Add()
        {
            Panel Table = new Panel();
            if (FindEmptyTable(ref Table))
            {
                AddToTable(Table); 
            }
            else
                MessageBox.Show("There is no table available :-(", "Tables Are Full", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private float TotalPriceOfTable(int Seconds)
        {
            float PricePerHour = Convert.ToSingle(nudPricePerHour.Value);
            return (Seconds * PricePerHour) / 3600;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timerDateTime.Enabled = true;
            Reset();
        }

        private void pbSwitchTheme_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Black)
            {
                LightTheme();
            }
            else
            {
                DarkTheme();
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTimeMain.Text = Convert.ToString(DateTime.Now);
        }

        private void TimerString(Label lbl, int s)
        {
            if (s < 60)
            {
                if (s < 10)
                    lbl.Text = $"00:00:0{s}";
                else
                    lbl.Text = $"00:00:{s}";
            }
            else if (s < 3600)
            {
                string Sec = "", Min = "";
                Sec = s % 60 < 10 ? $"0{s % 60}" : $"{s % 60}";
                Min = s / 60 < 10 ? $"0{s / 60}" : $"{s / 60}";
                lbl.Text = $"00:{Min}:{Sec}";
            }
            else
            {
                string Sec = "", Min = "", Hour = "";
                Sec = s % 60 < 10? $"0{s % 60}" : $"{s % 60}";
                Min = (s / 60) % 60 < 10 ? $"0{(s / 60) % 60}" : $"{(s / 60) % 60}";
                Hour = s / 3600 < 10 ? $"0{s / 3600}" : $"{s / 3600}";
                lbl.Text = $"{Hour}:{Min}:{Sec}";
            }
           
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPlayerName.Text))
                MessageBox.Show("Please enter a player name before!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Add();
            }
        }
        //Timer start must to add
        private void btnStart_Click(object sender, EventArgs e)
        {    
            Button btnStart = sender as Button;
            Panel Table = btnStart.Parent as Panel;
            int i = 0;
            DisableButton(btnStart);
            foreach (Control ctrl in Table.Controls)
            {
                if (ctrl.Name.Contains("pb"))
                    ctrl.BackColor = Color.Green;
                if (ctrl.Text == "Pause")
                    EnableButton(ctrl as Button);
                if (ctrl.Text == "End")
                    EnableButton(ctrl as Button);
                if (ctrl.Text.Contains("Table"))
                    i = Convert.ToInt32(ctrl.Text[ctrl.Text.Length - 1].ToString()) - 1;
            } 
            TimerEnable[i] =true;
        }

        private int GetTimerIndex(Panel pnl)
        {
            int i = 0;
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is Label)
                    if (ctrl.Text.Contains("Table"))
                        { i = Convert.ToInt32(ctrl.Text[ctrl.Text.Length - 1].ToString()) - 1; break;}
            }
            return i;
        }

        private void btnEnd1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the table?", "Close Table",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Button btnEnd = sender as Button;
                Panel pnl = btnEnd.Parent as Panel;
                int i = GetTimerIndex(pnl);
                TimerEnable[i] = false;
                MessageBox.Show($"The price is ${TotalPriceOfTable(TimerCounter[i])}", "Total Price", MessageBoxButtons.OK);
                TimerCounter[i] = 0;
                ResetAllControlsInPanel(pnl);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimerEnable[0])
            {
                TimerCounter[0]++;
                TimerString(lblTimer1, TimerCounter[0]);
            }
            if (TimerEnable[1])
            {
                TimerCounter[1]++;
                TimerString(lblTimer2, TimerCounter[1]);
            }
            if (TimerEnable[2])
            {
                TimerCounter[2]++;
                TimerString(lblTimer3, TimerCounter[2]);
            }
            if (TimerEnable[3])
            {
                TimerCounter[3]++;
                TimerString(lblTimer4, TimerCounter[3]);
            }
            if (TimerEnable[4])
            {
                TimerCounter[4]++;
                TimerString(lblTimer5, TimerCounter[4]);
            }
            if (TimerEnable[5])
            {
                TimerCounter[5]++;
                TimerString(lblTimer6, TimerCounter[5]);
            }
            if (TimerEnable[6])
            {
                TimerCounter[6]++;
                TimerString(lblTimer7, TimerCounter[6]);
            }
            if (TimerEnable[7])
            {
                TimerCounter[7]++;
                TimerString(lblTimer8, TimerCounter[7]);
            }

        }


        private void btnPause1_Click(object sender, EventArgs e)
        {
            Button btnPause = (Button)sender;
            Panel pnl = btnPause.Parent as Panel;
            int i = GetTimerIndex(pnl);
            if (btnPause.Text == "Pause")
            {
                btnPause.Text = "Resume";
                TimerEnable[i] = false;
                foreach (Control ctrl in pnl.Controls)
                {
                    if (ctrl.Name.Contains("pb"))
                    {
                        ctrl.BackColor = Color.Yellow;
                        break;
                    }
                }
            }
            else
            {
                btnPause.Text = "Pause";
                TimerEnable[i] = true;
                foreach (Control ctrl in pnl.Controls)
                {
                    if (ctrl.Name.Contains("pb"))
                    {
                        ctrl.BackColor = Color.Green;
                        break;
                    }
                }
            }
        }
    }
}
