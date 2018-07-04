namespace Dependency_Inversion.Models.Strategies
{
    public class MultiplyStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
