using System.ComponentModel.DataAnnotations;

namespace user_microservice.Src.DTOs.Subjects
{
    public class UpdateUserProgressDTO
    {
        // [RegularExpression(@"^[A-Za-z]{3}-\d{3}$", ErrorMessage = "Invalid format. It should be LLL-NNN.")]
        public List<string> AddSubjects { get; set; } = new();

        // [RegularExpression(@"^[A-Za-z]{3}-\d{3}$", ErrorMessage = "Invalid format. It should be LLL-NNN.")]
        public List<string> DeleteSubjects { get; set; } = new();
    }
}