using CustomerRegistry.Application.Interfaces;

namespace CustomerRegistry.Application.Services;

public class DateService : IDateService
{
    public DateTime nextPay(DateTime lastPay, string plan)
    {
        int months = 0;

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

        return lastPay.AddMonths(months);
    }
}
