namespace MqsCleanArchitectureMVP.Application.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string HolderName { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
