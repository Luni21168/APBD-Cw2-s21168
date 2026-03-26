using Zadanie_2.Domain.Equipment;
using Zadanie_2.Domain.Users;
using Zadanie_2.Repositories;
using Zadanie_2.Services;

namespace Zadanie_2.UI;

public static class DemoDataSeeder
{
    public static void Seed(
        UserRepository userRepository,
        EquipmentRepository equipmentRepository,
        RentalService rentalService)
    {
        userRepository.Add(new Student(1, "Anna", "Kowalska", "s12345", "Computer Science"));
        userRepository.Add(new Student(2, "Jan", "Nowak", "s23456", "Management"));
        userRepository.Add(new Employee(3, "Maria", "Wisniewska", "IT", "Administrator"));
        userRepository.Add(new Employee(4, "Piotr", "Zielinski", "Media", "Lecturer"));

        equipmentRepository.Add(new Laptop(1, "Dell Latitude", "Intel i7", 16));
        equipmentRepository.Add(new Laptop(2, "Lenovo ThinkPad", "AMD Ryzen 7", 32));
        equipmentRepository.Add(new Projector(3, "Epson X500", 3500, "Full HD"));
        equipmentRepository.Add(new Camera(4, "Canon EOS", 24, true));
        equipmentRepository.Add(new Camera(5, "Sony Alpha", 32, true));

        rentalService.BorrowEquipment(1, 1, DateTime.Today.AddDays(-2), 7);
        rentalService.BorrowEquipment(1, 3, DateTime.Today.AddDays(-1), 5);

        try
        {
            rentalService.BorrowEquipment(1, 4, DateTime.Today, 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXPECTED ERROR: " + ex.Message);
        }

        try
        {
            rentalService.MarkEquipmentUnavailable(2);
            rentalService.BorrowEquipment(3, 2, DateTime.Today, 5);
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXPECTED ERROR: " + ex.Message);
        }

        var penalty1 = rentalService.ReturnEquipment(1, DateTime.Today);
        Console.WriteLine($"Returned equipment 1 on time. Penalty: {penalty1:C}");

        rentalService.BorrowEquipment(3, 4, DateTime.Today.AddDays(-10), 3);
        var penalty2 = rentalService.ReturnEquipment(4, DateTime.Today);
        Console.WriteLine($"Returned equipment 4 late. Penalty: {penalty2:C}");
    }
}