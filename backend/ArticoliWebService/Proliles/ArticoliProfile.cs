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
            );
        }
    }
}