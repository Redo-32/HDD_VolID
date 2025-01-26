using System;
using System.IO;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;  // Make sure this is included

namespace HDD_VolID
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string GetHDSerialNo(string strDrive)
        {
            // Ensure Valid Drive Letter Entered, Else Default to "C"
            if (string.IsNullOrEmpty(strDrive))
            {
                strDrive = (cbodrive.SelectedItem.ToString());
            }
            // Create ManagementObject for the specified drive
            ManagementObject moHD = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + strDrive + ":\"");
            // Get information
            moHD.Get();
            // Return the Volume Serial Number as a string
            return moHD["VolumeSerialNumber"].ToString();
        }

        private void cbodrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDrive = cbodrive.SelectedItem.ToString();
            HWID.Text = GetHDSerialNo(selectedDrive).Insert(4, "-");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate cbodrive with available drive letters
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Fixed) // Only include fixed drives (e.g., hard drives)
                {
                    cbodrive.Items.Add(drive.Name.Substring(0, 1)); // Add only the drive letter (e.g., "C")
                }
            }
            if (cbodrive.Items.Count > 0)
            {
                cbodrive.SelectedIndex = 0; // Select the first drive by default
            }
            // Set HWID TextBox with default drive serial number
            HWID.Text = GetHDSerialNo(cbodrive.SelectedItem.ToString()).Insert(4, "-");

            // Change path to temporary folder
            string volumeIdPath = Path.Combine(Application.StartupPath, "Volumeid.exe");

            // Check if the Volumeid.exe file exists in the temporary folder and create it if it doesn't
            if (!File.Exists(volumeIdPath))
            {
                File.WriteAllBytes(volumeIdPath, Properties.Resources.Volumeid);
            }
        }
        private void GenHWID_Click(object sender, EventArgs e)
        {
            string hwid = GenVolID();
            HWID.Text = hwid;
        }
        private string GenVolID()
        {
            Random random = new Random();
            string hexCharacters = "0123456789ABCDEF";
            string hwid = "";

            for (int i = 0; i < 4; i++)  // Generate 4 characters for the first segment
            {
                hwid += hexCharacters[random.Next(hexCharacters.Length)];
            }
            hwid += "-";

            for (int i = 0; i < 4; i++)  // Generate 4 characters for the second segment
            {
                hwid += hexCharacters[random.Next(hexCharacters.Length)];
            }
            return hwid;
        }

        private void ChangeHWID_Click(object sender, EventArgs e)
        {
            // Ensure HWID.Text has been trimmed and validated beforehand
            string hwid = HWID.Text.Trim();
            if (string.IsNullOrEmpty(hwid))
            {
                MessageBox.Show("Please generate a valid HWID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            {
                string selectedDrive = cbodrive.SelectedItem.ToString();
                string volumeIdPath = Path.Combine(Application.StartupPath, "Volumeid.exe");
                var processInfo = new ProcessStartInfo  // Prepare the process to change the HWID
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/c Volumeid.exe " + selectedDrive + ": " + hwid + "", // Assuming "C:" is the drive to change the HWID
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };
                using (var process = Process.Start(processInfo))  // Start the process
                {
                    if (process != null)
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();
                        // Display the result
                        if (process.ExitCode == 0)
                        {
                            MessageBox.Show("HWID changed successfully to : " + hwid + "\nRestart Computer to apply changes..\n\n"/* + output */, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to change HWID.\nMake sure app is running with admin privileges..\n\n" /* + error */, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to start the process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Override the FormClosing event to delete Volumeid.exe
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            string volumeIdPath = Path.Combine(Application.StartupPath, "Volumeid.exe");
            if (File.Exists(volumeIdPath))
            {
                File.Delete(volumeIdPath);
            }
            else
            {
                MessageBox.Show("An error occurred while deleting Volumeid.exe:\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}