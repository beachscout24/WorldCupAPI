using Microsoft.EntityFrameworkCore;

namespace WorldCupAPI.Repositories
{
	public class WorldCupRepository : IWorldCupRepository
	{
		private readonly DataContext _dataContext;

		public WorldCupRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<int> AddTeam(Team team)
		{
			await _dataContext.Teams.AddAsync(team);
			await Save();
			return team.TeamId;
		}

		public async Task<bool> DeleteTeam(int id)
		{
			return await _dataContext.Teams.Where(t => t.TeamId == id).ExecuteDeleteAsync() > 0;
		}

		public async Task<bool> EditTeam(Team team)
		{
			return await _dataContext.Teams.Where(t => t.TeamId == team.TeamId)
				.ExecuteUpdateAsync(t => t.SetProperty(t => t.CountryName, team.CountryName)
				.SetProperty(t => t.ConfederationId, team.ConfederationId)) > 0;
		}

		public async Task<Team> GetTeamById(int id)
		{
			var team = await _dataContext.Teams.Include(x => x.Confederation).Where(x => x.TeamId == id).FirstOrDefaultAsync();
			return team!;
		}

		public async Task<List<Team>> GetTeams()
		{
			var teams = await _dataContext.Teams.Include(t => t.Confederation).ToListAsync();
			return teams;
		}

		private async Task<bool> Save()
		{
			return await _dataContext.SaveChangesAsync() > 0;
		}
	}
}
