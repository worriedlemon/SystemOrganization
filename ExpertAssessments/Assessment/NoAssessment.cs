namespace ExpertAssessments.Assessment
{
    public class NoAssessment : AbstractAssessmentMethod
    {
        public NoAssessment() : base("None") { }

        public override void Calculate()
        {
            throw new InvalidOperationException("No assessment method");
        }
    }
}
