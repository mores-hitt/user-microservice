using Google.Protobuf.Collections;
using user_microservice.Src.Protos;

namespace user_microservice.Src.Services.Interfaces
{
    public interface ISubjectsService
    {
        public Task<RepeatedField<SubjectDto>> GetAll();

        public Task<RepeatedField<SubjectRelationshipDto>> GetAllRelationships();

        public Task<MapField<string, PrerequisiteDto>> GetAllPrerequisites();

        public Task<MapField<string, PostRequisiteDto>> GetAllPostRequisites();

    }
}