namespace WorldCupAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeamController : ControllerBase
	{
		private readonly ITeamService _teamService;

		public TeamController(ITeamService teamService)
		{
			_teamService = teamService;
		}

		[HttpGet("GetTeams")]
		public async Task<IActionResult> GetTeams()
		{
			try
			{
				return Ok(await _teamService.GetTeams());
			}
			catch (Exception exc)
			{
				return BadRequest(exc.Message);
			}
		}

		[HttpGet("GetTeamsById/{teamId}")]
		public async Task<IActionResult> GetTeamsById(int teamId)
		{
			try
			{
				return Ok(await _teamService.GetTeamById(teamId));
			}
			catch (Exception exc)
			{
				return BadRequest(exc.Message);
			}
		}

		[HttpPost("AddTeam")]
		public async Task<IActionResult> AddTeam(TeamRequestDto newTeam)
		{
			try
			{
				return Ok(await _teamService.AddTeam(newTeam));
			}
			catch (Exception exc)
			{
				return BadRequest(exc.Message);
			}
		}

		[HttpPut("EditTeam/{teamId}")]
		public async Task<IActionResult> EditTeam(int teamId, UpdatedTeamRequestDto team)
		{
			try
			{
				return Ok(await _teamService.EditTeam(teamId, team));
			}
			catch (Exception exc)
			{
				return BadRequest(exc.Message);
			}
		}

		[HttpDelete("DeleteTeam/{teamId}")]
		public async Task<IActionResult> DeleteTeam(int teamId)
		{
			try
			{
				return Ok(await _teamService.DeleteTeam(teamId));
			}
			catch (Exception exc)
			{
				return BadRequest(exc.Message);
			}
		}
	}
}
