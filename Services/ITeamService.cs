namespace WorldCupAPI.Services
{
	public interface ITeamService
	{

		Task<List<Team>> GetTeams();

		Task<Team> GetTeamById(int id);

		Task<TeamResponseDto> AddTeam(TeamRequestDto team);

		Task<List<Team>> EditTeam(int teamId, UpdatedTeamRequestDto team);

		Task<List<Team>> DeleteTeam(int id);
	}
}
