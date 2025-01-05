using AutoMapper;
using Peercode.Core;
using Peercode.Core.Models;
using Peercode.Dtos;

namespace Peercode.Services.Implementations;

public class UserService(IMapper mapper, IUnitOfWork unitOfWork) : IUserService
{
    public async Task AddUserAsync(Register register)
    {
        var user = mapper.Map<User>(register);
        await unitOfWork.UserRepository.AddUserAsync(user);
    }

    public async Task<UserDetailsDto> GetUserAsync(Guid userId)
    {
        var user = await unitOfWork.UserRepository.GetUserAsync(userId);
        return mapper.Map<UserDetailsDto>(user);
    }

    public async Task UpdateUserAsync(Guid userId, UserUpdateDto userUpdateDto)
    {
        var user = mapper.Map<User>(userUpdateDto);
        user.UserId = userId;
        await unitOfWork.UserRepository.UpdateUserAsync(user);
    }
}
