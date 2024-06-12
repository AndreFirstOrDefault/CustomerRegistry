namespace CustomerRegistry.Domain.Validation;

// 3° passo - classe de validação
public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base (error)
    {
        
    }

    public static void When(bool hasError, string error)
    {
        if (hasError)
        {
            throw new DomainExceptionValidation(error);
        }
    }
}
