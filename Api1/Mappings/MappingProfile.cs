using Api1.Models;
using AutoMapper;

namespace Api1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Dzivoklis and Dzivoklis_DTO
            CreateMap<Dzivoklis, Dzivoklis_DTO>()
                .ForMember(dest => dest.Maja_Id, opt => opt.MapFrom(src => src.Maja_Id))
                .ForMember(dest => dest.Saikne_Ar_Maju, opt => opt.MapFrom(src => src.Saikne_Ar_Maju));

            CreateMap<Dzivoklis_DTO, Dzivoklis>()
                .ForMember(dest => dest.Maja_Id, opt => opt.MapFrom(src => src.Maja_Id))
                .ForMember(dest => dest.Saikne_Ar_Maju, opt => opt.Ignore());

            // Mapping for Iedzivotajs and Iedzivotajs_DTO
            CreateMap<Iedzivotajs, Iedzivotajs_DTO>();
            CreateMap<Iedzivotajs_DTO, Iedzivotajs>();

            // Mapping for Maja and Maja_DTO
            CreateMap<Maja, Maja_DTO>();
            CreateMap<Maja_DTO, Maja>();

            // Mapping for Iedzivotaja_Dzivoklis and Dzivokla_Iedzivotajs
            CreateMap<Iedzivotaja_Dzivoklis, Dzivokla_Iedzivotajs>();
            CreateMap<Dzivokla_Iedzivotajs, Iedzivotaja_Dzivoklis>();

            // Mapping for Majas_Dzivoklis
            CreateMap<Majas_Dzivoklis, Maja_DTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Maja_Id))
                .ForMember(dest => dest.Numurs, opt => opt.MapFrom(src => src.Maja!.Numurs))
                .ForMember(dest => dest.Iela, opt => opt.MapFrom(src => src.Maja!.Iela))
                .ForMember(dest => dest.Pilseta, opt => opt.MapFrom(src => src.Maja!.Pilseta))
                .ForMember(dest => dest.Valsts, opt => opt.MapFrom(src => src.Maja!.Valsts))
                .ForMember(dest => dest.Pasta_Indekss, opt => opt.MapFrom(src => src.Maja!.Pasta_Indekss));

            CreateMap<Maja_DTO, Majas_Dzivoklis>()
                .ForMember(dest => dest.Maja_Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Maja, opt => opt.Ignore());
        }
    }
}
