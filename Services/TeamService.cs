using WorldCupAPI.Models;

namespace WorldCupAPI.Services
{
	public class TeamService : ITeamService
	{
		private readonly IWorldCupRepository _worldCupRepository;
		private readonly IMapper _mapper;

		public TeamService(IWorldCupRepository worldCupRepository, IMapper mapper)
        { 
			_worldCupRepository = worldCupRepository;
			_mapper = mapper;
		}
        public async Task<TeamResponseDto> AddTeam(TeamRequestDto team)
		{

			var addedTeam = await _worldCupRepository.AddTeam(_mapper.Map<Team>(team));
			return _mapper.Map<TeamResponseDto>(addedTeam);
		}

		public async Task<List<Team>> DeleteTeam(int teamId)
		{
			if (await _worldCupRepository.DeleteTeam(teamId))
			{
				return await _worldCupRepository.GetTeams();
			}
			else
			{
				throw new Exception($"Team was not deleted with ID: {teamId}");
			}
		}

		public async Task<List<Team>> EditTeam(int teamId, UpdatedTeamRequestDto? updatedTeam)
		{
			var team = await _worldCupRepository.GetTeamById(teamId);
			_mapper.Map(updatedTeam, team);

			if (await _worldCupRepository.EditTeam(team))
			{
				return await _worldCupRepository.GetTeams();
			}
			else
			{
				throw new Exception($"Team could not be updated for teamId: {team.TeamId}");
			}
		}

		public async Task<Team> GetTeamById(int teamId)
		{
			var team = await _worldCupRepository.GetTeamById(teamId);
			if (team is null)
			{
				throw new Exception($"Team could not be found for teamId: {teamId}");
			}
			else
			{
				return team;
			}
		}

		public async Task<List<Team>> GetTeams()
		{
			return await _worldCupRepository.GetTeams();
		}
	}
}
