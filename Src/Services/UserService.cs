using Grpc.Core;
using user_microservice.Src.Exceptions;
using user_microservice.Src.Models;
using user_microservice.Src.Repositories.Interfaces;
using user_microservice.Src.Services.Interfaces;

using Google.Protobuf.Collections;
using user_microservice.Src.Protos;

namespace user_microservice.Src.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;
        private readonly IAuthService _authService;

        public UsersService(IUnitOfWork unitOfWork, IMapperService mapperService, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapperService = mapperService;
            _authService = authService;
        }

        public Task<UserDto> GetProfile(ServerCallContext context)
        {
            var userEmail = _authService.GetUserEmailInToken(context);
            return GetByEmail(userEmail);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await GetUserByEmail(email);
            return _mapperService.Map<User, UserDto>(user);
        }

        private async Task<User> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.UsersRepository.GetByEmail(email)
                                        ?? throw new EntityNotFoundException($"User with email: {email} not found");


            var allUsers = await _unitOfWork.UsersRepository.GetAll();

            allUsers.ForEach(u => 
            {
                Console.WriteLine(u.Id + " " + u.Email);
            });

            return user;
        }

        public async Task<UserDto> EditProfile(EditProfileDto editProfileDto, ServerCallContext context)
        {
            
            
            var userEmail = _authService.GetUserEmailInToken(context);
            var user = await GetUserByEmail(userEmail);
            // UpdateFields
            user.Name = editProfileDto.Name;
            user.FirstLastName = editProfileDto.FirstLastName;
            user.SecondLastName = editProfileDto.SecondLastName;

            var updatedUser = await _unitOfWork.UsersRepository.Update(user);

            return _mapperService.Map<User, UserDto>(updatedUser);
        }

    }

}