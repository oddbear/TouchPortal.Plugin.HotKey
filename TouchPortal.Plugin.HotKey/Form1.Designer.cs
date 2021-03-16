
namespace TouchPortal.Plugin.HotKey
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hotkeySelector = new WK.Libraries.HotkeyListenerNS.HotkeySelector(this.components);
            this.tbHotkeySelector = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbUnknownKey = new System.Windows.Forms.TextBox();
            this.cbNeverShow = new System.Windows.Forms.CheckBox();
            this.tbInformation = new System.Windows.Forms.TextBox();
            this.lblUnknownKey = new System.Windows.Forms.Label();
            this.lblMapper = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hotkeySelector1
            // 
            this.hotkeySelector.EmptyHotkeyText = "None";
            this.hotkeySelector.InvalidHotkeyText = "Unsupported";
            // 
            // tbHotkeySelector
            // 
            this.tbHotkeySelector.Location = new System.Drawing.Point(121, 154);
            this.tbHotkeySelector.Name = "tbHotkeySelector";
            this.tbHotkeySelector.Size = new System.Drawing.Size(199, 20);
            this.tbHotkeySelector.TabIndex = 2;
            this.tbHotkeySelector.Text = "None";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(245, 180);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(164, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbUnknownKey
            // 
            this.tbUnknownKey.Location = new System.Drawing.Point(12, 154);
            this.tbUnknownKey.Name = "tbUnknownKey";
            this.tbUnknownKey.ReadOnly = true;
            this.tbUnknownKey.Size = new System.Drawing.Size(100, 20);
            this.tbUnknownKey.TabIndex = 3;
            // 
            // cbNeverShow
            // 
            this.cbNeverShow.AutoSize = true;
            this.cbNeverShow.Location = new System.Drawing.Point(12, 184);
            this.cbNeverShow.Name = "cbNeverShow";
            this.cbNeverShow.Size = new System.Drawing.Size(129, 17);
            this.cbNeverShow.TabIndex = 4;
            this.cbNeverShow.Text = "Don\'t show this dialog";
            this.cbNeverShow.UseVisualStyleBackColor = true;
            // 
            // tbInformation
            // 
            this.tbInformation.Location = new System.Drawing.Point(13, 13);
            this.tbInformation.Multiline = true;
            this.tbInformation.Name = "tbInformation";
            this.tbInformation.ReadOnly = true;
            this.tbInformation.Size = new System.Drawing.Size(307, 119);
            this.tbInformation.TabIndex = 5;
            this.tbInformation.Text = resources.GetString("tbInformation.Text");
            // 
            // lblUnknownKey
            // 
            this.lblUnknownKey.AutoSize = true;
            this.lblUnknownKey.Location = new System.Drawing.Point(13, 135);
            this.lblUnknownKey.Name = "lblUnknownKey";
            this.lblUnknownKey.Size = new System.Drawing.Size(76, 13);
            this.lblUnknownKey.TabIndex = 6;
            this.lblUnknownKey.Text = "Unknown key:";
            // 
            // lblMapper
            // 
            this.lblMapper.AutoSize = true;
            this.lblMapper.Location = new System.Drawing.Point(118, 135);
            this.lblMapper.Name = "lblMapper";
            this.lblMapper.Size = new System.Drawing.Size(90, 13);
            this.lblMapper.TabIndex = 7;
            this.lblMapper.Text = "Try to add it here:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 214);
            this.Controls.Add(this.lblMapper);
            this.Controls.Add(this.lblUnknownKey);
            this.Controls.Add(this.tbInformation);
            this.Controls.Add(this.cbNeverShow);
            this.Controls.Add(this.tbUnknownKey);
            this.Controls.Add(this.tbHotkeySelector);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Add hotkey alias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WK.Libraries.HotkeyListenerNS.HotkeySelector hotkeySelector;
        private WK.Libraries.HotkeyListenerNS.HotkeyListener hotkeyListener1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbHotkeySelector;
        private System.Windows.Forms.TextBox tbUnknownKey;
        private System.Windows.Forms.CheckBox cbNeverShow;
        private System.Windows.Forms.TextBox tbInformation;
        private System.Windows.Forms.Label lblUnknownKey;
        private System.Windows.Forms.Label lblMapper;
    }
}

