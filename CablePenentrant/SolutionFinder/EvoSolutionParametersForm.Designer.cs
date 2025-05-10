namespace CablePenentrant.SolutionFinder
{
    partial class EvoSolutionParametersForm
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
            populationLabel = new Label();
            populationSize = new NumericUpDown();
            mutationLabel = new Label();
            mutationPossibility = new NumericUpDown();
            generationsLabel = new Label();
            generationsCount = new NumericUpDown();
            crossingoverLabel = new Label();
            crossingoverPossibility = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)populationSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mutationPossibility).BeginInit();
            ((System.ComponentModel.ISupportInitialize)generationsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)crossingoverPossibility).BeginInit();
            SuspendLayout();
            // 
            // populationLabel
            // 
            populationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            populationLabel.AutoSize = true;
            populationLabel.Location = new Point(12, 9);
            populationLabel.Name = "populationLabel";
            populationLabel.Size = new Size(114, 20);
            populationLabel.TabIndex = 0;
            populationLabel.Text = "Population Size:";
            // 
            // populationSize
            // 
            populationSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            populationSize.Location = new Point(12, 32);
            populationSize.Maximum = new decimal(new int[] { 2147000000, 0, 0, 0 });
            populationSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            populationSize.Name = "populationSize";
            populationSize.Size = new Size(185, 27);
            populationSize.TabIndex = 1;
            populationSize.ThousandsSeparator = true;
            populationSize.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // mutationLabel
            // 
            mutationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mutationLabel.AutoSize = true;
            mutationLabel.Location = new Point(12, 62);
            mutationLabel.Name = "mutationLabel";
            mutationLabel.Size = new Size(141, 20);
            mutationLabel.TabIndex = 0;
            mutationLabel.Text = "Mutation Possibility:";
            // 
            // mutationPossibility
            // 
            mutationPossibility.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mutationPossibility.DecimalPlaces = 2;
            mutationPossibility.Location = new Point(12, 85);
            mutationPossibility.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            mutationPossibility.Name = "mutationPossibility";
            mutationPossibility.Size = new Size(185, 27);
            mutationPossibility.TabIndex = 1;
            mutationPossibility.Value = new decimal(new int[] { 33, 0, 0, 131072 });
            // 
            // generationsLabel
            // 
            generationsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            generationsLabel.AutoSize = true;
            generationsLabel.Location = new Point(12, 115);
            generationsLabel.Name = "generationsLabel";
            generationsLabel.Size = new Size(134, 20);
            generationsLabel.TabIndex = 0;
            generationsLabel.Text = "Generations Count:";
            // 
            // generationsCount
            // 
            generationsCount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            generationsCount.Location = new Point(12, 138);
            generationsCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            generationsCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            generationsCount.Name = "generationsCount";
            generationsCount.Size = new Size(185, 27);
            generationsCount.TabIndex = 1;
            generationsCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // crossingoverLabel
            // 
            crossingoverLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            crossingoverLabel.AutoSize = true;
            crossingoverLabel.Location = new Point(12, 168);
            crossingoverLabel.Name = "crossingoverLabel";
            crossingoverLabel.Size = new Size(172, 20);
            crossingoverLabel.TabIndex = 0;
            crossingoverLabel.Text = "Crosssingover Possibility:";
            // 
            // crossingoverPossibility
            // 
            crossingoverPossibility.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            crossingoverPossibility.DecimalPlaces = 2;
            crossingoverPossibility.Location = new Point(12, 191);
            crossingoverPossibility.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            crossingoverPossibility.Name = "crossingoverPossibility";
            crossingoverPossibility.Size = new Size(185, 27);
            crossingoverPossibility.TabIndex = 1;
            crossingoverPossibility.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // EvoSolutionParametersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(209, 227);
            Controls.Add(crossingoverPossibility);
            Controls.Add(generationsCount);
            Controls.Add(mutationPossibility);
            Controls.Add(populationSize);
            Controls.Add(crossingoverLabel);
            Controls.Add(generationsLabel);
            Controls.Add(mutationLabel);
            Controls.Add(populationLabel);
            Name = "EvoSolutionParametersForm";
            Text = "Parameters";
            ((System.ComponentModel.ISupportInitialize)populationSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)mutationPossibility).EndInit();
            ((System.ComponentModel.ISupportInitialize)generationsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)crossingoverPossibility).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label populationLabel;
        private NumericUpDown populationSize;
        private Label mutationLabel;
        private NumericUpDown mutationPossibility;
        private Label generationsLabel;
        private NumericUpDown generationsCount;
        private Label crossingoverLabel;
        private NumericUpDown crossingoverPossibility;
    }
}