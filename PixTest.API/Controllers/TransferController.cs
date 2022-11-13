using Microsoft.AspNetCore.Mvc;
using PixTest.Application.DTOs;
using PixTest.Application.Interfaces;
using System.Threading.Tasks;

namespace PixTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost("TransferirPix")]
        public async Task<IActionResult> Transfer(TransferDTO transferDTO)
        {          
            return Ok(await _transferService.PostTransaction(transferDTO));
        }
    }
}
