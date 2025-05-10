namespace CablePenentrant.SolutionFinder
{

    public interface IPlacingSolutionFinder
    {
        public List<CablePenentrant2D> FindSolution(out double criteriaValue);
        public Form GetParametersForm();
        public void Load(string path);
    }
}
