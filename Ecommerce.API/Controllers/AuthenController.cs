using Ecommerce.Data.IdentityDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenController : ControllerBase
    {
        private readonly IDbContextFactory<EcommerceDbContext> _dbContextFactory;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public AuthenController(IDbContextFactory<EcommerceDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Get()
        {
            return Ok($"Anh day!");
        }
    }
}