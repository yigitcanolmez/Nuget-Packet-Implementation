 using Deneme.Authorization.Nuget.AuthMapper.Abstraction;
using Deneme.Authorization.Nuget.AuthMapper.Concretion;
using Deneme.Authorization.Nuget.Business.Abstraction;
using Deneme.Authorization.Nuget.Business.Concretion;
using Deneme.Authorization.Nuget.Business.Utilities.AppSettings;
using Deneme.Authorization.Nuget.Data.Concretion;
using Deneme.Authorization.Nuget.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Deneme.Core.Data;
using Sample.Deneme.Core.UnitOfWork;
using SOD.Data;
using SOD.Model;
using Deneme.Authorization.Nuget.Business.Utilities.AuthorizeHelpers;
using Deneme.Authorization.Nuget.Business.Utilities.Session;

namespace SOD.Business
{
    public static class ConfigureContainerExtensions
    {
        public static IServiceCollection AddContainerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IPersonnelService, PersonnelService<SampleProjectDbContext>>();
            services.AddScoped<IPersonnelRoleService, PersonnelRoleService<SampleProjectDbContext>>();
            services.AddScoped<IRoleService<SampleProjectDbContext>, RoleService<SampleProjectDbContext>>();
            services.AddScoped<IPrivilegeService, PrivilegeService<SampleProjectDbContext>>();
            services.AddScoped<IRolePrivilegeService, RolePrivilegeService<SampleProjectDbContext>>();
            services.AddScoped<IAuthorizeService<SampleProjectDbContext>, AuthorizeService<SampleProjectDbContext>>();
            services.AddScoped<IAuthMapper, AuthMapper>();

            services.AddScoped(typeof(IRepositoryBase<StudentEntity>), typeof(StudentRepository));
            services.AddScoped(typeof(IRepositoryBase<PersonnelEntity>), typeof(PersonnelRepository<SampleProjectDbContext>));
            services.AddScoped(typeof(IRepositoryBase<PersonnelRoleEntity>), typeof(PersonnelRoleRepository<SampleProjectDbContext>));
            services.AddScoped(typeof(IRepositoryBase<RoleEntity>), typeof(RoleRepository<SampleProjectDbContext>));
            services.AddScoped(typeof(IRepositoryBase<RolePrivilegeEntity>), typeof(RolePrivilegeRepository<SampleProjectDbContext>));
            services.AddScoped(typeof(IRepositoryBase<PrivilegeEntity>), typeof(PrivilegeRepository<SampleProjectDbContext>));

            services.AddAutoMapper(typeof(EntityToModelMapperProfile));
            services.AddAutoMapper(typeof(ModelToEntityMapperProfile));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            IConfigurationSection? sampleSection = configuration.GetSection("SampleSettings");

            services.Configure<Settings>(configuration.GetSection("SampleSettings"));

            services.AddScoped(typeof(IUnitOfWork<,,>), typeof(UnitOfWork<,,>));

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<SessionManager>();

            services.AddOptions();

            services.AddScoped(typeof(TokenHelper));

            return services;
        }
    }
}