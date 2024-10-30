using Google.Protobuf.Collections;
using user_microservice.Src.DTOs.UserProgress;
using user_microservice.Src.DTOs.Subjects;
using user_microservice.Src.Protos;

namespace user_microservice.Src.Services.Interfaces
{
    public interface ISubjectsService
    {
        public Task<RepeatedField<SubjectResponse>> GetAll();

        public Task<RepeatedField<RelationshipResponse>> GetAllRelationships();

    }
}