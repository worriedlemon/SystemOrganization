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
            methodLabel = new Label();
            methodCombo = new ComboBox();
            formPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scalingFactorNumeric).BeginInit();
            SuspendLayout();
            // 
            // picture
            // 
            picture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picture.BackColor = Color.White;
            picture.BorderStyle = BorderStyle.FixedSingle;
            picture.Location = new Point(12, 12);
            picture.Name = "picture";
            picture.Size = new Size(620, 536);
            picture.TabIndex = 0;
            picture.TabStop = false;
            // 
            // refresh
            // 
            refresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refresh.Enabled = false;
            refresh.Location = new Point(638, 489);
            refresh.Name = "refresh";
            refresh.Size = new Size(175, 59);
            refresh.TabIndex = 1;
            refresh.Text = "Refresh";
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += OnRefreshClick;
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label.AutoSize = true;
            label.Location = new Point(638, 12);
            label.Name = "label";
            label.Size = new Size(104, 20);
            label.TabIndex = 2;
            label.Text = "Scaling Factor:";
            // 
            // scalingFactorNumeric
            // 
            scalingFactorNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            scalingFactorNumeric.DecimalPlaces = 2;
            scalingFactorNumeric.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            scalingFactorNumeric.Location = new Point(638, 35);
            scalingFactorNumeric.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            scalingFactorNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            scalingFactorNumeric.Name = "scalingFactorNumeric";
            scalingFactorNumeric.Size = new Size(175, 27);
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
            loadFileButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            loadFileButton.Location = new Point(638, 424);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(175, 59);
            loadFileButton.TabIndex = 4;
            loadFileButton.Text = "Load File";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += OnLoadClick;
            // 
            // showLogButton
            // 
            showLogButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            showLogButton.Location = new Point(12, 554);
            showLogButton.Name = "showLogButton";
            showLogButton.Size = new Size(119, 29);
            showLogButton.TabIndex = 5;
            showLogButton.Text = "Show Log";
            showLogButton.UseVisualStyleBackColor = true;
            showLogButton.Click += OnShowLogClick;
            // 
            // methodLabel
            // 
            methodLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            methodLabel.AutoSize = true;
            methodLabel.Location = new Point(638, 81);
            methodLabel.Name = "methodLabel";
            methodLabel.Size = new Size(64, 20);
            methodLabel.TabIndex = 2;
            methodLabel.Text = "Method:";
            // 
            // methodCombo
            // 
            methodCombo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            methodCombo.FormattingEnabled = true;
            methodCombo.Location = new Point(638, 104);
            methodCombo.Name = "methodCombo";
            methodCombo.Size = new Size(175, 28);
            methodCombo.TabIndex = 6;
            methodCombo.SelectedIndexChanged += OnSelectedMethodChange;
            // 
            // formPanel
            // 
            formPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            formPanel.Location = new Point(633, 140);
            formPanel.Margin = new Padding(0);
            formPanel.Name = "formPanel";
            formPanel.Size = new Size(187, 278);
            formPanel.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 593);
            Controls.Add(formPanel);
            Controls.Add(methodCombo);
            Controls.Add(showLogButton);
            Controls.Add(loadFileButton);
            Controls.Add(scalingFactorNumeric);
            Controls.Add(methodLabel);
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
        private Label methodLabel;
        private ComboBox methodCombo;
        private Panel formPanel;
    }
}
