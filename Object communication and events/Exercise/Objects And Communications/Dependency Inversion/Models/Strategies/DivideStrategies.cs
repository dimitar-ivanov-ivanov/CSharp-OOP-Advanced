namespace Dependency_Inversion.Models.Strategies
{
    public class DivideStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
