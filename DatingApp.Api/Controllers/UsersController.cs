using DatingApp.Api.Entities;
using DatingApp.Api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController(ApplicationDbContext dbContext) : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext = dbContext;

		[HttpGet()]
		public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
		{
			var users = await _dbContext.Users.ToListAsync();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AppUser>> GetUser(int id)
		{
			var user = await _dbContext.Users.FindAsync(id);
			if(user is null)
				return NotFound();

			return Ok(user);
		}
	}
}
