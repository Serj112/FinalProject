﻿using AutoMapper;
using FinalProject.BLL.RequestModels;
using FinalProject.BLL.Validators;
using FinalProject.Controllers;
using FinalProject.DLL.Interface;
using FinalProject.DLL.Repository;
using FluentValidation;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using NLog.Extensions.Logging;

namespace FinalProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<BlogDB>();
            
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ICommentRepository, CommentRepository>();
            builder.Services.AddTransient<ITagRepository, TagRepository>();
            builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
            builder.Services.AddTransient<IRoleRepository, RoleRepository>();

           
            builder.Services.AddTransient<IValidator<UserRequest>, UserRequestValidator>();
            builder.Services.AddTransient<IValidator<TagRequest>, TagRequestValidator>();
            builder.Services.AddTransient<IValidator<ArticleRequest>, ArticleRequestValidator>();
            builder.Services.AddTransient<IValidator<CommentRequest>, CommentRequestValidator>();
            builder.Services.AddTransient<IValidator<RoleRequest>, RoleRequestValidator>();

            
            builder.Services.AddTransient<UserController, UserController>();
            builder.Services.AddTransient<TagController, TagController>();
            builder.Services.AddTransient<ArticleController, ArticleController>();
            builder.Services.AddTransient<CommentController, CommentController>();
            builder.Services.AddTransient<RoleController, RoleController>();
            builder.Services.AddTransient<IAccountController, AccountController>();

            
            builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
                            .AddCookie("Cookies", options =>
                            {
                                options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                                {
                                    OnRedirectToLogin = redirectContext =>
                                    {
                                        redirectContext.HttpContext.Response.StatusCode = 401;
                                        return Task.CompletedTask;
                                    }
                                };
                            });
            builder.Services.AddHttpContextAccessor();

            // nLog
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddNLog();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Errors/ErrorsRedirect", "?statusCode={0}");
                app.UseExceptionHandler("/Errors/SomethingWrongPage");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }
            if (app.Environment.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Errors/ErrorsRedirect", "?statusCode={0}");
                app.UseExceptionHandler("/Errors/SomethingWrongPage");
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorPages();

            app.Run();

        }
    }
    
}