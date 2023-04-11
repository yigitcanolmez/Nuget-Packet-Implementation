using AutoMapper;
using Sample.Deneme.Core.Model;

namespace SOD.Model
{
    public class EntityToModelMapperProfile : Profile
    {
        public EntityToModelMapperProfile()
        {
            CreateMap<BaseEntity, BaseModel>();

            CreateMap<StudentEntity, StudentModel>().IncludeBase<BaseEntity, BaseModel>();
        }
    }
}


