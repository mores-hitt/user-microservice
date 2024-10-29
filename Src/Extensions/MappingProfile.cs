using AutoMapper;
//using user_microservice.Src.DTOs.Auth;
using user_microservice.Src.DTOs.Models;
using user_microservice.Src.DTOs.Subjects;
using user_microservice.Src.Models;

namespace user_microservice.Src.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Career, CareerDto>();
            //CreateMap<Role, RoleDto>();
            //CreateMap<User, UserDto>();
            //CreateMap<User, LoginResponseDto>();
            //CreateMap<RegisterStudentDto, User>();
            CreateMap<Subject, SubjectsDTO>();
            //CreateMap<SubjectRelationship, SubjectRelationshipDto>();
        }
    }
}