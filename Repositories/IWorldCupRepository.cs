namespace WorldCupAPI.Repositories
{
	public interface IWorldCupRepository
	{
		Task<List<Team>> GetTeams();

		Task<Team> GetTeamById(int id);

		Task<Team> AddTeam(Team team);

		Task<bool> EditTeam(Team team);

		Task<bool> DeleteTeam(int id);
	}
}
