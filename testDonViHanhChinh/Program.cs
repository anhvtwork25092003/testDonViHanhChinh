using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using testDonViHanhChinh.Data;
using testDonViHanhChinh.Repository;
using testDonViHanhChinh.Repository.impl;
using testDonViHanhChinh.Service;
using testDonViHanhChinh.Service.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("myconn"))
    );

builder.Services.AddScoped<IProvincesService, ProvinceService>();
builder.Services.AddScoped<IProviceRepository, ProviceRepository>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });


builder.Services.AddControllers();
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
