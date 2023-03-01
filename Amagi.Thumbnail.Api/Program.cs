using Amagi.Thumbnail.Api;
using Amagi.Thumbnail.Api.Mapping;
using Amagi.Thumbnail.BusinessLayer;
using FluentValidation;
using FluentValidation.AspNetCore;
using static Amagi.Thumbnail.Api.ThumbnailMetaModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IValidator<ThumbnailMetaModel>, ThumbnailMetaValidator>();
builder.Services.AddFluentValidationAutoValidation(options => { });
builder.Services.AddControllers();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddServices();

AutoMapper.MapperConfiguration mapperConfiguration = new(mc =>
{
    mc.AddProfile(new ThumbnailProfile());
});
builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();


app.MapControllers();

app.Run();