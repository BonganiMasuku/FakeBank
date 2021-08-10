using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBankApi.Models;
using FakeBankContract.Interfaces;
using FakeBankModel.Enums;
using FakeBankService.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeBankApi.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/BankAccountTransfer")]
    public class BankAccountTransferController : ControllerBase
    {
        private readonly IBankAccountTransferService _bankAccountTransferService;

        public BankAccountTransferController(
            IBankAccountTransferService bankAccountTransferService
            )
        {
            _bankAccountTransferService = bankAccountTransferService;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Execute([FromBody] BankAccountTransferExecuteRequest request)
        {
            _bankAccountTransferService.Execute(request.FromAccountId, request.ToAccountId, request.Amount);
            return Ok();
        }

        [HttpGet]
        [Route("IncomeHistory/{bankAccountId}")]
        public ActionResult<List<IBankAccountTransferContract>> IncomeHistory(int bankAccountId)
        {
            var response = _bankAccountTransferService.GetAccountHistory(bankAccountId, TransferRoleEnum.Receiver);
            return Ok(response);
        }

        [HttpGet]
        [Route("OutgoingHistory/{bankAccountId}")]
        public ActionResult<List<IBankAccountTransferContract>> OutgoingHistory(int bankAccountId)
        {
            var response = _bankAccountTransferService.GetAccountHistory(bankAccountId, TransferRoleEnum.Sender);
            return Ok(response);
        }
    }
}
