using FoodieFam_Back.DTOs.IngredientTypeDto;
using FoodieFam_Back.DTOs.UserDto;
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
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<RecipeService>();

//Repository
builder.Services.AddScoped<IRepositoryGuid<User>, UserRepository>();
builder.Services.AddScoped<IRepositoryInt<IngredientType>, IngredientTypeRepository>();
builder.Services.AddScoped<IngredientRepository>();
builder.Services.AddScoped<UserIngredientRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<RecipeRepository>();


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
