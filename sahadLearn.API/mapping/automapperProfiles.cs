using AutoMapper;
using sahadLearn.API.models.domains;
using sahadLearn.API.models.DTO;

namespace sahadLearn.API.mapping
{
    public class automapperProfiles : Profile
    {
        public automapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<CreateRegionDTO, Region>();
            CreateMap<SignleRegionDTO, Region>().ReverseMap();
            CreateMap<WalksCreateDTO, Walk>().ReverseMap();
            CreateMap<Walk, WalksSingleDTO>();
            CreateMap<WalksCreateDTO, Walk>()
    .ForMember(x => x.WalkImageUrl, opt => opt.Ignore());
            CreateMap<Walk, WalksDTO>();
            CreateMap<Difficulty, difficultyDTO>();

        }
    }
}