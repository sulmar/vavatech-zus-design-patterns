using System;

namespace StrategyPattern;

public class ShoppingCart
{
    private double _price;
   
    public DateTime OrderDate { get; set; }

    public ShoppingCart(double price)
    {
        _price = price;
    }

    public ICanDiscountStrategy CanDiscountStrategy { get; set; }
    public IDiscountStrategy DiscountStrategy { get; set; }


    // Obliczanie ceny na podstawie zniżki
    public double CalculateTotalPrice()
    {        
        if (CanDiscountStrategy.CanDiscount(this))
        {
            return _price - DiscountStrategy.Discount(_price);
        }       
        else
        {
            // No Discount
            return _price; // Brak zniżki
        }
    }
}