using SOD.Data;
using SOD.Model;
using Sample.Deneme.Core.Business;
using Sample.Deneme.Core.Utilities;

namespace SOD.Business
{
    public interface IStudentService : IBusinessService<StudentEntity, StudentModel, IStudentRepository, SampleProjectDbContext, DataResult>
    {
    }
}