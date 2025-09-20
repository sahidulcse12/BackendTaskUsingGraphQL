using BackendTaskUsingGraphQL.Data;
using BackendTaskUsingGraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5174") // your frontend URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add GraphQL server
builder.Services
    .AddGraphQLServer()
    .AddQueryType<TaskQuery>()
    .AddMutationType<TaskMutation>()
    .AddType<TaskType>();

var app = builder.Build();


// 👇 Apply migrations automatically at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}
// Use CORS
app.UseCors("AllowFrontend");

app.MapGraphQL(); // GraphQL endpoint at /graphql

app.Run();
