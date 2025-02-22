namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;

public class CreateCorporateCustomerRequest
{
    public string CompanyName { get; set; }
    public string TradeRegistryNumber { get; set; }
    public string CompanyType { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public DateTime FoundationDate { get; set; }
    public int NumberOfEmployees { get; set; }
    public decimal AnnualTurnover { get; set; }
    public string AuthorizedPersonName { get; set; }
    public string AuthorizedPersonTitle { get; set; }
    public string TaxOffice { get; set; }
    public string TaxNumber { get; set; }
} 