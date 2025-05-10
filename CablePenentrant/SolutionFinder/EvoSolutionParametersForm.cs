namespace CablePenentrant.SolutionFinder
{
    public partial class EvoSolutionParametersForm : Form
    {
        public double GenerationsCount
        {
            get => Convert.ToDouble(generationsCount.Value);
        }

        public int PopulationSize
        {
            get => Convert.ToInt32(populationSize.Value);
        }

        public double MutationPossibility
        {
            get => Convert.ToDouble(mutationPossibility.Value);
        }

        public double CrossingoverPossibility
        {
            get => Convert.ToDouble(crossingoverPossibility.Value);
        }

        public EvoSolutionParametersForm()
        {
            InitializeComponent();
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
        }
    }
}
