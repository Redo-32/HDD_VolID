namespace HDD_VolID
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChangeHWID = new System.Windows.Forms.Button();
            this.GenHWID = new System.Windows.Forms.Button();
            this.lbl_AdminPrivileges = new System.Windows.Forms.Label();
            this.HWID = new System.Windows.Forms.TextBox();
            this.cbodrive = new System.Windows.Forms.ComboBox();
            this.grp_Drive = new System.Windows.Forms.GroupBox();
            this.grp_Drive.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChangeHWID
            // 
            this.ChangeHWID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeHWID.Location = new System.Drawing.Point(16, 50);
            this.ChangeHWID.Name = "ChangeHWID";
            this.ChangeHWID.Size = new System.Drawing.Size(75, 30);
            this.ChangeHWID.TabIndex = 0;
            this.ChangeHWID.Text = "Change\r\n";
            this.ChangeHWID.UseVisualStyleBackColor = true;
            this.ChangeHWID.Click += new System.EventHandler(this.ChangeHWID_Click);
            // 
            // GenHWID
            // 
            this.GenHWID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenHWID.Location = new System.Drawing.Point(124, 50);
            this.GenHWID.Name = "GenHWID";
            this.GenHWID.Size = new System.Drawing.Size(75, 30);
            this.GenHWID.TabIndex = 1;
            this.GenHWID.Text = "Generate";
            this.GenHWID.UseVisualStyleBackColor = true;
            this.GenHWID.Click += new System.EventHandler(this.GenHWID_Click);
            // 
            // lbl_AdminPrivileges
            // 
            this.lbl_AdminPrivileges.AutoSize = true;
            this.lbl_AdminPrivileges.Location = new System.Drawing.Point(12, 107);
            this.lbl_AdminPrivileges.Name = "lbl_AdminPrivileges";
            this.lbl_AdminPrivileges.Size = new System.Drawing.Size(168, 13);
            this.lbl_AdminPrivileges.TabIndex = 2;
            this.lbl_AdminPrivileges.Text = "* Run with administrator privileges.";
            // 
            // HWID
            // 
            this.HWID.BackColor = System.Drawing.SystemColors.Window;
            this.HWID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HWID.Location = new System.Drawing.Point(86, 20);
            this.HWID.MaxLength = 10;
            this.HWID.Multiline = true;
            this.HWID.Name = "HWID";
            this.HWID.ReadOnly = true;
            this.HWID.Size = new System.Drawing.Size(112, 22);
            this.HWID.TabIndex = 3;
            this.HWID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbodrive
            //
            this.cbodrive.SelectedIndexChanged += cbodrive_SelectedIndexChanged;
            this.cbodrive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbodrive.FormattingEnabled = true;
            this.cbodrive.Location = new System.Drawing.Point(16, 20);
            this.cbodrive.Name = "cbodrive";
            this.cbodrive.Size = new System.Drawing.Size(70, 22);
            this.cbodrive.TabIndex = 4;
            // 
            // grp_Drive
            // 
            this.grp_Drive.Controls.Add(this.cbodrive);
            this.grp_Drive.Controls.Add(this.HWID);
            this.grp_Drive.Controls.Add(this.GenHWID);
            this.grp_Drive.Controls.Add(this.ChangeHWID);
            this.grp_Drive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Drive.Location = new System.Drawing.Point(12, 12);
            this.grp_Drive.Name = "grp_Drive";
            this.grp_Drive.Size = new System.Drawing.Size(212, 92);
            this.grp_Drive.TabIndex = 5;
            this.grp_Drive.TabStop = false;
            this.grp_Drive.Text = "Volume ID :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 123);
            this.Controls.Add(this.grp_Drive);
            this.Controls.Add(this.lbl_AdminPrivileges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HDD Hwid Changer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp_Drive.ResumeLayout(false);
            this.grp_Drive.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangeHWID;
        private System.Windows.Forms.Button GenHWID;
        private System.Windows.Forms.Label lbl_AdminPrivileges;
        private System.Windows.Forms.TextBox HWID;
        private System.Windows.Forms.ComboBox cbodrive;
        private System.Windows.Forms.GroupBox grp_Drive;
    }
}

