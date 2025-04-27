namespace ExpertAssessments
{
    partial class AssessmentsForm
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
            methodLabel = new Label();
            methodCombo = new ComboBox();
            startButton = new Button();
            loadFileButton = new Button();
            assessmentsLabel = new Label();
            ofd = new OpenFileDialog();
            headersCheck = new CheckBox();
            assessmentsData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)assessmentsData).BeginInit();
            SuspendLayout();
            // 
            // methodLabel
            // 
            methodLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            methodLabel.AutoSize = true;
            methodLabel.Location = new Point(607, 9);
            methodLabel.Name = "methodLabel";
            methodLabel.Size = new Size(144, 20);
            methodLabel.TabIndex = 0;
            methodLabel.Text = "Assessment method:";
            // 
            // methodCombo
            // 
            methodCombo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            methodCombo.FormattingEnabled = true;
            methodCombo.Location = new Point(607, 32);
            methodCombo.Name = "methodCombo";
            methodCombo.Size = new Size(181, 28);
            methodCombo.TabIndex = 1;
            methodCombo.SelectedIndexChanged += OnSelectedIndexChange;
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            startButton.Location = new Point(607, 372);
            startButton.Name = "startButton";
            startButton.Size = new Size(181, 66);
            startButton.TabIndex = 2;
            startButton.Text = "Calculate";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += OnCalculateClick;
            // 
            // loadFileButton
            // 
            loadFileButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            loadFileButton.Location = new Point(607, 326);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(181, 40);
            loadFileButton.TabIndex = 2;
            loadFileButton.Text = "Load File";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += OnLoadClick;
            // 
            // assessmentsLabel
            // 
            assessmentsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            assessmentsLabel.AutoSize = true;
            assessmentsLabel.Location = new Point(12, 9);
            assessmentsLabel.Name = "assessmentsLabel";
            assessmentsLabel.Size = new Size(94, 20);
            assessmentsLabel.TabIndex = 3;
            assessmentsLabel.Text = "Assessments:";
            // 
            // ofd
            // 
            ofd.Filter = "CSV Table|*.csv";
            // 
            // headersCheck
            // 
            headersCheck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            headersCheck.AutoSize = true;
            headersCheck.Checked = true;
            headersCheck.CheckState = CheckState.Checked;
            headersCheck.Location = new Point(607, 84);
            headersCheck.Name = "headersCheck";
            headersCheck.Size = new Size(141, 24);
            headersCheck.TabIndex = 5;
            headersCheck.Text = "Contains Header";
            headersCheck.UseVisualStyleBackColor = true;
            // 
            // assessmentsData
            // 
            assessmentsData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            assessmentsData.BackgroundColor = SystemColors.ControlLightLight;
            assessmentsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            assessmentsData.Location = new Point(12, 32);
            assessmentsData.MultiSelect = false;
            assessmentsData.Name = "assessmentsData";
            assessmentsData.RowHeadersWidth = 51;
            assessmentsData.Size = new Size(589, 406);
            assessmentsData.TabIndex = 6;
            // 
            // AssessmentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(assessmentsData);
            Controls.Add(headersCheck);
            Controls.Add(assessmentsLabel);
            Controls.Add(loadFileButton);
            Controls.Add(startButton);
            Controls.Add(methodCombo);
            Controls.Add(methodLabel);
            Name = "AssessmentsForm";
            Text = "Assessments";
            ((System.ComponentModel.ISupportInitialize)assessmentsData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label methodLabel;
        private ComboBox methodCombo;
        private Button startButton;
        private Button loadFileButton;
        private Label assessmentsLabel;
        private OpenFileDialog ofd;
        private CheckBox headersCheck;
        private DataGridView assessmentsData;
    }
}
