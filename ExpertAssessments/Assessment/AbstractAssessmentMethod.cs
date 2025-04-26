namespace ExpertAssessments.Assessment
{
    public abstract class AbstractAssessmentMethod
    {
        public abstract string MethodName { get; }

        protected int expertsCount, objectsCount;

        public AbstractAssessmentMethod() { }

        public virtual void LoadData(string path) { }

        public abstract double[] Calculate();

        public override sealed string ToString()
        {
            return MethodName;
        }
    }
}
