namespace Dependency_Inversion.Models.Strategies
{
    public class SubtractionStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}