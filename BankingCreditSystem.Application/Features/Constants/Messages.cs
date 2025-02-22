namespace BankingCreditSystem.Application.Features.Constants;

public static class Messages
{
    public static class IndividualCustomer
    {
        public const string NotFound = "Individual customer not found.";
        public const string AlreadyExists = "Individual customer already exists.";
        public const string Created = "Individual customer created successfully.";
        public const string Updated = "Individual customer updated successfully.";
        public const string Deleted = "Individual customer deleted successfully.";
    }

    public static class CorporateCustomer
    {
        public const string NotFound = "Corporate customer not found.";
        public const string AlreadyExists = "Corporate customer already exists.";
        public const string Created = "Corporate customer created successfully.";
        public const string Updated = "Corporate customer updated successfully.";
        public const string Deleted = "Corporate customer deleted successfully.";
        public const string TaxNumberExists = "Tax number already exists.";
    }
} 