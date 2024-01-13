using AutoMapper;
using BibliotekaCentralna.Dto;
using BibliotekaCentralna.Model;

namespace BibliotekaCentralna.MapProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RegisterMemberDto, Member>().ReverseMap();
            CreateMap<Member, MemberDto>().ReverseMap();
        }
    }
}
