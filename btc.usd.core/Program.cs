using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.App.Extensions;
using Core.App.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
     .ConfigureApiBehaviorOptions(options =>
     {
         options.SuppressConsumesConstraintForFormFileParameters = true;
         options.SuppressInferBindingSourcesForParameters = true;
         options.SuppressModelStateInvalidFilter = true;
         options.SuppressMapClientErrors = true;
         options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
     });

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
//Swagger as UI
builder.Services.AddSwaggerGen();

//Engine
IEngine engine = builder.Services.ConfigureApplicationServices(builder.Configuration);

//DI
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(diBuilder => engine.RegisterDependencies(diBuilder, builder.Configuration));

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
