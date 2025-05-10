namespace CablePenentrant.SolutionFinder
{
    public partial class CommonSolutionParametersForm : Form
    {
        public int FailsCount
        {
            get => Convert.ToInt32(tryCountNumeric.Value);
        }

        public double ReplaceRate
        {
            get => Convert.ToDouble(replaceRatio.Value);
        }

        public CommonSolutionParametersForm(int attemps, double rate)
        {
            InitializeComponent();
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            tryCountNumeric.Value = attemps;
            replaceRatio.Value = Convert.ToDecimal(rate);
        }
    }
}
