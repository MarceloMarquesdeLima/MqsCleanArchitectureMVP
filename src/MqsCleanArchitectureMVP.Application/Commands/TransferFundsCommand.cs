namespace MqsCleanArchitectureMVP.Application.Commands
{
    public class TransferFundsCommand
    {
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
