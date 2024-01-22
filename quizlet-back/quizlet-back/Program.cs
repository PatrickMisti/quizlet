using quizlet_back.Repository;
using quizlet_back.Service;
using Serilog;

const string allowPolicySpecificOrigins = "_allowPolicySpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// add services and db
builder.Services.AddControllers();
builder.Services.AddDbContext<DbDatabase>();
await DbDatabase.CreateDatabase(new DbDatabase());
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IUserService, UserService>();


// Added todo
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

// add todo
// add to use cors functions
app.UseCors(allowPolicySpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
