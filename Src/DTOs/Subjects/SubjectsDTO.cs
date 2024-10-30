using user_microservice.Src.DTOs.Models;

namespace user_microservice.Src.DTOs.Subjects
{
    public class SubjectsDTO : BaseModelDTO
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Department { get; set; } = null!;

        public int Credits { get; set; }

        public int Semester { get; set; }
    }
}