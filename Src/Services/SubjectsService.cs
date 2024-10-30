using System.Runtime.CompilerServices;
using Google.Protobuf.Collections;
using user_microservice.Src.DTOs.UserProgress;
using user_microservice.Src.DTOs.Subjects;
using user_microservice.Src.Protos;
using user_microservice.Src.Models;
using user_microservice.Src.Repositories.Interfaces;
using user_microservice.Src.Services.Interfaces;

namespace user_microservice.Src.Services
{
    public class SubjectsService : ISubjectsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;
        //private readonly IAuthService _authService;

        public SubjectsService(IUnitOfWork unitOfWork, IMapperService mapperService
        //, IAuthService authService
        )
        {
            _unitOfWork = unitOfWork;
            _mapperService = mapperService;
            //_authService = authService;
        }

        public async Task<RepeatedField<SubjectResponse>> GetAll()
        {
            var subjects = await _unitOfWork.SubjectsRepository.Get();

            return _mapperService.MapRepeatedField<Subject, SubjectResponse>(subjects);
        }


        public async Task<RepeatedField<RelationshipResponse>> GetAllRelationships()
        {
            var relationships = await _unitOfWork.SubjectRelationshipsRepository.Get();
            return _mapperService.MapRepeatedField<SubjectRelationship, RelationshipResponse>(relationships);
        }
    }
}