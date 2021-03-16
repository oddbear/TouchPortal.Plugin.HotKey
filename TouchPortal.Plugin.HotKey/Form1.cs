using System;
using System.IO;
using System.Windows.Forms;

namespace TouchPortal.Plugin.HotKey
{
    public partial class Form1 : Form
    {
        public Form1(string unknownKey)
        {
            InitializeComponent();
            tbUnknownKey.Text = unknownKey;
            hotkeySelector.Enable(tbHotkeySelector);
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var hideDialog = cbNeverShow.Checked;
            var trueKey = tbHotkeySelector.Text.Trim();
            var falseKey = tbUnknownKey.Text.Trim();
            using (var writer = File.AppendText("key.map"))
            {
                if (hideDialog)
                {
                    writer.WriteLine("DO_NOT_SHOW_DIALOG");
                }
                if (!string.IsNullOrWhiteSpace(trueKey) && !string.IsNullOrWhiteSpace(falseKey))
                {
                    writer.WriteLine($"{trueKey}={falseKey}");
                }
            }
            Close();
        }
    }
}
