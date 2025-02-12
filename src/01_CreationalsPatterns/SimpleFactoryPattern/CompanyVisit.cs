namespace SimpleFactoryPattern
{
    public class CompanyVisit : Visit
    {
        private const decimal companyDiscountPercentage = 0.9m;

        public CompanyVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return (decimal) Duration.TotalHours * PricePerHour * companyDiscountPercentage;
        }
    }
}
