namespace Dependency_Inversion.Models.Strategies
{
    public class AdditionStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
