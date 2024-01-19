using FoodieFam_Back.DTOs;
using FoodieFam_Back.Models;
using FoodieFam_Back.Repository;
using FoodieFam_Back.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKeyedScoped<ICommonGuidService<UserDto, UserInsertDto, UserPutDto>, UserService>("userService");
builder.Services.AddKeyedScoped<ICommonIntService<IngredientTypeDto, IngredientTypeInsertDto, IngredientTypePutDto>, IngredientTypeService>("ingredientTypeService");
builder.Services.AddScoped<IngredientService>();
builder.Services.AddScoped<UserIngredientService>();
//Repository
builder.Services.AddScoped<IRepositoryGuid<User>, UserRepository>();
builder.Services.AddScoped<IRepositoryInt<IngredientType>, IngredientTypeRepository>();
builder.Services.AddScoped<IngredientRepository>();
builder.Services.AddScoped<UserIngredientRepository>();
//Services


//conection with sql server
builder.Services.AddDbContext<FoodieFamContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodieFamConnection"));
});

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
