using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace DevIO.Api.Configuration
{
    public static class ApiConfig
    {

        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                    {
                        builder.AllowAnyOrigin().
                        AllowAnyHeader().
                        AllowAnyMethod().
                        AllowCredentials();
                    });

                options.AddPolicy("Production",
                   builder =>
                   {
                       builder.WithOrigins("https://meudominioprod.com.br")
                       .WithMethods("GET")
                       .SetIsOriginAllowedToAllowWildcardSubdomains()
                       //.WithHeaders(HeaderNames.ContentType,"x-custom-header")
                       .AllowAnyMethod();
                   });

            });

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
            return app;
        }
    }
}
