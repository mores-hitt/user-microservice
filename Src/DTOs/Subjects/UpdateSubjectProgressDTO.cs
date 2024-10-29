using System.ComponentModel.DataAnnotations;

namespace user_microservice.Src.DTOs.Subjects
{
    public class UpdateSubjectProgressDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int SubjectId { get; set; }

        [Required]
        public bool IsAdded { get; set; } = false;
    }
}