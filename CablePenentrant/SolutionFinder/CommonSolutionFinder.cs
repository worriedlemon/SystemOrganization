namespace CablePenentrant.SolutionFinder
{
    public class CommonSolutionFinder : IPlacingSolutionFinder
    {
        List<CablePenentrant2D> cablePensInitial;
        int failsCount;
        double replaceRate;
        CommonSolutionParametersForm? form;

        public CommonSolutionFinder(bool form = true)
        {
            cablePensInitial = new();
            failsCount = 5;
            replaceRate = 0.33;
            if (form)
            {
                this.form = new(failsCount, replaceRate);
            }
        }

        public void Load(string path)
        {
            cablePensInitial = CablePenentrantReader.FromFile(path);
            Program.Log("Parsed cable penentrants:");
            foreach (var p in cablePensInitial)
            {
                Program.Log(p.ToString());
            }
        }

        public List<CablePenentrant2D> FindSolution(out double criteriaValue)
        {
            if (form is not null)
            {
                failsCount = form.FailsCount;
                replaceRate = form.ReplaceRate;
            }

            List<CablePenentrant2D> cablePens = new();
            foreach (var cp in cablePensInitial)
            {
                cablePens.Add(new CablePenentrant2D(cp));
            }
            Program.Log("Initializing placement algorithm...");

            CablePlacement placement = new(cablePens);
            placement.Init();

            double criteria = placement.GetMinimumRectangle().Length();
            criteriaValue = criteria;
            Program.Log($"Initial placement done!");
            Program.Log($"Criteria value = {criteria}.");

            int failsLeft = failsCount;
            while (failsLeft > 0)
            {
                Program.Log("Rearranging...");

                if (placement.Rearrange(Convert.ToInt32(cablePens.Count * replaceRate), out criteria))
                {
                    Program.Log("Found better solution. Applying it.");
                    failsLeft = failsCount;
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

        public Form GetParametersForm() => form!;

        public void BindParameters(int failsCount, double replaceRate)
        {
            this.failsCount = failsCount;
            this.replaceRate = replaceRate;
        }

        public override string ToString()
        {
            return "Common Euristic Method";
        }
    }
}
