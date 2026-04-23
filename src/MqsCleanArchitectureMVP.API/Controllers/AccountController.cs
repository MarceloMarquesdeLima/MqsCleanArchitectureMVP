using Microsoft.AspNetCore.Mvc;
using MqsCleanArchitectureMVP.Application.Commands;
using MqsCleanArchitectureMVP.Application.Handlers.CommandHandlers;
using MqsCleanArchitectureMVP.Application.Handlers.QueryHandlers;
using MqsCleanArchitectureMVP.Application.Queries;

namespace MqsCleanArchitectureMVP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly CreateAccountHandler _createHandler;
        private readonly TransferFundsHandler _transferHandler;
        private readonly GetAccountBalanceHandler _balanceHandler;

        public AccountController(
            CreateAccountHandler createHandler,
            TransferFundsHandler transferHandler,
            GetAccountBalanceHandler balanceHandler)
        {
            _createHandler = createHandler;
            _transferHandler = transferHandler;
            _balanceHandler = balanceHandler;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            await _createHandler.Handle(command);
            return Ok("Conta criada com sucesso!");
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferFunds([FromBody] TransferFundsCommand command)
        {
            await _transferHandler.Handle(command);
            return Ok("Transferência realizada com sucesso!");
        }

        [HttpGet("{id}/balance")]
        public async Task<IActionResult> GetBalance(Guid id)
        {
            var result = await _balanceHandler.Handle(new GetAccountBalanceQuery { AccountId = id });
            return Ok(result);
        }
    }
}
