namespace SimpleFactoryPattern
{
    public class NfzVisit : Visit
    {
        public NfzVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return 0;
        }
    }
}
