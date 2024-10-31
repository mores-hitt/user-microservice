using System.Runtime.CompilerServices;
using Google.Protobuf.Collections;
using user_microservice.Src.Protos;
using user_microservice.Src.Models;
using user_microservice.Src.Repositories.Interfaces;
using user_microservice.Src.Services.Interfaces;
using Google.Protobuf;

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

            Console.WriteLine("Subjects: ");
            foreach (var subject in subjects)
            {
                Console.WriteLine(subject.Name + " " + subject.Id);
            }

            return _mapperService.MapRepeatedField<Subject, SubjectResponse>(subjects);
        }


        public async Task<RepeatedField<RelationshipResponse>> GetAllRelationships()
        {
            var relationships = await _unitOfWork.SubjectRelationshipsRepository.Get();
            return _mapperService.MapRepeatedField<SubjectRelationship, RelationshipResponse>(relationships);
        }

        public async Task<MapField<string, PrerequisiteResponse>> GetAllPrerequisites()
        {
            var relationshipsList = await _unitOfWork.SubjectRelationshipsRepository.Get();
            var dictionary = new MapField<string, PrerequisiteResponse>();

            relationshipsList.ForEach(r =>
            {
                if (!dictionary.ContainsKey(r.SubjectCode))
                {
                    var preRequisites = new PrerequisiteResponse();
                    preRequisites.SubjectCode.Add(r.PreSubjectCode);

                    dictionary.Add(r.SubjectCode, preRequisites);
                } else {
                    dictionary[r.SubjectCode].SubjectCode.Add(r.PreSubjectCode);
                }
            });

            return dictionary;
        }

        public async Task<MapField<string, PostRequisiteResponse>> GetAllPostRequisites()
        {
            var relationshipsList = await _unitOfWork.SubjectRelationshipsRepository.Get();
            var dictionary = new MapField<string, PostRequisiteResponse>();

            relationshipsList.ForEach(r => 
            {
                if (!dictionary.ContainsKey(r.PreSubjectCode))
                {
                    var postRequisites = new PostRequisiteResponse();
                    postRequisites.SubjectCode.Add(r.SubjectCode);

                    dictionary.Add(r.PreSubjectCode, postRequisites);
                } else {
                    dictionary[r.PreSubjectCode].SubjectCode.Add(r.SubjectCode);
                }
            });

            return dictionary;
        }
    }
}