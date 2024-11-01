using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using user_microservice.Src.Protos;

using user_microservice.Src.Services.Interfaces;

namespace user_microservice.Src.Controllers
{
    public class AuthController : JwtGrpc.JwtGrpcBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /*

        public override async Task<GenerateTokenResponse> GenerateToken(Empty request, ServerCallContext context)
        {
            var token =  await _authService.GenerateJwt();

            var response = new GenerateTokenResponse();

            //add token to response

            response.Token = token;

            return response;

        }

        */
    }
}