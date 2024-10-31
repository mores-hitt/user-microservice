using Google.Protobuf.Collections;
using user_microservice.Src.Protos;

namespace user_microservice.Src.Services.Interfaces
{
    public interface ISubjectsService
    {
        public Task<RepeatedField<SubjectResponse>> GetAll();

        public Task<RepeatedField<RelationshipResponse>> GetAllRelationships();

        public Task<MapField<string, PrerequisiteResponse>> GetAllPrerequisites();

        public Task<MapField<string, PostRequisiteResponse>> GetAllPostRequisites();

    }
}