using AutoMapper;
using ConnectLegal.DTOs;
using ConnectLegal.Entities;

namespace ConnectLegal.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLawFirmDto, LawFirm>();
        CreateMap<UpdateLawFirmDto, LawFirm>();
        CreateMap<LawFirm, LawFirmResponseDto>();
        CreateMap<LawFirm, LawFirmDetailDto>();


        CreateMap<CreateLawyerDto, Lawyer>();
        CreateMap<UpdateLawyerDto, Lawyer>();
        CreateMap<Lawyer, LawyerResponseDto>()
    }
}