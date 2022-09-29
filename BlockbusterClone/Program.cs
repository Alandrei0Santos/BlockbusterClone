using BlockbusterClone.Models;
using BlockbusterClone.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/* Get appsettings.json 'BlockbusterDatabaseSettings' section and
 * map it down to BlockbusterDatabaseSettings class
 */
builder.Services.Configure<BlockbusterDatabaseSettings>(
    builder.Configuration.GetSection(nameof(BlockbusterDatabaseSettings))
);

builder.Services.AddSingleton<IBlockbusterDatabaseSettings>(
    sp => sp.GetRequiredService<IOptions<BlockbusterDatabaseSettings>>().Value
);


/* Specifies where MongoClient has to get the connection string from
 * in order to communicate with the database
 */
builder.Services.AddSingleton<IMongoClient>(
    s => new MongoClient(
        builder.Configuration.GetValue<string>("BlockbusterDatabaseSettings:ConnectionString")
    )
);

// Links 'BlockbusterServices' class with its interface
 
builder.Services.AddScoped<IBlockbusterServices, BlockbusterServices>();

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
