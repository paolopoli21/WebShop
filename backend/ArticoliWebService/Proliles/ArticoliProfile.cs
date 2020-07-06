using ArticoliWebService.Dtos;
using ArticoliWebService.Models;
using AutoMapper;
namespace Articoli_Web_Service.Proliles
{
    public class ArticoliProfile: Profile
    {
        public ArticoliProfile()
        {
            CreateMap<Articoli, ArticoliDto>()
            .ForMember
            (
                dest => dest.Categoria,
                opt => opt.MapFrom(src => $"{src.IdFamAss}{src.famAssort.Descrizione}")
            )
            .ForMember
            (
                dest => dest.CodStat,
                opt => opt.MapFrom(src => src.CodStat.Trim())
            )
            .ForMember
            (
                dest => dest.Um,
                opt => opt.MapFrom(src => src.Um.Trim())
            )
            .ForMember
            (
                dest => dest.IdStatoArt,
                opt => opt.MapFrom(src => src.IdStatoArt.Trim())
            );
        }
    }
}