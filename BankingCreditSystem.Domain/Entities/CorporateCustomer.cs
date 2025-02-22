namespace BankingCreditSystem.Domain.Entities;

public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; }
    public string TradeRegistryNumber { get; set; }
    public string CompanyType { get; set; } // AŞ, LTD vs.
    public DateTime FoundationDate { get; set; }
    public int NumberOfEmployees { get; set; }
    public decimal AnnualTurnover { get; set; }
    public string AuthorizedPersonName { get; set; }
    public string AuthorizedPersonTitle { get; set; }
} 