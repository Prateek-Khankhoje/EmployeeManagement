namespace EmployeeManagement.Contracts
{
    public class BaseContractRS
    {
        public bool Success { get; set; } = true;
        public string? Error { get; set; }
    }
}