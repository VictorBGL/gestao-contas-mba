using GestaoContas.Api.Configurations;
using GestaoContas.Api.Helpers;
using GestaoContas.Shared.CommonConfigurations;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);




builder
    .AddSharedsConfiguration()
    .AddApiConfiguration()
    .AddSwaggerConfiguration()
    .AddDbContextConfiguration()
    .AddContextConfiguration()
    .AddIdentityConfiguration()
    .ResolveDependencies();



var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerConfig(apiVersionDescriptionProvider);
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseDbMigrationHelper();

app.Run();
