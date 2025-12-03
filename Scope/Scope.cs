using System.Data.Common;
using PMS.Business.Interface;
using PMS.Business.Services;
using PMS.Repository;

namespace PMS.Scope
{
    public static class PMSScope
    {
        public static void RegisterService(this IServiceCollection services)
        {
            // services.AddScoped<IStoredProcedure, StoredProcedure>();
            services.AddScoped<IStoredProcedureRepository, StoredProcedureRepository>();
            // services.AddScoped<IPMSService, PMSServices>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostsService, PostService>();
            // DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
        }
    }
}