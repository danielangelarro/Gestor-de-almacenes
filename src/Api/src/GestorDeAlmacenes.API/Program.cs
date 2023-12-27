using GestorDeAlmacenes.Application;
using GestorDeAlmacenes.Infrastructure;
using GestorDeAlmacenes.API.Authentication;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)

        .ConfigureAutheticationServices(builder.Configuration)
        .SwaggerDocumentatiobService();
    
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyPolicy",
            builder =>
            {
                builder.WithOrigins("http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(origin => true)
                        .AllowCredentials();
            });
    });

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseCors("MyPolicy");

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseStatusCodePages();
    
    app.Run();
}