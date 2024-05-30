using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Persistence.Repositories;
using CarBook.Application.Services;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Persistence.Repositories.CarPricingRepositories;


var builder = WebApplication.CreateBuilder(args);

// About icin handlerlarin eklenmesi
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();

//Banner icin handlerlarin eklenmesi
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();

//Brand icin handlerlarin eklenmesi
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

//Car icin handlerlarin eklenmesi
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();

//Category icin handlerlarin eklenmesi
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

//Contact icin handlerlarin eklenmesi
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

//Her bir Sýnýf için handlerlari tek tek eklememek icin bu sekilde ekledik.
builder.Services.AddApplicationServices(builder.Configuration);


builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));

builder.Services.AddDbContext<CarBookContext>();

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
