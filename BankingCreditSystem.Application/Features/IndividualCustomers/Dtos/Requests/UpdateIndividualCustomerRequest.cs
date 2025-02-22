namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;

public class UpdateIndividualCustomerRequest
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Occupation { get; set; }
    public bool IsEmployed { get; set; }
    public string EmployerName { get; set; }
    public int WorkExperienceInMonths { get; set; }
} 