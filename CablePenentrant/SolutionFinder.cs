namespace CablePenentrant
{
    public class SolutionFinder
    {
        public int FailsCount;
        public double ReplaceRatio;
        List<CablePenentrant2D> cablePensInitial;
        public event Action? OnVisualize;

        public SolutionFinder(string path)
        {
            FailsCount = 5;
            ReplaceRatio = 0.33;
            cablePensInitial = new();
            cablePensInitial = CablePenentrantReader.FromFile(path);
            Program.Log("Parsed cable penentrants:");
            foreach (var p in cablePensInitial)
            {
                Program.Log(p.ToString());
            }
        }

        public List<CablePenentrant2D> FindSolution(out double criteriaValue)
        {
            List<CablePenentrant2D> cablePens = new();
            foreach (var cp in cablePensInitial)
            {
                cablePens.Add(new CablePenentrant2D(cp));
            }
            Program.Log("Initializing placement algorithm...");

            CablePlacement placement = new(ref cablePens);
            placement.Init();
            placement.Shrink(true);

            double criteria = placement.GetMinimumRectangle().Length();
            criteriaValue = criteria;
            Program.Log($"Initial placement done!");
            Program.Log($"Criteria value = {criteria}.");
            if (OnVisualize is not null)
            {
                OnVisualize();
                MessageBox.Show("Wait for continue");
            }

            int failsLeft = FailsCount;
            while (failsLeft > 0)
            {
                Program.Log("Rearranging...");

                if (placement.Rearrange(Convert.ToInt32(cablePens.Count * ReplaceRatio), out criteria))
                {
                    Program.Log("Found better solution. Applying it.");
                    failsLeft = FailsCount;
                }
                else
                {
                    Program.Log("Solution rollback, trying again...");
                    --failsLeft;
                }
                Program.Log($"Criteria value = {criteria}.");
                if (criteria < criteriaValue)
                {
                    criteriaValue = criteria;
                }
            }
            Program.Log("Found pseudooptimal solution!\nResult:");
            foreach (var p in cablePens)
            {
                Program.Log(p.ToString());
            }

            return cablePens;
        }
    }
}
