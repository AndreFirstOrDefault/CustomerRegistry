using CustomerRegistry.Domain.Entities;
using FluentAssertions;

namespace CustomerRegistry.Domain.Tests;

public class CustomerUnitTest1
{
    // Sucesso
    [Fact]
    public void CreateCustomer_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Customer (1,"Andre",
            "(11)5677-9338","andre@hotmail.com",true,"Monthly",DateTime.Now );
        action.Should().NotThrow<Validation.DomainExceptionValidation>();
    }

    // Id <= 0
    [Fact]
    public void CreateCustomer_NegativeOrZeroIdValue_DomainExceptioninvalidId()
    {
        Action action = () => new Customer(0,"André","+551156779338","andre@gmail.com",true,"Bimonthly",DateTime.Now );
        action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid Id value.");
    }

    // Nome = "" ou null
    [Fact]
    public void CreateCustomer_NullOrEmptyName_DomainExceptionInvalidName()
    {
        Action action = () => new Customer(1, "",
             "(11)5677-9338", "andre@hotmail.com", true,"Quarterly", DateTime.Now);
        action.Should().Throw<Validation.DomainExceptionValidation>("Invalid name. Name is required");
    }

    // Nome < 3 caracteres
    [Fact]
    public void CreateCustomer_InvalidName_DomainExceptionNameTooShort()
    {
        Action action = () => new Customer(1, "An",
             "(11)5677-9338", "andre@hotmail.com", true, "Semiannual", DateTime.Now);
        action.Should().Throw<Validation.DomainExceptionValidation>("Invalid name, too short, minimum 3 characters");
    }

    // Telefone = "" ou null
    [Fact]
    public void CreateCustomer_NullOrEmptyPhoneNumber_DomainExceptionInvalidPhoneNumber()
    {
        Action action = () => new Customer(1, "André",
             "", "andre@hotmail.com", true, "Annual",DateTime.Now);
        action.Should().Throw<Validation.DomainExceptionValidation>("Invalid phone number. Phone number is required");
    }

    // Telefone < 13 caracteres
    [Fact]
    public void CreateCustomer_InvalidPhoneNumber_DomainExceptionInvalidPhoneNumberTooSort()
    {
        Action action = () => new Customer(1,"Andre","5566","andre@gmail.com",false, "Bimonthly", DateTime.Now);
        action.Should().Throw<Validation.DomainExceptionValidation>("Invalid phone number, too short, minimum 13 characters, ex: (XX)XXXX-XXXX");
    }

    // Email = "" ou null
    [Fact]
    public void CreateCustomer_NullOrEmail_DomainExceptionInvalidEmail()
    {
        Action action = () => new Customer(1, "André",
             "", "", true, "Monthly",DateTime.Now);
        action.Should().Throw<Validation.DomainExceptionValidation>("Invalid email. Email is required");
    }

    // Email não contem: "@outlook.com", "@gmail.com", "@yahoo.com", "@hotmail.com"
    [Fact]
    public void CreateCustomer_InvalidEmail_DomainExceptionInvalidEmail()
    {
        Action action = () => new Customer(1, "André",
             "", "andre.com", true, "Annual", DateTime.Now);
        action.Should().Throw<Validation.DomainExceptionValidation>("Invalid email.");
    }

    // Data do ultimo pagamento > Data Atual
    [Fact]
    public void CreateCustomer_InvalidLastPaymentDate_DomainExceptionInvalidLastPayment()
    {
        Action action = () => new Customer(1, "André", "+551156779338", "andre@gmail.com", true,"Bimonthly", DateTime.Now.AddDays(1));
        action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid date. The date of the last payment cannot be greater than the current date.");
    }

    // O plano é passado como "" ou null
    [Fact]
    public void CreateCustomer_InvalidPlan_DomainExceptionInvalidPlan()
    {
        Action action = () => new Customer(1, "André", "+551155555555", "andre@gmail.com", true, "", DateTime.Now);
        action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid plan. The plan is required.");
    }

    [Fact]
    public void CreateCustomer_PlanNotExist_DomainExceptionPlanNotExist()
    {
        Action action = () => new Customer(1, "André", "+551156565656", "andre@gmail.com", false, "Mont", DateTime.Now);
        action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid plan, this plan does not exist at the moment.");

    }
}
