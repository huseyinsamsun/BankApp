namespace BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;

public class UpdateCorporateCustomerRequest
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int NumberOfEmployees { get; set; }
    public decimal AnnualTurnover { get; set; }
    public string AuthorizedPersonName { get; set; }
    public string AuthorizedPersonTitle { get; set; }
} 