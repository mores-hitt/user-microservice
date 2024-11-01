using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using user_microservice.Src.Protos;

using user_microservice.Src.Services.Interfaces;

namespace user_microservice.Src.Controllers
{
    public class UsersController : UserGrpc.UserGrpcBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public override Task<UserDto> GetProfile(Empty request, ServerCallContext context)
        {
            try
            {
                return _usersService.GetProfile(context);
            }
            catch (System.Exception e)
            {
                switch (e)
                {
                    case UnauthorizedAccessException:
                        throw new RpcException(new Status(StatusCode.Unauthenticated, e.Message));
                    default:
                        throw new RpcException(new Status(StatusCode.Internal, e.Message));
                }
            }
        }

        public override async Task<UserDto> EditProfile(EditProfileDto request, ServerCallContext context)
        {
            try
            {
                return await _usersService.EditProfile(request, context);
            }
            catch (System.Exception e)
            {
                switch (e)
                {
                    case UnauthorizedAccessException:
                        throw new RpcException(new Status(StatusCode.Unauthenticated, e.Message));
                    default:
                        throw new RpcException(new Status(StatusCode.Internal, e.Message));
                }
            }
        
        }

    }
}