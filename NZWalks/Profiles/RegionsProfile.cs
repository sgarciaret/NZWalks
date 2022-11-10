using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;

namespace NZWalksAPI.Profiles
{
    public class RegionsProfile: Profile
    {
        public RegionsProfile()
        {
            // Convert Domain model into DTO model
            CreateMap<Models.Domain.Region, Models.DTO.RegionDTO>()
                //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));   if properties hasn't the same name
                .ReverseMap();
        }
    }
}
