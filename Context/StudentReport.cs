using System.ComponentModel.DataAnnotations;

namespace StudentTracker1.Context
{
    public class StudentReport
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int Grade { get; set; }
    }
}
