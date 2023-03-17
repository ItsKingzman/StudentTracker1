using System.ComponentModel.DataAnnotations;

namespace StudentTracker1.Context
{
    public class StudentReport
    {
        // The [Key] attribute is used to mark the property as the primary key for the entity, which is
        // required in order for EF Core to track changes to an entity, as well as for ensured uniqueness.
        [Key]

        // This creates a public integer property called Id.
        // The get; and set; methods allow the property to get and set its value.
        public int Id { get; set; }

        // This creates a public string property called Name.
        // The get; and set; methods allow the property to get and set its value.
        public string Name { get; set; }

        // This creates a public string property called Course.
        // The get; and set; methods allow the property to get and set its value.
        public string Course { get; set; }

        // This creates a public integer property called Grade.
        // The get; and set; methods allow the property to get and set its value.
        public int Grade { get; set; }
    }
}
