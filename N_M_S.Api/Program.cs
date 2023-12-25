using Application.Shared.Middlewares;
using N_M_S.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
new DependencyResolver(builder.Configuration).Resolve(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
