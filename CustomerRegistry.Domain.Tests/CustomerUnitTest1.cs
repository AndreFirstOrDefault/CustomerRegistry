using CustomerRegistry.Domain.Entities;
using FluentAssertions;

namespace CustomerRegistry.Domain.Tests;

public class CustomerUnitTest1
{
    [Fact]
    public void CreateCustomer_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Customer (1,"Andre",
            "(11)5677-9338","andre@hotmail.com",true,DateTime.Now );
        action.Should().NotThrow<Validation.DomainExceptionValidation>();
    }


}
