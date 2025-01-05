using AutoMapper;
using Peercode.Core.Models;
using Peercode.Dtos;

namespace Peercode
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile() 
        {
            this.CreateMap<RegisterDto, Register>();
            this.CreateMap<LoginDto, Login>();
            this.CreateMap<Register, User>();
            this.CreateMap<UserUpdateDto, User>();
        }
    }
}
