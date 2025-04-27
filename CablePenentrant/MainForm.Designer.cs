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
            tryCountLabel = new Label();
            tryCountNumeric = new NumericUpDown();
            replacementRatioLabel = new Label();
            replaceRatio = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scalingFactorNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tryCountNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)replaceRatio).BeginInit();
            SuspendLayout();
            // 
            // picture
            // 
            picture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picture.BackColor = Color.White;
            picture.BorderStyle = BorderStyle.FixedSingle;
            picture.Location = new Point(12, 12);
            picture.Name = "picture";
            picture.Size = new Size(568, 494);
            picture.TabIndex = 0;
            picture.TabStop = false;
            // 
            // refresh
            // 
            refresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refresh.Enabled = false;
            refresh.Location = new Point(588, 447);
            refresh.Name = "refresh";
            refresh.Size = new Size(145, 59);
            refresh.TabIndex = 1;
            refresh.Text = "Refresh";
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += OnRefreshClick;
            // 
            // label
            // 
            label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label.AutoSize = true;
            label.Location = new Point(588, 12);
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
            scalingFactorNumeric.Location = new Point(588, 35);
            scalingFactorNumeric.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            scalingFactorNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            scalingFactorNumeric.Name = "scalingFactorNumeric";
            scalingFactorNumeric.Size = new Size(145, 27);
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
            loadFileButton.Location = new Point(588, 382);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(145, 59);
            loadFileButton.TabIndex = 4;
            loadFileButton.Text = "Load File";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += OnLoadClick;
            // 
            // showLogButton
            // 
            showLogButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            showLogButton.Location = new Point(12, 512);
            showLogButton.Name = "showLogButton";
            showLogButton.Size = new Size(119, 29);
            showLogButton.TabIndex = 5;
            showLogButton.Text = "Show Log";
            showLogButton.UseVisualStyleBackColor = true;
            showLogButton.Click += OnShowLogClick;
            // 
            // tryCountLabel
            // 
            tryCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tryCountLabel.AutoSize = true;
            tryCountLabel.Location = new Point(588, 92);
            tryCountLabel.Name = "tryCountLabel";
            tryCountLabel.Size = new Size(72, 20);
            tryCountLabel.TabIndex = 2;
            tryCountLabel.Text = "Try count:";
            // 
            // tryCountNumeric
            // 
            tryCountNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tryCountNumeric.Location = new Point(588, 115);
            tryCountNumeric.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            tryCountNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            tryCountNumeric.Name = "tryCountNumeric";
            tryCountNumeric.Size = new Size(145, 27);
            tryCountNumeric.TabIndex = 3;
            tryCountNumeric.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // replacementRatioLabel
            // 
            replacementRatioLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            replacementRatioLabel.AutoSize = true;
            replacementRatioLabel.Location = new Point(588, 163);
            replacementRatioLabel.Name = "replacementRatioLabel";
            replacementRatioLabel.Size = new Size(96, 40);
            replacementRatioLabel.TabIndex = 2;
            replacementRatioLabel.Text = "Replacement\r\nratio:";
            // 
            // replaceRatio
            // 
            replaceRatio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            replaceRatio.DecimalPlaces = 2;
            replaceRatio.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            replaceRatio.Location = new Point(588, 206);
            replaceRatio.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            replaceRatio.Name = "replaceRatio";
            replaceRatio.Size = new Size(145, 27);
            replaceRatio.TabIndex = 3;
            replaceRatio.Value = new decimal(new int[] { 33, 0, 0, 131072 });
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 551);
            Controls.Add(showLogButton);
            Controls.Add(loadFileButton);
            Controls.Add(replacementRatioLabel);
            Controls.Add(tryCountNumeric);
            Controls.Add(tryCountLabel);
            Controls.Add(replaceRatio);
            Controls.Add(scalingFactorNumeric);
            Controls.Add(label);
            Controls.Add(refresh);
            Controls.Add(picture);
            Name = "MainForm";
            Text = "Visualization";
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ((System.ComponentModel.ISupportInitialize)scalingFactorNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)tryCountNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)replaceRatio).EndInit();
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
        private Label tryCountLabel;
        private NumericUpDown tryCountNumeric;
        private Label replacementRatioLabel;
        private NumericUpDown replaceRatio;
    }
}
