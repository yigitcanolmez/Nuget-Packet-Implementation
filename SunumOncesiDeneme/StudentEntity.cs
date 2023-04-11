using Sample.Deneme.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOD.Model
{
    [Table("student")]
    public class StudentEntity : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
