using Moq;

namespace CompositePattern.UnitTests;

public class CustomerControllerTests
{
    [Fact]
    public void Post_WhenTaxNumberIsValid_ShoudReturnsCreatedResult()
    {
        // Arrange
        ICustomerValidator validator = new TaxNumberValidator();
        CustomerController controller = new CustomerController(validator);

        // Act
        var result = controller.Post(new Customer { TaxNumber = "01234567891" });

        // Assert
        Assert.IsType<CreatedResult>(result);
    }

    [Fact]
    public void Post_WhenTaxNumberIsInvalid_ShoudReturnsBadRequestObjectResult()
    {
        // Arrange
        ICustomerValidator validator = new TaxNumberValidator();
        CustomerController controller = new CustomerController(validator);

        // Act
        var result = controller.Post(new Customer { TaxNumber = "1" });

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }


    [Fact]
    public void Post_WhenTaxNumberAndRegonIsValid_ShoudReturnsCreatedResult()
    {
        // Arrange
        ICustomerValidator taxNumberValidator = new TaxNumberValidator();
        ICustomerValidator regonValidator = new RegonValidator();
        CompositeCustomerValidator compositeValidator = new CompositeCustomerValidator();
        compositeValidator.Add(taxNumberValidator);
        compositeValidator.Add(regonValidator);

        CustomerController controller = new CustomerController(compositeValidator);

        // Act
        var result = controller.Post(new Customer { TaxNumber = "01234567891", Regon = "123456789" });

        // Assert
        Assert.IsType<CreatedResult>(result);
    }

    [Fact]
    public void Post_WhenTaxNumberIsInvalidAndRegonIsValid_ShoudReturnsBadRequestObjectResult()
    {
        // Arrange
        ICustomerValidator taxNumberValidator = new TaxNumberValidator();
        ICustomerValidator regonValidator = new RegonValidator();
        CompositeCustomerValidator compositeValidator = new CompositeCustomerValidator();
        compositeValidator.Add(taxNumberValidator);
        compositeValidator.Add(regonValidator);

        CustomerController controller = new CustomerController(compositeValidator);

        // Act
        var result = controller.Post(new Customer { TaxNumber = "1", Regon = "123456789" });

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}