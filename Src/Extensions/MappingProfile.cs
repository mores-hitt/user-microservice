using AutoMapper;
//using user_microservice.Src.DTOs.Auth;
using user_microservice.Src.DTOs.Models;
using user_microservice.Src.DTOs.Subjects;
using user_microservice.Src.Models;
using user_microservice.Src.Protos;

namespace user_microservice.Src.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subject, SubjectResponse>();
            CreateMap<SubjectRelationship, RelationshipResponse>();
        }
    }
}