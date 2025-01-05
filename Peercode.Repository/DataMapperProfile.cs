using AutoMapper;
using Peercode.Core.Enums;
using Peercode.Core.Extensions;
using Peercode.Core.Models;
using Peercode.Persistance.DbModels;

namespace Peercode.Persistance;

public class DataMapperProfile : Profile
{
    public DataMapperProfile()
    {
        this.CreateMap<User, DbUser>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.ToJson()))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => (short)src.Sex))
            .ReverseMap()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.FromJson<Address>()))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => (Sex)src.Sex));
    }
}
