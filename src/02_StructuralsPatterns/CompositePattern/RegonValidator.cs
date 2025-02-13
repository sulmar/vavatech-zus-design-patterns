namespace CompositePattern;

public class RegonValidator : ICustomerValidator
{
    public bool Validate(Customer customer)
    {
        return customer.Regon.Length == 9;
    }
}


public class CompositeCustomerValidator : ICustomerValidator
{
    private readonly List<ICustomerValidator> validators = [];

    public bool Validate(Customer customer)
    {
        return validators.All(x => x.Validate(customer));
    }

    public void Add(ICustomerValidator validator)
    {
        validators.Add(validator);
    }
}

