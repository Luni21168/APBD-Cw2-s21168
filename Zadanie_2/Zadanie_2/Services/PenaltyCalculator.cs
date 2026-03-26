namespace Zadanie_2.Services;

public class PenaltyCalculator
{
    private const decimal DailyPenalty = 15m;

    public decimal Calculate(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate.Date <= dueDate.Date)
        {
            return 0m;
        }

        var lateDays = (returnDate.Date - dueDate.Date).Days;
        return lateDays * DailyPenalty;
    }
}