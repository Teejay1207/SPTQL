using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPTQL
{
    public partial class Form1 : Form
    {
        private Process serverProcess;
        private Process launcherProcess;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Load the delaySeconds setting
            textBox1.Text = Properties.Settings.Default.DelaySeconds.ToString();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Save the delaySeconds setting
            if (int.TryParse(textBox1.Text, out var delaySeconds))
            {
                Properties.Settings.Default.DelaySeconds = delaySeconds;
                Properties.Settings.Default.Save();
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*",
                Title = "Select Server and Launcher Executables",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileNames.Length == 2)
                {
                    Properties.Settings.Default.ServerPath = openFileDialog.FileNames[0];
                    Properties.Settings.Default.LauncherPath = openFileDialog.FileNames[1];
                    Properties.Settings.Default.Save();
                    statusLabel.Text = "Paths Set";
                    await Task.Delay(2000);
                    statusLabel.Text = "Ready";
                }
                else
                {
                    statusLabel.Text = "Select Server + Launcher Files.";
                }
            }
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (serverProcess != null && !serverProcess.HasExited)
                {
                    serverProcess.Kill();
                    serverProcess = null;
                }

                if (launcherProcess != null && !launcherProcess.HasExited)
                {
                    launcherProcess.Kill();
                    launcherProcess = null;
                }
                statusLabel.Text = "Closed";
                await Task.Delay(2000);
                statusLabel.Text = "Ready";
            }
            catch (Exception)
            {
                statusLabel.Text = "Error Closing";
            }
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            var serverPath = Properties.Settings.Default.ServerPath;
            var launcherPath = Properties.Settings.Default.LauncherPath;

            if (string.IsNullOrEmpty(serverPath) || string.IsNullOrEmpty(launcherPath))
            {
                statusLabel.Text = "Set Paths";
                return;
            }

            if (!int.TryParse(textBox1.Text, out int delaySeconds))
            {
                statusLabel.Text = "Invalid delay value";
                return;
            }

            try
            {
                var launcherStartInfo = new ProcessStartInfo
                {
                    FileName = launcherPath,
                    WorkingDirectory = Path.GetDirectoryName(launcherPath)
                };
                launcherProcess = Process.Start(launcherStartInfo);
                statusLabel.Text = "Server Launched";
                await Task.Delay(2000); // Wait for 2 seconds
                statusLabel.Text = "Ready";

                await Task.Delay(delaySeconds * 1000); // Wait for the specified seconds

                var serverStartInfo = new ProcessStartInfo
                {
                    FileName = serverPath,
                    WorkingDirectory = Path.GetDirectoryName(serverPath)
                };
                serverProcess = Process.Start(serverStartInfo);
                statusLabel.Text = "Launcher Launched";
                await Task.Delay(2000); // Wait for 2 seconds
                statusLabel.Text = "Ready";
            }
            catch (Exception)
            {
                statusLabel.Text = "Error Launching";
            }
        }

        private async void btnConfigEditor_Click(object sender, EventArgs e)
        {
            var configEditorUI = new ConfigEditor();
            configEditorUI.Show();
            statusLabel.Text = "Config Editor Launched";
            await Task.Delay(2000); // Wait for 2 seconds
            statusLabel.Text = "Ready";
        }
    }
}
