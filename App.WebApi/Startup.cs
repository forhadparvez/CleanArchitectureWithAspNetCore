using App.Application.Infrastructure;
using App.Application.Infrastructure.AutoMapper;
using App.Application.Interfaces;
using App.Application.Students.Commands.CreateStudent;
using App.Application.Students.Commands.DeleteStudent;
using App.Application.Students.Commands.UpdateStudent;
using App.Application.Students.Queries.GetStudentDetail;
using App.Application.Students.Queries.GetStudentList;
using App.Common;
using App.Infrastructure;
using App.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.WebApi
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
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            // Add MediatR
            services.AddMediatR(typeof(CreateStudentCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateStudentCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteStudentCommand).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetAllStudentQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetStudentDetailQuery).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Add DbContext using SQL Server Provider
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDatabase")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
