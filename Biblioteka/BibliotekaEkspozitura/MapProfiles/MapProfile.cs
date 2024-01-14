using AutoMapper;
using BibliotekaEkspozitura.Domain;
using BibliotekaEkspozitura.Dto;

namespace BibliotekaEkspozitura.MapProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RentDto, RentBook>().ReverseMap();
        }
    }
}
