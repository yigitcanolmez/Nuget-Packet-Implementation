using Sample.Deneme.Core.Data;
using SOD.Model;

namespace SOD.Data
{
    public class StudentRepository : EFRepositoryBase<StudentEntity>, IStudentRepository
    {
        public StudentRepository(SampleProjectDbContext sampleProjectDbContext) : base(sampleProjectDbContext)
        {
        }
    }
}
