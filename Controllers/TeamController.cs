namespace WorldCupAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeamController : ControllerBase
	{
		private readonly IWorldCupRepository _worldCupRepository;

		public TeamController(IWorldCupRepository worldCupRepository)
		{
			_worldCupRepository = worldCupRepository;
		}

		[HttpGet("GetTeams")]
		public async Task<IActionResult> GetTeams()
		{
			try
			{
				return Ok(await _worldCupRepository.GetTeams());
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
				return Ok(await _worldCupRepository.GetTeamById(teamId));
			}
			catch (Exception exc)
			{
				return BadRequest(exc.Message);
			}
		}

		[HttpPost("AddTeam")]
		public async Task<IActionResult> AddTeam(Team newTeam)
		{
			try
			{
				var teamId = await _worldCupRepository.AddTeam(newTeam);
				return Ok(await _worldCupRepository.GetTeamById(teamId));
			}
			catch (Exception exc)
			{
				return BadRequest(exc.Message);
			}
		}

		[HttpPut("EditTeam")]
		public async Task<IActionResult> EditTeam(Team team)
		{
			try
			{
				if (await _worldCupRepository.EditTeam(team))
				{
					return Ok(await _worldCupRepository.GetTeams());
				}
				else
				{
					return BadRequest($"Team could not be updated for teamID: {team.TeamId}");
				}
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
				if (await _worldCupRepository.DeleteTeam(teamId))
				{
					return Ok(await _worldCupRepository.GetTeams());
				}
				else
				{
					return BadRequest($"Team was not deleted with ID: {teamId}");
				}
			}
			catch (Exception exc)
			{
				return BadRequest(exc.Message);
			}
		}
	}
}
