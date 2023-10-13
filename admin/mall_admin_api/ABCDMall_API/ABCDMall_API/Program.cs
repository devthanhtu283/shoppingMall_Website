using ABCDMall_API.Models;
using ABCDMall_API.Services;
using Microsoft.EntityFrameworkCore;
using ABCDMall_API.Converters;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddControllers();

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies()
.UseSqlServer(connectionString));

builder.Services.AddScoped<StoreService, StoreServiceImpl>();
builder.Services.AddScoped<CategoryService, CategoryServiceImpl>();
builder.Services.AddScoped<ProductService, ProductServiceImpl>();
builder.Services.AddScoped<FeedBackService, FeedBackServiceImpl>();
builder.Services.AddScoped<GalleryService, GalleryServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();

builder.Services.AddScoped<MovieService, MovieServiceImpl>();
builder.Services.AddScoped<RoomService, RoomServiceImpl>();
builder.Services.AddScoped<ShowService, ShowServiceImpl>();
builder.Services.AddScoped<TimeSlotService, TimeSlotServiceImpl>();
builder.Services.AddScoped<TicketService, TicketServiceImpl>();
builder.Services.AddScoped<SeatService, SeatServiceImpl>();

var app = builder.Build();

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

//app.UseMiddleware<BasicAuthMiddleware>();

app.UseStaticFiles();

app.MapControllers();

app.Run();
