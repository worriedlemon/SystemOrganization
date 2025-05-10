namespace CablePenentrant.SolutionFinder
{
    public class EvoSolutionFinder : IPlacingSolutionFinder
    {
        List<CablePenentrant2D> cablePensInitial;
        EvoSolutionParametersForm form;
        Random rng;

        public EvoSolutionFinder()
        {
            rng = new();
            cablePensInitial = new();
            form = new();
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

        public Form GetParametersForm() => form;

        public List<CablePenentrant2D> FindSolution(out double criteria)
        {
            int count = cablePensInitial.Count;
            List<List<CablePenentrant2D>> cablePens = new(form.PopulationSize);
            for (int i = 0; i < form.PopulationSize; ++i)
            {
                var cps = new CablePenentrant2D[count];
                int j = 0;
                foreach (var cp in cablePensInitial)
                {
                    cps[j++] = new CablePenentrant2D(cp);
                }
                rng.Shuffle(cps);
                List<CablePenentrant2D> ps = cps.ToList();
                StraightCablePlacement pl = new(ps);
                pl.Init();
                cablePens.Add(ps);
            }
            Program.Log($"Created a random population of size {form.PopulationSize}");

            criteria = -1;

            List<CablePenentrant2D> best = cablePens.First();

            Program.Log($"Initiating genetic algorithm...");
            for (int i = 0; i < form.GenerationsCount; ++i)
            {
                Program.Log($"Generation {i} in process...");
                Crossingover(cablePens);
                Program.Log($"Crossingover complete (population size = {cablePens.Count}).");
                Mutate(cablePens);
                Program.Log($"Mutation complete.");
                Selection(ref cablePens);
                
                var newBest = cablePens.First();
                StraightCablePlacement bestO = new(best), bestN = new(newBest);
                double criteriaO = bestO.GetMinimumRectangle().Length();
                double criteriaN = bestN.GetMinimumRectangle().Length();
                if (criteriaN < criteriaO)
                {
                    criteria = criteriaN;
                    best = newBest;
                }
                else if (criteria == -1)
                {
                    criteria = criteriaO;
                }
                Program.Log($"Selection complete. Best criteria value is {criteria}.");
            }
                
            return best;
        }

        private void Crossingover(List<List<CablePenentrant2D>> cps)
        {
            List<List<CablePenentrant2D>> newCp = new();
            foreach (var cp in cps)
            {
                if (rng.NextDouble() < form.CrossingoverPossibility)
                {
                    int idx = rng.Next(0, cp.Count);
                    var p = cps[idx];
                    StraightCablePlacement s1 = new(cp), s2 = new(p);
                    double diff = s1.GetMinimumRectangle().Length() - s2.GetMinimumRectangle().Length();
                    List<CablePenentrant2D> copyFrom = diff <= 0 ? cp : p, newIndividual = new();
                    foreach (var c in copyFrom)
                    {
                        newIndividual.Add(new CablePenentrant2D(c));
                    }
                    newCp.Add(newIndividual);
                }
            }
            cps.AddRange(newCp);
        }

        private void Mutate(List<List<CablePenentrant2D>> cps)
        {
            foreach (var cp in cps)
            {
                if (rng.NextDouble() < form.MutationPossibility)
                {
                    int i1 = rng.Next(0, cp.Count), i2 = rng.Next(0, cp.Count);
                    (cp[i1], cp[i2]) = (cp[i2], cp[i1]);
                    StraightCablePlacement pl = new(cp);
                    pl.Init();
                }
            }
        }

        private void Selection(ref List<List<CablePenentrant2D>> cps)
        {
            cps.Sort((s1, s2) =>
            {
                StraightCablePlacement cp1 = new(s1), cp2 = new(s2);
                double diff = cp1.GetMinimumRectangle().Length() - cp2.GetMinimumRectangle().Length();
                if (diff == 0) return 0;
                if (diff < 0) return -1;
                else return 1;
            });
            cps = cps.Take(form.PopulationSize).ToList();
        }

        public override string ToString()
        {
            return "Evolution algorithm";
        }
    }
}
