using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace IntuneWinAppUtil_GUI
{
    public partial class Form1 : Form
    {
        Thread threadCli;
        private readonly Color defaultTextColor = SystemColors.WindowText;
        private readonly string updateUrl = "update_url_goes_here"; // URL to the updated software file
        string inputText = "input path";
        string outputText = "output path";

        public Form1()
        {
            InitializeComponent();

            // Checks if IntuneWinAppUtil.exe exists, and if not runs DownloadFile to download IntuneWinAppUtil.exe from GitHub
            if (!File.Exists("IntuneWinAppUtil.exe"))
            {
                DownloadFile();
            }

            textBoxInput.Text = inputText;
            textBoxInput.ForeColor = Color.Gray;

            textBoxOutput.Text = outputText;
            textBoxOutput.ForeColor = Color.Gray;
            buttonStart.Enabled = false;

            textBoxCli.TextChanged += textBoxCli_TextChanged; // Attach the event handler to the TextBox's TextChanged event

        }

        // Downloads IntuneWinAppUtil.exe from GitHub
        private void DownloadFile()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(new Uri("https://github.com/microsoft/Microsoft-Win32-Content-Prep-Tool/raw/master/IntuneWinAppUtil.exe"), "IntuneWinAppUtil.exe");
            }
        }

        // Browse for package files + folders
        private void BrowseInput()
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
        private void BrowseOutput()
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

        private void ClearItems()
        {
            textBoxInput.Clear();
            textBoxOutput.Clear();
            textBoxCli.Clear();
            listBoxFiles.Items.Clear();
            buttonStart.Enabled = false;
        }

        // Packages software on seperate thread to avoid hanging up the software
        private void Thread1()
        {
            try
            {
                MessageBox.Show("Software name: " + textBoxSoftware.Text); // Check if error panel is working
                //string softwareName = textBoxFilename.Text;
                string appPath = System.Windows.Forms.Application.StartupPath;
                char x = (char)34;
                ProcessStartInfo procStartInfo = new ProcessStartInfo();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
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

        private void UpdateSoftware(object sender, DoWorkEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                // Download the updated software file
                client.DownloadFile(updateUrl, "software_new.exe");
            }
        }

        private void UpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
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


        // Button for input file + directory
        private void buttonInput_Click(object sender, EventArgs e)
        {
            BrowseInput();
        }

        // Button for output path
        private void buttonOutput_Click(object sender, EventArgs e)
        {
            BrowseOutput();
        }

        // Start packaging input file + directory and save .intunewin package to output path
        private void buttonStart_Click(object sender, EventArgs e)
        {
            threadCli = new Thread(Thread1);
            threadCli.Start();
        }

        private void textBoxInput_Enter(object sender, EventArgs e)
        {
            if (textBoxInput.Text == inputText)
            {
                textBoxInput.Text = string.Empty;
                textBoxInput.ForeColor = defaultTextColor;
            }
        }

        private void textBoxInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                textBoxInput.Text = inputText;
                textBoxInput.ForeColor = Color.Gray;
            }
        }

        private void textBoxOutput_Enter(object sender, EventArgs e)
        {
            if (textBoxOutput.Text == outputText)
            {
                textBoxOutput.Text = string.Empty;
                textBoxOutput.ForeColor = defaultTextColor;
            }
        }

        private void textBoxOutput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOutput.Text))
            {
                textBoxOutput.Text = outputText;
                textBoxOutput.ForeColor = Color.Gray;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Disable the update button to prevent multiple update requests
            updateToolStripMenuItem.Enabled = false;

            // Start the software update process asynchronously
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += UpdateSoftware;
            worker.RunWorkerCompleted += UpdateCompleted;
            worker.RunWorkerAsync();
        }

        private void textBoxCli_TextChanged(object sender, EventArgs e)
        {
            // Get the current text and reset the color to default
            string text = textBoxCli.Text;
            textBoxCli.ForeColor = SystemColors.ControlText;

            // Specify the keywords to be highlighted in green
            string[] keywordsGreen = { "Done!!!", "sucessfully", "text" };
            string[] keywordsYellow = { "Done!!!", "sucessfully", "text" };


            // Loop through each keyword and find its occurrences in the text
            foreach (string keyword in keywordsGreen)
            {
                // Use a regular expression to find all occurrences of the keyword
                MatchCollection matches = Regex.Matches(text, Regex.Escape(keyword), RegexOptions.IgnoreCase);

                // Change the color to green for each occurrence of the keyword
                foreach (Match match in matches)
                {
                    textBoxCli.Select(match.Index, match.Length);
                    textBoxCli.SelectionColor = Color.Green;
                }
            }

            // Reset the selection to the end of the text
            textBoxCli.Select(text.Length, 0);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

