using CustomerRegistry.Domain.Enums;
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
    public string? Plan { get; private set; }
    public decimal PlanPrice{ get; private set; }
    public SubscriptionPlan SubscriPlan { get; private set; }
    public DateTime LastPaymentDate { get; private set; }
    public DateTime NextPaymentDate { get; private set; }

    public Customer(string name, string phoneNumber, string email, bool isActive, string plan, decimal planPrice,DateTime lastPaymentDate)
    {
        ValidateDomain(name, phoneNumber, email, isActive,plan, planPrice,lastPaymentDate);
    }

    public void Update(string? name, string phoneNumber, string email, bool isActive, string plan,decimal planPrice, DateTime lastPaymentDate)
    {
        Name = name; 
        PhoneNumber = phoneNumber; 
        Email = email; 
        IsActive = isActive;
        Plan = plan;
        PlanPrice = planPrice;
        LastPaymentDate = lastPaymentDate;
        
    }

    // 2° passo, o construtor com id foi criado apenas para popular a tabela
    public Customer(int id, string name, string phoneNumber, string email, bool isActive, string plan, decimal planPrice, DateTime lastPaymentDate)
    {
        ValidateDomain(id, name, phoneNumber, email, isActive, plan, planPrice, lastPaymentDate);
        
    }

    private void ValidateDomain(string name, string phoneNumber, string email, bool isActive, string plan, decimal planPrice, DateTime lastPaymentDate)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
        Name = name;

        DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber), "Invalid phone number. Phone number is required");
        DomainExceptionValidation.When(phoneNumber.Length < 13, "Invalid phone number, too short, minimum 13 characters, ex: (XX)XXXX-XXXX");
        PhoneNumber = phoneNumber;

        if (string.IsNullOrEmpty(email))
        {
            Email = email;
        }
        else
        {
            DomainExceptionValidation.When(!email.Contains("@outlook.com") && !email.Contains("@gmail.com") && !email.Contains("@yahoo.com") && !email.Contains("@hotmail.com"), "Invalid email.");
            Email = email;
        }

        IsActive = isActive;

        DomainExceptionValidation.When(string.IsNullOrEmpty(plan), "Invalid plan. The plan is required.");
        DomainExceptionValidation.When(plan != "Monthly" && plan != "Bimonthly" && plan != "Quarterly" && plan != "Semiannual" && plan != "Annual", "Invalid plan, this plan does not exist at the moment.");
        SubscriPlan = Enum.Parse<SubscriptionPlan>(plan);
        Plan = plan;

        int months = 0;

        if (isActive)
        {
            if (plan == "Monthly")
            {
                months = 1;
            }
            else if (plan == "Bimonthly")
            {
                months = 2;
            }
            else if (plan == "Quarterly")
            {
                months = 3;
            }
            else if (plan == "Semiannual")
            {
                months = 6;
            }
            else
            {
                months = 12;
            }


        }

        DomainExceptionValidation.When(planPrice < 15m, "The plan value is invalid. The provided value is too low.");
        DomainExceptionValidation.When(planPrice >= 500m, "The plan value is invalid. The provided value is too high.");
        PlanPrice = planPrice;

        DomainExceptionValidation.When(lastPaymentDate > DateTime.Now, "The date of the last payment cannot be greater than the current date.");
        LastPaymentDate = lastPaymentDate;

        NextPaymentDate = lastPaymentDate.AddMonths(months);
    }

    private void ValidateDomain(int id,string name, string phoneNumber, string email, bool isActive, string plan, decimal planPrice, DateTime lastPaymentDate)
    {
        DomainExceptionValidation.When(id <= 0, "Invalid Id value.");
        CustomerId = id;

        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
        Name = name;

        DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber), "Invalid phone number. Phone number is required");
        DomainExceptionValidation.When(phoneNumber.Length < 13, "Invalid phone number, too short, minimum 13 characters, ex: (XX)XXXX-XXXX");
        PhoneNumber = phoneNumber;

        if(!string.IsNullOrEmpty(email))
        {
            Email = email;
        }
        else
        {
            DomainExceptionValidation.When(!email.Contains("@outlook.com") && !email.Contains("@gmail.com") && !email.Contains("@yahoo.com") && !email.Contains("@hotmail.com"), "Invalid email.");
            Email = email;
        }

        IsActive = isActive;
        
        DomainExceptionValidation.When(lastPaymentDate > DateTime.Now, "Invalid date. The date of the last payment cannot be greater than the current date.");
        LastPaymentDate = lastPaymentDate;

        DomainExceptionValidation.When(string.IsNullOrEmpty(plan), "Invalid plan. The plan is required.");
        DomainExceptionValidation.When(plan != "Monthly" && plan != "Bimonthly" && plan != "Quarterly" && plan != "Semiannual" && plan != "Annual", "Invalid plan, this plan does not exist at the moment.");
        SubscriPlan = Enum.Parse<SubscriptionPlan>(plan);
        Plan = plan;

        int months = 0;

        if (isActive)
        {
            if (plan == "Monthly")
            {
                months = 1;
            }
            else if (plan == "Bimonthly")
            {
                months = 2;
            }
            else if (plan == "Quarterly")
            {
                months = 3;
            }
            else if (plan == "Semiannual")
            {
                months = 6;
            }
            else
            {
                months = 12;
            }

            
        }
        
        DomainExceptionValidation.When(planPrice < 15m, "The plan value is invalid. The provided value is too low.");
        DomainExceptionValidation.When(planPrice >= 500m, "The plan value is invalid. The provided value is too high.");
        PlanPrice = planPrice;

        NextPaymentDate = lastPaymentDate.AddMonths(months);

        
    }

    

}
