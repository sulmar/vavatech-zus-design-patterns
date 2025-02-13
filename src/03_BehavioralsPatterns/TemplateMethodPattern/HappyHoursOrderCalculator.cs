using System;

namespace TemplateMethodPattern
{


    // Happy Hours - 10% upustu w godzinach od 9:30 do 15
    public class HappyHoursPercentageOrderCalculator : PercentageOrderCalculatorTemplate
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        public HappyHoursPercentageOrderCalculator(TimeSpan from, TimeSpan to, decimal percentage)
             :base(percentage) 
        {
            this.from = from;
            this.to = to;
        }

        protected override bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from && order.OrderDate.TimeOfDay < to;
        }
    }

}
