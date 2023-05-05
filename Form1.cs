using System.Diagnostics;
using System.Globalization;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace H1_Scenario_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Log Widget //
        public bool yep = false;
        public bool toolFound = false;
        public string Commmm = "";
        public bool isClassic = true;
        public string classic = "classic";
        public string remastered = "remastered";
        public int progressVisibleTimer = 0;





        private void button3_Click(object sender, EventArgs e)
        {
            // lock settings during build //
            var ScenarioMap = txtScenario.Text.Replace(".scenario", "");

            txtScenario.Enabled = false;
            txtToolLocation.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            rbModernGame.Enabled = false;
            rbClassicGame.Enabled = false;

            // Show busy bar //
            progressBar1.Visible = true;

            try
            {


                if (isCompiling == true)
                {
                    // Get the process by its name (e.g. "notepad")
                    Process[] processes = Process.GetProcessesByName("tool.exe");

                    // Check if the process is running
                    if (processes.Length > 0)
                    {
                        richTextBox1.AppendText($"Aborting {ScenarioMap} from compiling!");


                        // Kill the process
                        foreach (Process procesfs in processes)
                        {
                            procesfs.Kill();
                        }
                    }

                    isCompiling = false;
                    timer1.Enabled = false;
                    timer1.Stop();
                    button3.Text = "COMPILE";
                    Process_Aborted();
                    return;

                }

                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string uTextMap = textInfo.ToTitleCase(ScenarioMap);

                isCompiling = true;
                progressVisibleTimer = 0;
                seconds = 0;
                timer1.Enabled = true;
                timer1.Start();
                button3.Text = "Elapsed time:";

                // string argument = $"tool.exe structure level\\test\\{ScenarioMap} {ScenarioMap}";
                string argument; // = $"build-cache-file level\\test\\{ScenarioMap}\\{ScenarioMap}";

                string toolDir = txtToolLocation.Text.Replace("\\tool.exe", "");
                // System.Diagnostics.Process.Start("cmd.exe", argument);

                if (isClassic == true)
                {
                    richTextBox1.Text = (DateTime.Now.ToString("g") + ": Running Tool.exe - Classic - " + Environment.NewLine + Environment.NewLine + $"Loading {uTextMap}!");

                    argument = @$"build-cache-file levels\test\{ScenarioMap}\{ScenarioMap} classic";
                }
                else
                {
                    richTextBox1.Text = (DateTime.Now.ToString("g") + ": Running Tool.exe - Remastered - " + Environment.NewLine + Environment.NewLine + $"Loading {uTextMap}!");

                    argument = @$"build-cache-file levels\test\{ScenarioMap}\{ScenarioMap} remastered";
                }

                // Begin process //


                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.WorkingDirectory = toolDir; // This will run the process with administrator privileges
                //processStartInfo.Verb = "runas"; // This will run the process with administrator privileges 
                //processStartInfo.Verb = "runas"; // This will run the process with administrator privileges 
                processStartInfo.FileName = txtToolLocation.Text;

                processStartInfo.Arguments = argument;

                processStartInfo.RedirectStandardOutput = true; // Redirect the standard output of the process

                processStartInfo.CreateNoWindow = true;



                Process process = new Process();

                process.EnableRaisingEvents = true;
                process.OutputDataReceived += Process_OutputDataReceived;
                process.Exited += Process_Exited;

                process.StartInfo = processStartInfo;
                process.Start();
                richTextBox1.Text += Environment.NewLine +
                        Environment.NewLine +
                        "Loading. Done..." +
                        Environment.NewLine +
                        Environment.NewLine;

                process.BeginOutputReadLine();


                // OBS //   string output = process.StandardOutput.ReadToEnd(); // Read the output from the process
                // OBS //   process.WaitForExit(); // Wait for the process to exit
                // OBS // 
                // OBS // 
                // OBS //   Thread.Sleep(100);
                // OBS //   richTextBox1.AppendText(output + Environment.NewLine);
                // OBS //   richTextBox1.ScrollToCaret();

                // hide busy bar //
                //progressBar1.Visible = false;

                // unlock settings after build //



            }
            catch (Exception ex)
            {

                // hide busy bar //
                progressBar1.Visible = false;
                MessageBox.Show(ex.Message);

                // unlock settings after build //
                txtScenario.Enabled = true;
                txtToolLocation.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                rbModernGame.Enabled = true;
                rbClassicGame.Enabled = true;


            }
            finally
            {

                // hide busy bar //
                // progressBar1.Visible = false;
                // Save our state // 
                SaveAllSettings();
            }


        }

        private void Process_Aborted()
        {


            progressBar1.Visible = false;
        }

        private void Process_Exited(object? sender, EventArgs e)
        {
            // This event is raised when the process exits
            // Invoke the progressBar control to hide it
            // Invoke the richTextBox control to append the output text

            try
            {
                string targetFolderName = "HCEEK"; // replace with your target folder name
                string[] allDrives = Directory.GetLogicalDrives();

                // Invoke the richTextBox control to append the output text
                Invoke((Action)delegate
                {
                    progressBar1.ForeColor = Color.Green;
                    progressBar1.Style = ProgressBarStyle.Continuous;//  =  100;
                    progressBar1.Value = 100;

                    button3.Enabled = false;

                    Random random = new Random();
                    int randomNumber = random.Next(1, 2001);

                    if (randomNumber == 420)
                    {
                        richTextBox1.AppendText(Environment.NewLine + "Created by: Trevor Potprocky" + Environment.NewLine);
                    }


                });

                timer1.Enabled = false;
                timer1.Stop();
                isCompiling = false;



            }
            catch
            {

            }

            Thread.Sleep(3000);
            Invoke((Action)delegate
            {
                string fpath = HCEEKPath + "\\" + @"maps";
                string mapsss = txtScenario.Text.Replace(".scenario", ".map");

                // Check if the file exists in the folder
                if (File.Exists(Path.Combine(fpath, mapsss)))
                {
                    // Start the process to open the folder in the default file explorer and highlight the file
                    Process.Start("explorer.exe", $"/select,\"{Path.Combine(fpath, mapsss)}\"");
                }
                else
                {
                    MessageBox.Show("Map could not be compiled from Scenario, please check for logs.");
                    var ScenarioMasp = txtScenario.Text.Replace(".scenario", "");
                    richTextBox1.AppendText($"Locate your HCEEK mod folder on your current system and open to your Maps folder to find your Modded map file." + Environment.NewLine +
                        $"(e.g. HCEEK\\maps\\{ScenarioMasp}.map)" + Environment.NewLine); // executed only if target folder is not found


                }
                var ScenarioMap = txtScenario.Text.Replace(".scenario", "");
                button3.Text = "COMPILE";
                button3.Enabled = true;

                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string uTextMap = textInfo.ToTitleCase(ScenarioMap);
                richTextBox1.AppendText(DateTime.Now.ToString("g") + $": {uTextMap} scenario compiled sucessfully!" + Environment.NewLine + Environment.NewLine);
                richTextBox1.AppendText($"Did you know, {uTextMap} took {wirelessTimer} to complete as a new playable map?!");
                progressBar1.Visible = false;



                txtScenario.Enabled = true;
                txtToolLocation.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                rbModernGame.Enabled = true;
                rbClassicGame.Enabled = true;
            });



        }

        int outRecCount = 0;


        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

            // This event is raised for each line of output written to the process's StandardOutput stream
            if (!string.IsNullOrEmpty(e.Data))
            {

                Random random = new Random();
                int randomNumber = random.Next(1, 2001);

                if (randomNumber == 420)
                {
                    richTextBox1.AppendText(e.Data + Environment.NewLine + "Created by: Trevor Potprocky" + Environment.NewLine);
                }

                if (randomNumber == 343)
                {
                    richTextBox1.AppendText(e.Data + Environment.NewLine + "Ahh! I am a genius! Hmf-hm-hmHm!!!" + Environment.NewLine);
                }

                if (randomNumber == 344)
                {
                    richTextBox1.AppendText(e.Data + Environment.NewLine + "Greatings traveller! I am 343 Guilty Spark.  Plesae don't mind me! I am only adjusting your circutry for optimal performance!!!" + Environment.NewLine);
                }



                // Invoke the richTextBox control to append the output text
                outRecCount++;

                if (e.Data.Contains("done"))
                {
                    // Invoke the richTextBox control to append the output text
                    Invoke((Action)delegate
                    {
                        button3.Enabled = false;


                        progressBar1.ForeColor = Color.Green;
                        progressBar1.Style = ProgressBarStyle.Continuous;//  =  100;
                        progressBar1.Value = 100;
                    });
                }
                // $"BUILD TOOK {wirelessTimer} To COMPLETE"


                if (e.Data.Contains("FAILED"))
                {
                    // Invoke the richTextBox control to append the output text
                    Invoke((Action)delegate
                    {
                        progressBar1.ForeColor = Color.Red;
                        progressBar1.Style = ProgressBarStyle.Continuous;//  =  100;
                        progressBar1.Value = 0;
                    });
                }


                Invoke((Action)delegate
                {
                    var ScenarioMap = txtScenario.Text.Replace(".scenario", "");



                    if (outRecCount == 1)
                    {

                        richTextBox1.Text += $"Checkpoint. Done... " +
                        Environment.NewLine +
                        Environment.NewLine +
                        DateTime.Now.ToString("g") + ": Begin compile scenario process...done." + Environment.NewLine;
                        richTextBox1.AppendText(e.Data + Environment.NewLine);
                        richTextBox1.ScrollToCaret();

                    }
                    else
                    {
                        richTextBox1.AppendText(e.Data + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                    }


                    button3.Enabled = true;


                    progressBar1.ForeColor = Color.Green;
                    progressBar1.Style = ProgressBarStyle.Marquee;//  =  100;
                    progressBar1.Value = 25;

                    // Invoke the richTextBox control to append the output text


                });


            }


        }


        // UI //
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Scenario files (*.scenario)|*.scenario";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // The user selected a file, so do something with it
                    string filePath = openFileDialog.SafeFileName;
                    txtScenario.Text = filePath;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Tool.exe file (*.exe)|*.exe";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // The user selected a file, so do something with it
                    string filePath = openFileDialog.FileName;
                    txtToolLocation.Text = filePath;

                    string toolFilePath = filePath.Replace("tool.exe", "");  // example D:\SteamLibrary\steamapps\common\HCEEK\tool.exe

                    MessageBox.Show(toolFilePath);

                    if (toolFilePath != Properties.Settings.Default.HCEEK)
                    {

                        // MessageBox.Show(Path.Combine(fpath, mapsss));

                        Properties.Settings.Default.HCEEK = toolFilePath;
                        Properties.Settings.Default.Save();
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        public string HCEEKPath;

        private void Form1_Load(object sender, EventArgs e)
        {
            txtScenario.Text = Properties.Settings.Default.Map;
            txtToolLocation.Text = Properties.Settings.Default.Tool;
            yep = Properties.Settings.Default.LogWidget;
            HCEEKPath = Properties.Settings.Default.HCEEK;

            if (Properties.Settings.Default.rClassic == true)
            {
                rbClassicGame.Checked = true;
                rbModernGame.Checked = false;
            }
            else
            {
                rbClassicGame.Checked = false;
                rbModernGame.Checked = true;
            }



            string toolEXE = "tool.exe";


            if (HCEEKPath == "")
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    // Set the initial selected folder (optional)
                    dialog.SelectedPath = @"C:\";


                    // Set the dialog title and description
                    dialog.Description = "Please locate a HCEEK folder for your mod projects.";
                    dialog.ShowNewFolderButton = true;

                    // Only allow the user to select folders (not files)
                    dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                    dialog.SelectedPath = @"C:\";


                    // Show the dialog and wait for the user to select a folder
                    DialogResult result = dialog.ShowDialog();

                    // If the user selected a folder, display its path in the label control
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                    {
                        HCEEKPath = dialog.SelectedPath;

                        txtToolLocation.Text = HCEEKPath + "\\" + toolEXE;
                        Properties.Settings.Default.HCEEK = HCEEKPath + "\\";

                        Properties.Settings.Default.Save();
                    }
                    else
                    {

                        MessageBox.Show("Please select a HCEEK directory.");
                        if (txtScenario.Text == "")
                        {
                            button3.Enabled = false;
                        }
                        else
                        {
                            button3.Enabled = true;
                        }
                        Application.Restart();
                    }
                }
            }
             

            if (yep == true)
            {


                // Rename the button text //
                button4.Text = "HIDE LOG";

                // Show the widget //
                this.Size = new Size(837, 518);
                this.MaximumSize = new Size(1068, 705);
                this.MinimumSize = new Size(702, 433);



            }
            else
            {
                // Rename the button text //
                button4.Text = "SHOW LOG";

                // Dont show the widget //
                this.Size = new Size(447, 222);
                this.MaximumSize = new Size(1080, 222);
                this.MinimumSize = new Size(447, 222);


            }




        }


        private void button4_Click(object sender, EventArgs e)
        {
            // resize control //

            if (yep == false)
            {
                yep = true;

                // Rename the button text //
                button4.Text = "HIDE LOG";

                // Show the widget //
                this.Size = new Size(837, 518);
                this.MaximumSize = new Size(1068, 705);
                this.MinimumSize = new Size(702, 433);



            }
            else
            {
                yep = false;

                // Rename the button text //
                button4.Text = "SHOW LOG";

                // Dont show the widget //
                this.Size = new Size(447, 215);
                this.MaximumSize = new Size(447, 215);
                this.MinimumSize = new Size(447, 215);


            }

            // Save our state // 
            SaveAllSettings();
        }




        void SaveAllSettings()
        {
            Properties.Settings.Default.Tool = txtToolLocation.Text;
            Properties.Settings.Default.Map = txtScenario.Text;
            Properties.Settings.Default.LogWidget = yep;
            Properties.Settings.Default.rClassic = isClassic;
            Properties.Settings.Default.Save();
        }


        bool isCompiling = false;
        bool isHovering = false;
        string wirelessTimer;
        int seconds;

        private void timer1_Tick(object sender, EventArgs e)
        {
            // hide busy bar //
            //progressBar1.Visible = false;

            progressVisibleTimer++;

            seconds = progressVisibleTimer;
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string timeFormatted = time.ToString(@"hh\:mm\:ss");

            wirelessTimer = timeFormatted;
            button3.Text = $"Compile time: {timeFormatted}";





            if (isHovering == true)
            {
                button3.Text = $"Click to Abort. Compile time: {wirelessTimer}";

            }

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (isCompiling == true)
            {
                isHovering = true;
                button3.Text = $"Click to Abort. Compile time: {wirelessTimer}";

            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (isHovering == true)
            {
                isHovering = false;
                button3.Text = $"Compile time: {wirelessTimer}";

            }
        }

        private void rbClassicGame_CheckedChanged(object sender, EventArgs e)
        {
            if (rbClassicGame.Checked == true)
            {
                isClassic = true;
                SaveAllSettings();

            }

        }

        private void rbModernGame_CheckedChanged(object sender, EventArgs e)
        {

            if (rbClassicGame.Checked == false)
            {
                isClassic = false;
                SaveAllSettings();

            }
        }

        private void txtScenario_TextChanged(object sender, EventArgs e)
        {
            if (txtScenario.Text == "")
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fpath = HCEEKPath + "\\" + @"maps";
            string mapsss = txtScenario.Text.Replace(".scenario", ".map");

            // Check if the file exists in the folder
            if (File.Exists(Path.Combine(fpath, mapsss)))
            {
                // Start the process to open the folder in the default file explorer and highlight the file
                Process.Start("explorer.exe", $"/select,\"{Path.Combine(fpath, mapsss)}\"");
            }
            else
            {
                MessageBox.Show(Path.Combine(fpath, mapsss));
            }
        }
    }
}