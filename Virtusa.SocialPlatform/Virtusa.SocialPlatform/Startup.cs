using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Virtusa.SocialPlatform.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Data;
using Virtusa.SocialPlatform.Business;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Common.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Virtusa.SocialPlatform.Auth;

namespace Virtusa.SocialPlatform
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server=(localdb)\mssqllocaldb;Database=SocialPlatform;Trusted_Connection=True;";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddEntityFrameworkSqlServer()
               .AddEntityFrameworkSqlServer()
               .AddDbContext<SampleContext>(options => options.UseSqlServer(
                connection,
                sql => sql.MigrationsAssembly(migrationsAssembly)
                ));

            services.AddScoped<ISampleDataAccess, SampleDataAccess>();
            services.AddScoped<ISampleBusiness, SampleBusiness>();
            services.AddScoped<INewsBusiness, NewsBusiness>();
            services.AddScoped<INewsDataAccess, NewsDataAccess>();
            services.AddScoped<IOrderDataAccess, OrderDataAccess>();
            services.AddScoped<IOrderBussiness, OrderBusiness>();
            services.AddScoped<ICompetitionDataAccess, CompetitionDataAccess>();
            services.AddScoped<ICompetitionBusiness, CompetitionBusiness>();
            services.AddScoped<IRegistrationsBusiness, RegistrationsBusiness>();
            services.AddScoped<IRegistrationsDataAccess, RegistrationsDataAccess>();
            services.AddScoped<ISessionBusiness, SessionBusiness>();
            services.AddScoped<ISessionDataAccess, SessionDataAccess>();
            services.AddScoped<IAttendanceBusiness, AttendanceBusiness>();
            services.AddScoped<IAttendanceDataAccess, AttendanceDataAccess>();
            services.AddScoped<IExcellExportBusiness, ExcellExportBusiness>();
            services.AddScoped<IExcelExxportDataAccess, ExcelExxportDataAccess>();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            // Enable the use of an [Authorize("Bearer")] attribute on methods and classes to protect.
            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            //        .RequireAuthenticatedUser().Build());
            //});

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Audience = "http://localhost:5001/";
                options.Authority = "http://localhost:5000/";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMissingTypeMaps = true;
                config.AllowNullCollections = true;
                config.AllowNullDestinationValues = true;
                config.CreateMap<IEnumerable<TiersModel>, List<Tiers>>();
                config.CreateMap<IEnumerable<CegsModel>, List<Cegs>>();
                config.CreateMap<IEnumerable<CompetitionModel>, List<Competition>>();
                config.CreateMap<IEnumerable<SessionModel>, List<Session>>();
                config.CreateMap<IEnumerable<AttendanceModel>, List<Attendance>>();
            });

            #region Auth

            #region Handle Exception

            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;

                    //when authorization has failed, should retrun a json message to client
                    if (error != null && error.Error is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResult
                        {
                            State = RequestState.NotAuth,
                            Msg = "token expired"
                        }));
                    }
                    //when orther error, retrun a error message json to client
                    else if (error != null && error.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new RequestResult
                        {
                            State = RequestState.Failed,
                            Msg = error.Error.Message
                        }));
                    }
                    //when no error, do next.
                    else await next();
                });
            });
            #endregion

            #region UseJwtBearerAuthentication

            app.UseAuthentication();

            #endregion

            #endregion


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
