namespace Dependency_Inversion.Models
{
    using Dependency_Inversion.Models.Strategies;

    public class PrimitiveCalculator
    {
        private char @operator;

        private AdditionStrategy additionStrategy;
        private SubtractionStrategy subtractionStrategy;
        private MultiplyStrategy multiplyStrategy;
        private DivideStrategy divideStrategy;

        public PrimitiveCalculator()
        {
            this.additionStrategy = new AdditionStrategy();
            this.subtractionStrategy = new SubtractionStrategy();
            this.multiplyStrategy = new MultiplyStrategy();
            this.divideStrategy = new DivideStrategy();
            this.@operator = '+';
        }

        public void changeStrategy(char @operator)
        {
            this.@operator = @operator;
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            if (@operator == '+')
            {
                return additionStrategy.Calculate(firstOperand, secondOperand);
            }
            else if (@operator == '-')
            {
                return subtractionStrategy.Calculate(firstOperand, secondOperand);
            }
            else if (@operator == '*')
            {
                return this.multiplyStrategy.Calculate(firstOperand, secondOperand);
            }

            return this.divideStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}