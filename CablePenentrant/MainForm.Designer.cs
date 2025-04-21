namespace CablePenentrant
{
    partial class MainForm
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
            picture = new PictureBox();
            refresh = new Button();
            label = new Label();
            scalingFactorNumeric = new NumericUpDown();
            ofd = new OpenFileDialog();
            loadFileButton = new Button();
            showLogButton = new Button();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scalingFactorNumeric).BeginInit();
            SuspendLayout();
            // 
            // picture
            // 
            picture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picture.BackColor = Color.White;
            picture.BorderStyle = BorderStyle.FixedSingle;
            picture.Location = new Point(12, 77);
            picture.Name = "picture";
            picture.Size = new Size(600, 567);
            picture.TabIndex = 0;
            picture.TabStop = false;
            // 
            // refresh
            // 
            refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refresh.Enabled = false;
            refresh.Location = new Point(467, 12);
            refresh.Name = "refresh";
            refresh.Size = new Size(145, 59);
            refresh.TabIndex = 1;
            refresh.Text = "Refresh";
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += OnRefreshClick;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(12, 31);
            label.Name = "label";
            label.Size = new Size(104, 20);
            label.TabIndex = 2;
            label.Text = "Scaling Factor:";
            // 
            // scalingFactorNumeric
            // 
            scalingFactorNumeric.DecimalPlaces = 2;
            scalingFactorNumeric.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            scalingFactorNumeric.Location = new Point(141, 31);
            scalingFactorNumeric.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            scalingFactorNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            scalingFactorNumeric.Name = "scalingFactorNumeric";
            scalingFactorNumeric.Size = new Size(150, 27);
            scalingFactorNumeric.TabIndex = 3;
            scalingFactorNumeric.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            ofd.Filter = "Penentrants|*.txt";
            // 
            // loadFileButton
            // 
            loadFileButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            loadFileButton.Location = new Point(321, 12);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(140, 59);
            loadFileButton.TabIndex = 4;
            loadFileButton.Text = "Load File";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += OnLoadClick;
            // 
            // showLogButton
            // 
            showLogButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            showLogButton.Location = new Point(493, 650);
            showLogButton.Name = "showLogButton";
            showLogButton.Size = new Size(119, 29);
            showLogButton.TabIndex = 5;
            showLogButton.Text = "Show Log";
            showLogButton.UseVisualStyleBackColor = true;
            showLogButton.Click += OnShowLogClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 689);
            Controls.Add(showLogButton);
            Controls.Add(loadFileButton);
            Controls.Add(scalingFactorNumeric);
            Controls.Add(label);
            Controls.Add(refresh);
            Controls.Add(picture);
            Name = "MainForm";
            Text = "Visualization";
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)scalingFactorNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picture;
        private Button refresh;
        private Label label;
        private NumericUpDown scalingFactorNumeric;
        private OpenFileDialog ofd;
        private Button loadFileButton;
        private Button showLogButton;
    }
}
