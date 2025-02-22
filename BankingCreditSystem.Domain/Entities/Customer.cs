namespace BankingCreditSystem.Domain.Entities;

public abstract class Customer : Core.Repositories.Entity<Guid>
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public bool IsActive { get; set; } = true;
    public decimal TotalIncome { get; set; }
    public string TaxOffice { get; set; }
    public string TaxNumber { get; set; }
} 