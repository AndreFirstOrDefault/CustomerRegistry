namespace CustomerRegistry.Application.Interfaces;

public interface IDateService
{
    DateTime nextPay(DateTime lastPay, string plan);
}
