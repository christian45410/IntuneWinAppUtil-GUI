using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace IntuneWinAppUtil_GUI1
{

    public class AppPackage
    {
        public AppPackage()
        {
            // Downloads IntuneWinAppUtil.exe from GitHub
            public void DownloadFile()
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(new Uri("https://github.com/microsoft/Microsoft-Win32-Content-Prep-Tool/raw/master/IntuneWinAppUtil.exe"), "IntuneWinAppUtil.exe");
                }
            }
        }

        // Downloads IntuneWinAppUtil.exe from GitHub
        public void DownloadFile()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(new Uri("https://github.com/microsoft/Microsoft-Win32-Content-Prep-Tool/raw/master/IntuneWinAppUtil.exe"), "IntuneWinAppUtil.exe");
            }
        }

        // Browse for package files + folders
        public void BrowseInput()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse for source file",
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "all files|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                ReadOnlyChecked = false,
                ShowReadOnly = false
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBoxFiles.Items.Clear();
                textBoxSoftware.Clear();
                string sofwareName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                textBoxSoftware.Text = sofwareName;
                string fullPath = openFileDialog1.FileName;
                textBoxInput.Text = fullPath.Substring(0, fullPath.LastIndexOf('\\'));
                textBoxOutput.Text = fullPath.Substring(0, fullPath.LastIndexOf('\\'));
                textBoxInput.ForeColor = defaultTextColor;
                textBoxOutput.ForeColor = defaultTextColor;
                buttonStart.Enabled = true;
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(fullPath.Substring(0, fullPath.LastIndexOf('\\')));
                int count = dir.GetFiles().Length;

                DirectoryInfo dinfo = new DirectoryInfo(textBoxInput.Text);
                FileInfo[] Files = dinfo.GetFiles("*.*");
                foreach (FileInfo file in Files)
                {
                    listBoxFiles.Items.Add(file.Name);
                }

                if (count > 1)
                {
                    //MessageBox.Show("Multi file TEST" + sofwareName); // Check if error panel is working
                }

                else
                {
                    return;
                }
            }
        }

        // Browse for output path
        public void BrowseOutput()
        {
            textBoxOutput.Clear();
            var folderBrowserOutput = new FolderBrowserDialog();
            DialogResult result = folderBrowserOutput.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserOutput.SelectedPath;
                textBoxOutput.Text = folderName;
            }

            buttonStart.Enabled = true;
        }

        public void ClearItems()
        {
            textBoxInput.Clear();
            textBoxOutput.Clear();
            textBoxCli.Clear();
            listBoxFiles.Items.Clear();
            buttonStart.Enabled = false;
        }

        // Packages software on seperate thread to avoid hanging up the software
        public void Thread1()
        {
            try
            {
                MessageBox.Show("Software name: " + textBoxSoftware.Text); // Check if error panel is working
                                                                           //string softwareName = textBoxFilename.Text;
                string appPath = Application.StartupPath;
                char x = (char)34;
                ProcessStartInfo procStartInfo = new ProcessStartInfo();
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.FileName = appPath + @"\IntuneWinAppUtil.exe";
                proc.StartInfo.Arguments = " -c " + x + textBoxInput.Text + x + " -s " + x + textBoxSoftware.Text + x + " -o " + x + textBoxOutput.Text + x + " -q";
                proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutPutDataReceived);
                proc.Start();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
            }

            catch (Exception)
            {

            }
        }

        void proc_OutPutDataReceived(object sender, DataReceivedEventArgs e) // Prints cli output to textBoxCli
        {
            if (e.Data != null)
            {
                string newLine = e.Data.Trim() + Environment.NewLine;
                MethodInvoker append = () => textBoxCli.Text += newLine;
                textBoxCli.BeginInvoke(append);
            }
        }

        public void UpdateSoftware(object sender, DoWorkEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                // Download the updated software file
                client.DownloadFile(updateUrl, "software_new.exe");
            }
        }

        public void UpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check if the update completed successfully
            if (e.Error == null)
            {
                // Replace the existing software with the updated version
                System.IO.File.Replace("software_new.exe", "software.exe", "software_backup.exe");

                MessageBox.Show("Software updated successfully!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update software. Please try again later.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Enable the update button again
            updateToolStripMenuItem.Enabled = true;
        }
    }
}