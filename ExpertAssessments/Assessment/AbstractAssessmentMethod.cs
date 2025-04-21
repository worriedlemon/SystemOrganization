namespace ExpertAssessments.Assessment
{
    public abstract class AbstractAssessmentMethod
    {
        public string MethodName { get; private set; }

        protected ExpertAssessment? data;

        public AbstractAssessmentMethod(string methodName)
        {
            MethodName = methodName;
        }

        public void LoadData(ExpertAssessment data)
        {
            this.data = data; 
        }

        public ExpertAssessment GetData()
        {
            if (data is null) throw new ArgumentNullException(nameof(data), "No data loaded");
            return data;
        }

        public abstract void Calculate();

        public override sealed string ToString()
        {
            return MethodName;
        }
    }
}
