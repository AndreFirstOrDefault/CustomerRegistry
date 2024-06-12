using CustomerRegistry.Domain.Validation;

namespace CustomerRegistry.Domain.Entities;

public sealed class Customer
{
    // 1° passo
    public int CustomerId { get; private set; }
    public string? Name { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Email { get; private set; } 
    public bool IsActive { get; private set; }
    public DateTime LastPaymentDate { get; private set; }
    public DateTime NextPaymentDate { get; private set; }

    public Customer(string name, string phoneNumber, string email, bool isActive, DateTime lastPaymentDate)
    {
        ValidateDomain(name,phoneNumber,email,isActive,lastPaymentDate);        
    }

    public void Update(string name, string phoneNumber, string email, bool isActive, DateTime lastPaymentDate)
    {
        Name = name; 
        PhoneNumber = phoneNumber; 
        Email = email; 
        IsActive = isActive; 
        LastPaymentDate = lastPaymentDate;
    }

    // 2° passo, o construtor com id foi criado apenas para popular a tabela
    public Customer(int id, string name, string phoneNumber, string email, bool isActive, DateTime lastPaymentDate)
    {
        ValidateDomain(id, name, phoneNumber, email, isActive, lastPaymentDate);
        
    }    

    private void ValidateDomain(string name, string phoneNumber, string email, bool isActive, DateTime lastPaymentDate)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
        Name = name;

        DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber), "Invalid phone number. Phone number is required");
        DomainExceptionValidation.When(phoneNumber.Length < 13, "Invalid phone number, too short, minimum 13 characters, ex: (XX)XXXX-XXXX");
        PhoneNumber = phoneNumber;

        DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Invalid email. Email is required");
        DomainExceptionValidation.When(!email.Contains("@outlook.com") && !email.Contains("@gmail.com") && !email.Contains("@yahoo.com") && !email.Contains("@hotmail.com"), "Invalid email.");
        Email = email;

        IsActive = isActive;

        DomainExceptionValidation.When(lastPaymentDate > DateTime.Now, "The date of the last payment cannot be greater than the current date.");
        LastPaymentDate = lastPaymentDate;

        NextPaymentDate = lastPaymentDate.AddMonths(1);
    }

    private void ValidateDomain(int id,string name, string phoneNumber, string email, bool isActive, DateTime lastPaymentDate)
    {
        DomainExceptionValidation.When(id <= 0, "Invalid ID");
        CustomerId = id;

        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
        Name = name;

        DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber), "Invalid phone number. Phone number is required");
        DomainExceptionValidation.When(phoneNumber.Length < 13, "Invalid phone number, too short, minimum 13 characters, ex: (XX)XXXX-XXXX");
        PhoneNumber = phoneNumber;

        DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Invalid email. Email is required");
        DomainExceptionValidation.When(!email.Contains("@outlook.com") && !email.Contains("@gmail.com") && !email.Contains("@yahoo.com") && !email.Contains("@hotmail.com"), "Invalid email.");
        Email = email;

        IsActive = isActive;

        DomainExceptionValidation.When(lastPaymentDate > DateTime.Now, "The date of the last payment cannot be greater than the current date.");
        LastPaymentDate = lastPaymentDate;

        NextPaymentDate = lastPaymentDate.AddMonths(1);
    }

}
