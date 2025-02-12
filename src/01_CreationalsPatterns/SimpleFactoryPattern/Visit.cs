using System;

namespace SimpleFactoryPattern
{
    // Fabryka prosta
    public class VisitFactory
    {
        // Product
        public Visit Create(string visitType, TimeSpan duration, decimal pricePerHour)
        {
            if (visitType == "N")
            {
                return new NfzVisit(duration, pricePerHour);
            }
            else if (visitType == "P")
            {
                return new PrivateVisit(duration, pricePerHour);
            }
            else if (visitType == "F")
            {
                return new CompanyVisit(duration, pricePerHour);
            }
            else if (visitType == "T")
            {
                return new TeleVisit(duration, pricePerHour);
            }
            else
                throw new NotSupportedException();
        }
    }


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

    public class TeleVisit : Visit
    {
        public TeleVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return 100;
        }
    }



    public abstract class Visit
    {
        public DateTime VisitDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }

        public Visit(TimeSpan duration, decimal pricePerHour)
        {
            VisitDate = DateTime.Now;
            Duration = duration;
            PricePerHour = pricePerHour;
        }

        public abstract decimal CalculateCost();        
    }
}
