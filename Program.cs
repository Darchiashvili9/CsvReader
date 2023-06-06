using ElectricitydataStore.Context;
using ElectricitydataStore.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(connectionString: "Server=(localdb)\\MSSQLLocalDB;Database=QuoteQuiz;MultipleActiveResultSets=True");
});


builder.Services.AddHttpClient();

builder.Services.AddScoped<IElectrycityDataStoreRepository,ElectrycityDataStoreRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
