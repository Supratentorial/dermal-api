using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dermal.api.Data;

namespace dermal.api.Controllers
{
    [Route("api/[controller]")]
    public class ReferralRequestsController : Controller
    {
        DermalDbContext _context;

        public ReferralRequestsController(DermalDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReferralRequests(bool? includeMedia)
        {
            var referralRequests = this._context.ReferralRequests;
            if (includeMedia == true)
            {
                referralRequests.Include(r => r.Media);
            }
            return Ok(await referralRequests.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostReferralRequest(ReferralRequest referralRequest)
        {
            if (referralRequest == null)
            {
                return BadRequest();
            }
            if (referralRequest.Id != 0)
            {
                return BadRequest();
            }
            this._context.ReferralRequests.Add(referralRequest);
            await this._context.SaveChangesAsync();
            return Ok();
        }
    }
}