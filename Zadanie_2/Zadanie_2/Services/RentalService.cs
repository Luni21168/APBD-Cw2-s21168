using Zadanie_2.Domain.Enums;
using Zadanie_2.Domain.Rentals;
using Zadanie_2.Repositories;

namespace Zadanie_2.Services;

public class RentalService
{
    private readonly EquipmentRepository _equipmentRepository;
    private readonly UserRepository _userRepository;
    private readonly RentalRepository _rentalRepository;
    private readonly RentalPolicy _rentalPolicy;
    private readonly PenaltyCalculator _penaltyCalculator;
    private int _rentalIdCounter = 1;

    public RentalService(
        EquipmentRepository equipmentRepository,
        UserRepository userRepository,
        RentalRepository rentalRepository,
        RentalPolicy rentalPolicy,
        PenaltyCalculator penaltyCalculator)
    {
        _equipmentRepository = equipmentRepository;
        _userRepository = userRepository;
        _rentalRepository = rentalRepository;
        _rentalPolicy = rentalPolicy;
        _penaltyCalculator = penaltyCalculator;
    }

    public void BorrowEquipment(int userId, int equipmentId, DateTime borrowDate, int days)
    {
        var user = _userRepository.GetById(userId)
                   ?? throw new InvalidOperationException($"User with id {userId} not found.");

        var equipment = _equipmentRepository.GetById(equipmentId)
                        ?? throw new InvalidOperationException($"Equipment with id {equipmentId} not found.");

        if (equipment.Status == EquipmentStatus.Unavailable)
        {
            throw new InvalidOperationException("Equipment is unavailable and cannot be rented.");
        }

        if (equipment.Status == EquipmentStatus.Rented)
        {
            throw new InvalidOperationException("Equipment is already rented.");
        }

        var activeRentalsCount = _rentalRepository.GetActiveByUserId(userId).Count;
        var limit = _rentalPolicy.GetUserLimit(user);

        if (activeRentalsCount >= limit)
        {
            throw new InvalidOperationException($"User exceeded active rental limit ({limit}).");
        }

        var rental = new Rental(_rentalIdCounter++, userId, equipmentId, borrowDate, borrowDate.AddDays(days));
        _rentalRepository.Add(rental);
        equipment.MarkAsRented();
    }

    public decimal ReturnEquipment(int equipmentId, DateTime returnDate)
    {
        var equipment = _equipmentRepository.GetById(equipmentId)
                        ?? throw new InvalidOperationException($"Equipment with id {equipmentId} not found.");

        var rental = _rentalRepository.GetActiveByEquipmentId(equipmentId)
                     ?? throw new InvalidOperationException("Active rental for this equipment not found.");

        var penalty = _penaltyCalculator.Calculate(rental.DueDate, returnDate);
        rental.Return(returnDate, penalty);
        equipment.MarkAsAvailable();

        return penalty;
    }

    public void MarkEquipmentUnavailable(int equipmentId)
    {
        var equipment = _equipmentRepository.GetById(equipmentId)
                        ?? throw new InvalidOperationException($"Equipment with id {equipmentId} not found.");

        if (equipment.Status == EquipmentStatus.Rented)
        {
            throw new InvalidOperationException("Cannot mark rented equipment as unavailable.");
        }

        equipment.MarkAsUnavailable();
    }
}