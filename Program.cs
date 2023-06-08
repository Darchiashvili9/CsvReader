using ElectricitydataStore.Context;
using ElectricitydataStore.Mappings;
using ElectricitydataStore.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(connectionString: "Server=(localdb)\\MSSQLLocalDB;Database=CsvReaderV3;MultipleActiveResultSets=True");
});

builder.Services.AddHttpLogging(opts =>
{
    opts.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestMethod
    | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPath
    | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseStatusCode;
});

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(ElectricityDataModelProfile));

builder.Services.AddScoped<IElectrycityDataStoreRepository, ElectrycityDataStoreRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
