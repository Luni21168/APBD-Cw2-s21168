using Zadanie_2.Repositories;
using Zadanie_2.Services;
using Zadanie_2.UI;

namespace Zadanie_2;

public class Program
{
    public static void Main(string[] args)
    {
        var equipmentRepository = new EquipmentRepository();
        var userRepository = new UserRepository();
        var rentalRepository = new RentalRepository();

        var rentalPolicy = new RentalPolicy();
        var penaltyCalculator = new PenaltyCalculator();

        var rentalService = new RentalService(
            equipmentRepository,
            userRepository,
            rentalRepository,
            rentalPolicy,
            penaltyCalculator
        );

        var reportService = new ReportService(
            equipmentRepository,
            userRepository,
            rentalRepository
        );

        DemoDataSeeder.Seed(userRepository, equipmentRepository, rentalService);

        Console.WriteLine("ALL EQUIPMENT");
        reportService.PrintAllEquipment();

        Console.WriteLine();
        Console.WriteLine("AVAILABLE EQUIPMENT");
        reportService.PrintAvailableEquipment();

        Console.WriteLine();
        Console.WriteLine("ACTIVE RENTALS FOR USER 1");
        reportService.PrintActiveRentalsForUser(1);

        Console.WriteLine();
        Console.WriteLine("OVERDUE RENTALS");
        reportService.PrintOverdueRentals(DateTime.Today);

        Console.WriteLine();
        Console.WriteLine("FINAL REPORT");
        reportService.PrintSummaryReport();
    }
}