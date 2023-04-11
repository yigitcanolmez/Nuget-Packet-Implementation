using AutoMapper;
using Sample.Deneme.Core.Model;

namespace SOD.Model
{
    public class ModelToEntityMapperProfile : Profile
    {
        public ModelToEntityMapperProfile()
        {
            CreateMap<BaseModel, BaseEntity>();

            CreateMap<StudentModel, StudentEntity>().IncludeBase<BaseModel, BaseEntity>();
        }
    }
}


