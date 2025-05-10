namespace CablePenentrant.SolutionFinder
{
    partial class CommonSolutionParametersForm
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
            replacementRatioLabel = new Label();
            tryCountNumeric = new NumericUpDown();
            tryCountLabel = new Label();
            replaceRatio = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)tryCountNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)replaceRatio).BeginInit();
            SuspendLayout();
            // 
            // replacementRatioLabel
            // 
            replacementRatioLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            replacementRatioLabel.AutoSize = true;
            replacementRatioLabel.Location = new Point(12, 83);
            replacementRatioLabel.Name = "replacementRatioLabel";
            replacementRatioLabel.Size = new Size(96, 40);
            replacementRatioLabel.TabIndex = 4;
            replacementRatioLabel.Text = "Replacement\r\nratio:";
            // 
            // tryCountNumeric
            // 
            tryCountNumeric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tryCountNumeric.Location = new Point(12, 35);
            tryCountNumeric.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            tryCountNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            tryCountNumeric.Name = "tryCountNumeric";
            tryCountNumeric.Size = new Size(159, 27);
            tryCountNumeric.TabIndex = 6;
            tryCountNumeric.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // tryCountLabel
            // 
            tryCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tryCountLabel.AutoSize = true;
            tryCountLabel.Location = new Point(12, 12);
            tryCountLabel.Name = "tryCountLabel";
            tryCountLabel.Size = new Size(72, 20);
            tryCountLabel.TabIndex = 5;
            tryCountLabel.Text = "Try count:";
            // 
            // replaceRatio
            // 
            replaceRatio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            replaceRatio.DecimalPlaces = 2;
            replaceRatio.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            replaceRatio.Location = new Point(12, 126);
            replaceRatio.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            replaceRatio.Name = "replaceRatio";
            replaceRatio.Size = new Size(159, 27);
            replaceRatio.TabIndex = 7;
            replaceRatio.Value = new decimal(new int[] { 33, 0, 0, 131072 });
            // 
            // CommonSolutionParametersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(183, 170);
            Controls.Add(replacementRatioLabel);
            Controls.Add(tryCountNumeric);
            Controls.Add(tryCountLabel);
            Controls.Add(replaceRatio);
            Name = "CommonSolutionParametersForm";
            Text = "Parameters";
            ((System.ComponentModel.ISupportInitialize)tryCountNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)replaceRatio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label replacementRatioLabel;
        private NumericUpDown tryCountNumeric;
        private Label tryCountLabel;
        private NumericUpDown replaceRatio;
    }
}