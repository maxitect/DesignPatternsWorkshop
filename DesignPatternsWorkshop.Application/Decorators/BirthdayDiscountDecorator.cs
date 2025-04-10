using DesignPatternsWorkshop.Application.Strategies;

namespace DesignPatternsWorkshop.Application.Decorators;

public class BirthdayDiscountDecorator : IDiscountStrategy
{
    public string Name { get; set; } = "Birthday discount";
    private readonly IDiscountStrategy _baseStrategy;
    private readonly DateTime _birthday;
    
    public BirthdayDiscountDecorator(IDiscountStrategy baseStrategy, DateTime birthday)
    {
        _baseStrategy = baseStrategy;
        _birthday = birthday;
    }
    
    public double ApplyDiscount(double discount)
    {
        if (IsBirthday())
        {
            return _baseStrategy.ApplyDiscount(discount);
        }
        
        return 0;
    }
    
    private bool IsBirthday()
    {
        DateTime today = DateTime.Today;
        return today.Month == _birthday.Month && today.Day == _birthday.Day;
    }
}