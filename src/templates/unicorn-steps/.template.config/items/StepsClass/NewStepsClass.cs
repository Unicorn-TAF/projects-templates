using Company.StepsInjection;
using Unicorn.Taf.Core.Steps.Attributes;

namespace Company.Steps
{
    [StepsClass]
    public class NewStepsClass
    {
        [Step("<step-description-with-parameter-'{0}'>")]
        public void Step1(string someParameter)
        {
        }
    }
}
