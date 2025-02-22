namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;

public class CreateIndividualCustomerRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Occupation { get; set; }
    public bool IsEmployed { get; set; }
    public string EmployerName { get; set; }
    public int WorkExperienceInMonths { get; set; }
} 