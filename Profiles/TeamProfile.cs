

namespace WorldCupAPI.Profiles
{
	public class TeamProfile : Profile
	{
        public TeamProfile()
        {
			CreateMap<TeamRequestDto, Team>()
				.ForMember(dest => dest.TeamId, options => options.Ignore());
			CreateMap<UpdatedTeamRequestDto, Team>()
				.ForMember(dest => dest.TeamId, options => options.Ignore())
				.ForMember(dest => dest.CountryName, opt => opt.Condition(src => src.CountryName != default))
				.ForMember(dest => dest.CountryName, options => options.MapFrom(src => src.CountryName))
				.ForMember(dest => dest.ConfederationId, opt => opt.Condition(src => src.ConfederationId != default))
				.ForMember(dest => dest.ConfederationId, options => options.MapFrom(src => src.ConfederationId));
			CreateMap<Team, TeamResponseDto>();
		}   
	}
}
