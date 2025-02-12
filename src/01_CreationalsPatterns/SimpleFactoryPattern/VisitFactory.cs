namespace SimpleFactoryPattern
{
    // Fabryka prosta
    public class VisitFactory
    {
        // Product
        public Visit Create(string visitType, TimeSpan duration, decimal pricePerHour) => visitType switch
        {
            "N" => new NfzVisit(duration, pricePerHour),
            "P" => new PrivateVisit(duration, pricePerHour),
            "F" => new CompanyVisit(duration, pricePerHour),
            "T" => new TeleVisit(duration, pricePerHour),
            _ => throw new NotSupportedException(),
        };
    }
}
