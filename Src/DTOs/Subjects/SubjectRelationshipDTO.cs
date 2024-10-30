using user_microservice.Src.DTOs.Models;

namespace user_microservice.Src.DTOs.Subjects
{
    public class SubjectRelationshipDto : BaseModelDTO
    {
        public string SubjectCode { get; set; } = null!;
        
        public string PreSubjectCode { get; set; } = null!;
    }
}