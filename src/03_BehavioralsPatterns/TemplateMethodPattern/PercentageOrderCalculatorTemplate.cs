namespace TemplateMethodPattern
{
    // Template Method

    public abstract class PercentageOrderCalculatorTemplate
    {
        private readonly decimal percentage;
        
        protected abstract bool CanDiscount(Order order);

        protected virtual decimal Discount(Order order)
        {
            return order.Amount* percentage;
        }

        protected PercentageOrderCalculatorTemplate(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (CanDiscount(order))
            {
                return Discount(order);
            }
            else
                return 0;
        }
    }

}
