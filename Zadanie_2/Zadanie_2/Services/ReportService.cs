using Zadanie_2.Repositories;

namespace Zadanie_2.Services;

public class ReportService
{
    private readonly EquipmentRepository _equipmentRepository;
    private readonly UserRepository _userRepository;
    private readonly RentalRepository _rentalRepository;

    public ReportService(
        EquipmentRepository equipmentRepository,
        UserRepository userRepository,
        RentalRepository rentalRepository)
    {
        _equipmentRepository = equipmentRepository;
        _userRepository = userRepository;
        _rentalRepository = rentalRepository;
    }

    public void PrintAllEquipment()
    {
        foreach (var equipment in _equipmentRepository.GetAll())
        {
            Console.WriteLine(equipment);
        }
    }

    public void PrintAvailableEquipment()
    {
        foreach (var equipment in _equipmentRepository.GetAvailable())
        {
            Console.WriteLine(equipment);
        }
    }

    public void PrintActiveRentalsForUser(int userId)
    {
        var user = _userRepository.GetById(userId);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine($"Active rentals for {user.FullName}:");

        var rentals = _rentalRepository.GetActiveByUserId(userId);
        if (!rentals.Any())
        {
            Console.WriteLine("No active rentals.");
            return;
        }

        foreach (var rental in rentals)
        {
            Console.WriteLine(rental);
        }
    }

    public void PrintOverdueRentals(DateTime today)
    {
        var overdueRentals = _rentalRepository.GetOverdue(today);

        if (!overdueRentals.Any())
        {
            Console.WriteLine("No overdue rentals.");
            return;
        }

        foreach (var rental in overdueRentals)
        {
            Console.WriteLine(rental);
        }
    }

    public void PrintSummaryReport()
    {
        var allEquipment = _equipmentRepository.GetAll();
        var allUsers = _userRepository.GetAll();
        var allRentals = _rentalRepository.GetAll();

        Console.WriteLine($"Users count: {allUsers.Count}");
        Console.WriteLine($"Equipment count: {allEquipment.Count}");
        Console.WriteLine($"Active rentals count: {allRentals.Count(r => r.IsActive)}");
        Console.WriteLine($"Returned rentals count: {allRentals.Count(r => !r.IsActive)}");
        Console.WriteLine($"Total penalties: {allRentals.Sum(r => r.Penalty):C}");
    }
}