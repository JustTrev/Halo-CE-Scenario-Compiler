namespace H1_Scenario_Tool
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            txtScenario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtToolLocation = new TextBox();
            button2 = new Button();
            button3 = new Button();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            richTextBox1 = new RichTextBox();
            button4 = new Button();
            rbClassicGame = new RadioButton();
            rbModernGame = new RadioButton();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            folderBrowserDialog1 = new FolderBrowserDialog();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(599, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtScenario
            // 
            txtScenario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtScenario.Location = new Point(221, 12);
            txtScenario.Name = "txtScenario";
            txtScenario.ReadOnly = true;
            txtScenario.Size = new Size(372, 23);
            txtScenario.TabIndex = 0;
            txtScenario.TextChanged += txtScenario_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(203, 15);
            label1.TabIndex = 11;
            label1.Text = "Select a scenario map file to compile:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 12;
            label2.Text = "Locate HCEEK Tool:";
            // 
            // txtToolLocation
            // 
            txtToolLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtToolLocation.Location = new Point(133, 41);
            txtToolLocation.Name = "txtToolLocation";
            txtToolLocation.Size = new Size(460, 23);
            txtToolLocation.TabIndex = 2;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(599, 41);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Browse";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button3.Enabled = false;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(221, 70);
            button3.Name = "button3";
            button3.Size = new Size(453, 54);
            button3.TabIndex = 6;
            button3.Text = "COMPILE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            button3.MouseEnter += button3_MouseEnter;
            button3.MouseLeave += button3_MouseLeave;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(12, 130);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            richTextBox1.Size = new Size(662, 205);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(12, 357);
            button4.Name = "button4";
            button4.Size = new Size(662, 25);
            button4.TabIndex = 7;
            button4.Text = "SHOW LOG";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // rbClassicGame
            // 
            rbClassicGame.AutoSize = true;
            rbClassicGame.Checked = true;
            rbClassicGame.Location = new Point(32, 70);
            rbClassicGame.Name = "rbClassicGame";
            rbClassicGame.Size = new Size(61, 19);
            rbClassicGame.TabIndex = 4;
            rbClassicGame.TabStop = true;
            rbClassicGame.Text = "Classic";
            rbClassicGame.UseVisualStyleBackColor = true;
            rbClassicGame.CheckedChanged += rbClassicGame_CheckedChanged;
            // 
            // rbModernGame
            // 
            rbModernGame.AutoSize = true;
            rbModernGame.Location = new Point(21, 95);
            rbModernGame.Name = "rbModernGame";
            rbModernGame.Size = new Size(87, 19);
            rbModernGame.TabIndex = 5;
            rbModernGame.Text = "Remastered";
            rbModernGame.UseVisualStyleBackColor = true;
            rbModernGame.CheckedChanged += rbModernGame_CheckedChanged;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.ForeColor = Color.Blue;
            progressBar1.Location = new Point(12, 341);
            progressBar1.MarqueeAnimationSpeed = 20;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(662, 10);
            progressBar1.Step = 1;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 10;
            progressBar1.Value = 100;
            progressBar1.Visible = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(133, 70);
            button5.Name = "button5";
            button5.Size = new Size(82, 54);
            button5.TabIndex = 13;
            button5.Text = "Open Map Folder";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(686, 394);
            Controls.Add(button5);
            Controls.Add(progressBar1);
            Controls.Add(rbModernGame);
            Controls.Add(rbClassicGame);
            Controls.Add(button4);
            Controls.Add(richTextBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(txtToolLocation);
            Controls.Add(label1);
            Controls.Add(txtScenario);
            Controls.Add(button1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(447, 215);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halo: CE Scenario Compiler";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtScenario;
        private Label label1;
        private Label label2;
        private TextBox txtToolLocation;
        private Button button2;
        private Button button3;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private RichTextBox richTextBox1;
        private Button button4;
        private RadioButton rbClassicGame;
        private RadioButton rbModernGame;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button5;
    }
}