using Grpc.Core;
using Google.Protobuf.Collections;
using user_microservice.Src.Protos;


namespace user_microservice.Src.Services.Interfaces
{
    public interface IUsersService
    {


        public Task<UserDto> GetProfile(ServerCallContext context);

        public Task<UserDto> EditProfile(EditProfileDto editProfileDto, ServerCallContext context);

        public Task<UserDto> GetByEmail(string email);

        /*

        public Task<List<UserDto>> GetAll();

        public Task<UserDto> GetById(int id);

        public Task<UserDto> GetByEmail(string email);

        public Task<UserDto> EditProfile(EditProfileDto editProfileDto);

        public Task<bool> IsEnabled(string email);

        public Task<List<UserProgressDto>> GetUserProgress();

        public Task SetUserProgress(UpdateUserProgressDto subjects);

        */

        
    }
}