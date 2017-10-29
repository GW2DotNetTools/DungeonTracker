using DungeonTracker.Properties;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DungeonTracker
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void buttonAPI_Click(object sender, EventArgs e)
        {
            Process.Start("https://account.arena.net/applications/create");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Please enter your API-Key.");
            }

            try
            {
                ApiBase.DeserializeObject<dynamic>($"https://api.guildwars2.com/v2/account?access_token={textBox1.Text}");
                Settings.Default.Key = textBox1.Text;
                Settings.Default.Save();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetError(textBox1, string.Empty);
        }
    }
}
