using NetConf.ConfClasses;
using NetConf.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<TennacyService>();
builder.Services.AddTransient<ExampleServices>();

//Configure appsettings.json IOptions
//Class ve json dosyasý ayný isimde olmalý ayný zamanda property isimleri de ayný olmalý
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.Configure<ExampleConf>(builder.Configuration.GetSection("ExampleConf"));

//more json file
//IConfiguration configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
// OR

builder.Configuration.AddJsonFile("example.json", optional: false, reloadOnChange: true);

//// Use ConfigurationBuilder to add both JSON files
//var configuration = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//    .AddJsonFile("example.json", optional: false, reloadOnChange: true)
//    .Build();

//configuration.GetSection("DbSettings").Bind(builder.Configuration.GetSection("DbSettings"));
//configuration.GetSection("ExampleConf").Bind(builder.Configuration.GetSection("ExampleConf"));

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
