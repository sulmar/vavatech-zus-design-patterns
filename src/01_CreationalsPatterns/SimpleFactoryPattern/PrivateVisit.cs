namespace SimpleFactoryPattern
{
    public class PrivateVisit : Visit
    {
        public PrivateVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return (decimal) Duration.TotalHours * PricePerHour;
        }
    }
}
