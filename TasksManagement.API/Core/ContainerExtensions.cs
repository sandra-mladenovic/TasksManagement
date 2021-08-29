using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TasksManagement.Application;
using TasksManagement.Application.Commands;
using TasksManagement.Application.Email;
using TasksManagement.Application.Queries;
using TasksManagement.Implementation.Commands;
using TasksManagement.Implementation.Email;
using TasksManagement.Implementation.Logging;
using TasksManagement.Implementation.Queries;
using TasksManagement.Implementation.Validators;

namespace TasksManagement.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<UpsertProjectValidator>();
            services.AddTransient<UpsertUserValidator>();
            services.AddTransient<UpsertAssignmentValidator>();
            services.AddTransient<UpsertRoleValidator>();
            services.AddTransient<UpsertStatusTypeValidator>();

            services.AddTransient<ICreateProjectCommand, CreateProjectCommand>();
            //services.AddTransient<IDeleteProjectCommand, DeleteProjectCommand>();
            services.AddTransient<IGetProjectsQuery, GetProjectsQuery>();
            services.AddTransient<IGetOneProjectQuery, GetOneProjectQuery>();
            services.AddTransient<IUpdateProjectCommand, UpdateProjectCommand>();

            services.AddTransient<IGetUsersQuery, GetUsersQuery>();
            services.AddTransient<IGetOneUserQuery, GetOneUserQuery>();

            services.AddTransient<IGetRolesQuery, GetRolesQuery>();
            services.AddTransient<IGetStatusTypesQuery, GetStatusTypesQuery>();
            services.AddTransient<ICreateRoleCommand, CreateRoleCommand>();
            services.AddTransient<ICreateStatusTypeCommand, CreateStatusTypeCommand>();
            services.AddTransient<IUpdateRoleCommand, UpdateRoleCommand>();
            services.AddTransient<IUpdateStatusTypeCommand, UpdateStatusTypeCommand>();
            services.AddTransient<IDeleteStatusTypeCommand, DeleteStatusTypeCommand>();
            services.AddTransient<IDeleteRoleCommand, DeleteRoleCommand>();

            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IGetUseCaseLogQuery, GetUseCaseLogQuery>();

            services.AddTransient<IGetAssigmnentsQuery, GetAssignmentsQuery>();
            services.AddTransient<ICreateAssignmentCommand, CreateAssignmentCommand>();
            services.AddTransient<IUpdateAssignmentCommand, UpdateAssignmentCommand>();
            services.AddTransient<IDeleteAssignmentCommand, DeleteAssignmentCommand>();

            services.AddTransient<IApplicationActor, FakeApiActor>();

            services.AddTransient<IUseCaseLogger, LoggUseCaseDatabase>();
            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddTransient<UseCaseExecutor>();

        }

        public static void AddApplicationActor(this IServiceCollection services)
        {

            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AdminFakeApiActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }

        public static void AddJwt(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        }
    }
}
