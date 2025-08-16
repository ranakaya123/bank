using Bank.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using Bank.Application.Services;
using Bank.Persistence.Services;
using Bank.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add HttpContextAccessor for AuthorizationBehavior
builder.Services.AddHttpContextAccessor();

        // Add Swagger/OpenAPI
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Bank API",
                Version = "v1",
                Description = "Bankacılık uygulaması için REST API",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Bank Development Team",
                    Email = "dev@bank.com"
                }
            });
            
            // Enum değerlerini Swagger'da göster
            c.UseInlineDefinitionsForEnums();
        });

// Add Core Services (Security, Application)
builder.Services.AddCoreServices();

// Add Application Services (MediatR, AutoMapper, Business Rules)
builder.Services.AddApplicationServices();

// Add Persistence Services (DbContext, Repositories)
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank API v1");
                c.RoutePrefix = string.Empty; // Swagger UI'ı root'ta göster
                c.DocumentTitle = "Bank API - Kredi Sistemi";
            });
        }

// HTTPS yönlendirmesini aktif et
app.UseHttpsRedirection();

// Custom Exception Middleware
app.UseCustomExceptionMiddleware();

app.MapControllers();

app.Run();


