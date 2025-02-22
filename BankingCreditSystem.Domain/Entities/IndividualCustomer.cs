namespace BankingCreditSystem.Domain.Entities;

public class IndividualCustomer : Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; } // TC Kimlik No
    public DateTime DateOfBirth { get; set; }
    public string Occupation { get; set; }
    public bool IsEmployed { get; set; }
    public string EmployerName { get; set; }
    public int WorkExperienceInMonths { get; set; }
} 