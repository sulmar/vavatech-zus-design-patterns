namespace TemplateMethodPattern
{
    // Gender - 20% upustu dla kobiet
    public class GenderPercentageOrderCalculator : PercentageOrderCalculatorTemplate
    {
        private readonly Gender gender;
        public GenderPercentageOrderCalculator(Gender gender, decimal percentage)
             : base(percentage)
        {
            this.gender = gender;
        }

        protected override bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }
    }
}
