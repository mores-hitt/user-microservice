using AutoMapper;
using user_microservice.Src.Models;
using user_microservice.Src.Protos;

namespace user_microservice.Src.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectRelationship, SubjectRelationshipDto>();
        }
    }
}