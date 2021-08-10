using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBankApi.Models;
using FakeBankContract.Interfaces;
using FakeBankService.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeBankApi.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/BankAccount")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly IBankAccountTransactionService _bankAccountTransactionService;

        public BankAccountController(
            IBankAccountService bankAccountService,
            IBankAccountTransactionService bankAccountTransactionService
            )
        {
            _bankAccountService = bankAccountService;
            _bankAccountTransactionService = bankAccountTransactionService;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<int> Create([FromBody] BankAccountCreateRequest request)
        {
            try
            {
                var response = _bankAccountService.Create(request.CustomerId, request.Name, request.InitialDeposit);
                return Ok(response);
            }
            catch (Exception e)
            {
                if (e.Message == "Customer not found with provided Id")
                    return NotFound(e.Message);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult<List<IBankAccountContract>> Get()
        {
            var response = _bankAccountService.Get();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById/{bankAccountId}")]
        public ActionResult<IBankAccountContract> GetById(int bankAccountId)
        {
            var response = _bankAccountService.GetById(bankAccountId);
            return Ok(response);
        }

        [HttpGet]
        [Route("Balance/{bankAccountId}")]
        public ActionResult<double> Balance(int bankAccountId)
        {
            var response = _bankAccountTransactionService.GetBalance(bankAccountId);
            return Ok(response);
        }
    }
}
