using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    // Abstract Strategy
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(ShoppingCart cart);
    }

    public interface IDiscountStrategy
    {
        double Discount(double price);
    }

    // Concrete Strategy A
    public class PercentageDiscountStrategy(double percentage) : IDiscountStrategy
    {
        public double Discount(double price) => price * percentage;
    }

    // Concrete Strategy B
    public class FixedDiscountStrategy(double fixedAmount) : IDiscountStrategy
    {
        public double Discount(double price) => fixedAmount;
    }

    // Concrete Strategy
    public class HappyHoursCanDiscountStrategy : ICanDiscountStrategy
    {
        TimeSpan from;
        TimeSpan to;

        public HappyHoursCanDiscountStrategy(TimeSpan from, TimeSpan to)
        {
            this.from = from;
            this.to = to;
        }

        public bool CanDiscount(ShoppingCart cart)
        {
            return cart.OrderDate.TimeOfDay >= from && cart.OrderDate.TimeOfDay <= to;
        }
    }


    public class BlackFridayCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly DateTime specialDate;

        public BlackFridayCanDiscountStrategy(DateTime specialDate)
        {
            this.specialDate = specialDate;
        }

        public bool CanDiscount(ShoppingCart cart)
        {
            return cart.OrderDate == specialDate;
        }
    }

}
