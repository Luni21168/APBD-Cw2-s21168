namespace Zadanie_2.Domain.Rentals;

public class Rental
{
    public int Id { get; }
    public int UserId { get; }
    public int EquipmentId { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal Penalty { get; private set; }

    public Rental(int id, int userId, int equipmentId, DateTime borrowDate, DateTime dueDate)
    {
        Id = id;
        UserId = userId;
        EquipmentId = equipmentId;
        BorrowDate = borrowDate;
        DueDate = dueDate;
    }

    public bool IsActive => ReturnDate == null;

    public bool IsOverdue(DateTime today)
    {
        return IsActive && today.Date > DueDate.Date;
    }

    public void Return(DateTime returnDate, decimal penalty)
    {
        ReturnDate = returnDate;
        Penalty = penalty;
    }

    public override string ToString()
    {
        return $"Rental Id: {Id} | UserId: {UserId} | EquipmentId: {EquipmentId} | Borrow: {BorrowDate:yyyy-MM-dd} | Due: {DueDate:yyyy-MM-dd} | Return: {(ReturnDate.HasValue ? ReturnDate.Value.ToString("yyyy-MM-dd") : "NOT RETURNED")} | Penalty: {Penalty:C}";
    }
}