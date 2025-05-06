using CandidateHub.API.Middleware;
using CandidateHub.Application;
using CandidateHub.Infrastructure;
using CandidateHub.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
#region AddDependices

builder.Services.AddInfrastructureDependencies()
    .AddApplicationDependencies();

#endregion

#region AllowCORS
var CORS = "_cors";
_ = builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS,
                      policy =>
                      {
                          _ = policy.AllowAnyHeader();
                          _ = policy.AllowAnyMethod();
                          _ = policy.AllowAnyOrigin();
                      });
});
_ = builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
_ = builder.Services.AddTransient<IUrlHelper>(x =>
{
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});
#endregion
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
_ = app.UseCors(CORS);
app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
