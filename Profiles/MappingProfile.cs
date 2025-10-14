using AutoMapper;
using ConnectLegal.DTOs;
using ConnectLegal.Entities;

namespace ConnectLegal.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LawFirm, LawFirmDto>();
        CreateMap<LawFirm, LawFirmWithLawyersDto>();
        CreateMap<CreateLawFirmDto, LawFirm>();
        CreateMap<UpdateLawFirmDto, LawFirm>();

        CreateMap<Lawyer, LawyerDto>();
        CreateMap<CreateLawyerDto, Lawyer>();
        CreateMap<UpdateLawyerDto, Lawyer>();
    }
}