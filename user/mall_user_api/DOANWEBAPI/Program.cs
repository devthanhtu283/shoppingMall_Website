using DOANWEBAPI.Models;
using DOANWEBAPI.Services;
using Microsoft.EntityFrameworkCore;
using DOANWEBAPI.Converters;

//builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
});

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddScoped<shopService, shopServiceImpl>();
builder.Services.AddScoped<productService, productServiceImpl>();
builder.Services.AddScoped<GallaryService, GallaryServiceImpl>();
builder.Services.AddScoped<RoomService, RoomServiceImpl>();
builder.Services.AddScoped<MovieService, MovieServiceImpl>();
builder.Services.AddScoped<TimeSlotService, TimeSlotServiceImpl>();
builder.Services.AddScoped<SeatService, SeatServiceImpl>();
builder.Services.AddScoped<ShowService, ShowServiceImpl>();
builder.Services.AddScoped<TicketService, TicketServiceImpl>();
builder.Services.AddScoped<FeedBackService, FeedBackServiceImpl>();

//app
var app = builder.Build();

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
/*app.UseMiddleware<BasicAuthMiddleware>();
app.UseMiddleware<Log1Middleware>();
app.UseMiddleware<SecurityMiddleware>();
app.UseMiddleware<Log2Middleware>();
app.UseMiddleware<Log3Middleware>();*/
app.MapControllers();
app.UseStaticFiles();
app.Run();
