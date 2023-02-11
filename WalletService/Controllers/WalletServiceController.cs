using Microsoft.AspNetCore.Mvc;
using WalletService;
using static WalletService.WalletService;

namespace WalletService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletServiceController : ControllerBase
    {
  
        // POST api/<WalletServiceController>
        [HttpPost("Walletnew")]
        public void Post(int ownerId, decimal balance, string createdAt, string updatedAt)
        {
          WalletService walletService = new WalletService();
          walletService.Walletnew(ownerId, balance, createdAt, updatedAt);
        }

        
    }
}
