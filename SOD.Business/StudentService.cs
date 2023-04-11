using Sample.Deneme.Core.UnitOfWork;
using SOD.Data;
using SOD.Model;
using AutoMapper;
using Sample.Deneme.Core.Utilities;
using SOD.Core;

namespace SOD.Business
{
    public class StudentService : BusinessService<StudentEntity, StudentModel, IStudentRepository, SampleProjectDbContext, DataResult>, IStudentService
    {
        public StudentService(IUnitOfWork<SampleProjectDbContext, StudentEntity, IStudentRepository> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}