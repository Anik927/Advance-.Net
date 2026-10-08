using FE53728API.Data.Entities;

namespace FE53728API.DTOs
{
    public class CourseDTO
    {

        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int TotalHrs { get; set; }

        public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    }
}
