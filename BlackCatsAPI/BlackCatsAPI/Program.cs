using BlackCats_Application;
using BlackCats_Infrastructure;
using BlackCats_Persistance;
using BlackCatsAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
                .AddApiService(builder.Configuration)
                .AddApplicationService(builder.Configuration)
                .AddInfraStructureServices(builder.Configuration)
                .AddPersistanceService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("BCPSWebClientPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
