using DungeonTracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DungeonTracker
{
    public partial class Tracker : Form
    {
        private Color DefaultColor = Color.FromArgb(107, 244, 66);

        public Tracker()
        {
            InitializeComponent();
            SetNames();
            StartTimer();
        }

        private void StartTimer()
        {
            var key = Settings.Default.Key;

            if (!string.IsNullOrWhiteSpace(key))
            {
                var timer = new System.Threading.Timer((e) =>
                {
                    UpdateView();
                }, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            }
        }

        private void UpdateView()
        {
            try
            {
                var response = ApiBase.DeserializeObject<List<string>>($"https://api.guildwars2.com/v2/account/dungeons?access_token={Settings.Default.Key}");

                if (response.Contains("ac_story")) { pathListAC.P1.ForeColor = DefaultColor; }
                if (response.Contains("hodgins")) { pathListAC.P2.ForeColor = DefaultColor; }
                if (response.Contains("detha")) { pathListAC.P3.ForeColor = DefaultColor; }
                if (response.Contains("tzark")) { pathListAC.P4.ForeColor = DefaultColor; }

                if (response.Contains("cm_story")) { pathListCM.P1.ForeColor = DefaultColor; }
                if (response.Contains("asura")) { pathListCM.P2.ForeColor = DefaultColor; }
                if (response.Contains("seraph")) { pathListCM.P3.ForeColor = DefaultColor; }
                if (response.Contains("butler")) { pathListCM.P4.ForeColor = DefaultColor; }

                if (response.Contains("ta_story")) { pathListTA.P1.ForeColor = DefaultColor; }
                if (response.Contains("leurent")) { pathListTA.P2.ForeColor = DefaultColor; }
                if (response.Contains("vevina")) { pathListTA.P3.ForeColor = DefaultColor; }
                if (response.Contains("aetherpath")) { pathListTA.P4.ForeColor = DefaultColor; }

                if (response.Contains("se_story")) { pathListSE.P1.ForeColor = DefaultColor; }
                if (response.Contains("fergg")) { pathListSE.P2.ForeColor = DefaultColor; }
                if (response.Contains("rasalov")) { pathListSE.P3.ForeColor = DefaultColor; }
                if (response.Contains("koptev")) { pathListSE.P4.ForeColor = DefaultColor; }

                if (response.Contains("cof_story")) { pathListCOF.P1.ForeColor = DefaultColor; }
                if (response.Contains("ferrah")) { pathListCOF.P2.ForeColor = DefaultColor; }
                if (response.Contains("magg")) { pathListCOF.P3.ForeColor = DefaultColor; }
                if (response.Contains("rhiannon")) { pathListCOF.P4.ForeColor = DefaultColor; }

                if (response.Contains("hotw_story")) { pathListHOTW.P1.ForeColor = DefaultColor; }
                if (response.Contains("butcher")) { pathListHOTW.P2.ForeColor = DefaultColor; }
                if (response.Contains("plunderer")) { pathListHOTW.P3.ForeColor = DefaultColor; }
                if (response.Contains("zealot")) { pathListHOTW.P4.ForeColor = DefaultColor; }

                if (response.Contains("coe_story")) { pathListCOE.P1.ForeColor = DefaultColor; }
                if (response.Contains("submarine")) { pathListCOE.P2.ForeColor = DefaultColor; }
                if (response.Contains("teleporter")) { pathListCOE.P3.ForeColor = DefaultColor; }
                if (response.Contains("front_door")) { pathListCOE.P4.ForeColor = DefaultColor; }

                if (response.Contains("jotun")) { pathListARAH.P1.ForeColor = DefaultColor; }
                if (response.Contains("mursaat")) { pathListARAH.P2.ForeColor = DefaultColor; }
                if (response.Contains("forgotten")) { pathListARAH.P3.ForeColor = DefaultColor; }
                if (response.Contains("seer")) { pathListARAH.P4.ForeColor = DefaultColor; }
            }
            catch (Exception)
            {
                MessageBox.Show("Error", "There was a error with your API-Key, please enter it again.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetNames()
        {
            pathListARAH.P1.Text = "P1";
            pathListARAH.P2.Text = "P2";
            pathListARAH.P3.Text = "P3";
            pathListARAH.P4.Text = "P4";

            pathListTA.P2.Text = "UP";
            pathListTA.P3.Text = "FW";
            pathListTA.P4.Text = "AE";
        }

        #region Waypoint Links
        private void pictureBoxAC_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[&BMUGAAA=]");
        }

        private void pictureBoxCM_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[&BMkGAAA=]");
        }

        private void pictureBoxTA_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[&BMgGAAA=]");
        }

        private void pictureBoxSE_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[&BMQGAAA=]");
        }

        private void pictureBoxCOF_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[&BMYGAAA=]");
        }

        private void pictureBoxHOTW_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[&BMsGAAA=]");
        }

        private void pictureBoxCOE_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[&BMoGAAA=]");
        }

        private void pictureBoxARAH_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("[&BMcGAAA=]");
        }
        #endregion

        #region Eventhandler
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            FormSettings settings = new FormSettings();
            var result = settings.ShowDialog();
            tableLayoutPanel1.Focus();
            if (result == DialogResult.OK)
            {
                StartTimer();
            }
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        
        #region user32.dll
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion  
    }
}
