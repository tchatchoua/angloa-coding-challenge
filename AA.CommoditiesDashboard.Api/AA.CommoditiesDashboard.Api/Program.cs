using AA.CommoditiesDashboard.DataAccess;
using AA.CommoditiesDashboard.DataAccess.Repositories;
using AA.CommoditiesDashboard.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

var corsPolicyName = "allowAll";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddHealthChecks();
services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName,
        policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

services.AddScoped<DbContext, CommodityContext>();

services.AddDbContext<CommodityContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("CommoditiesDashboard")));

services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IModelService, ModelService>();
services.AddScoped<ICommodityService, CommodityService>();
services.AddScoped<ITradeService, TradeService>();


services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors(corsPolicyName);
app.MapControllers();


app.Run();