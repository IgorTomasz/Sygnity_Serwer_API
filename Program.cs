using CountNextTaskDate.Repositories;
using CountNextTaskDate.Services;
using Microsoft.EntityFrameworkCore;

namespace CountNextTaskDate
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  policy =>
								  {
									  policy.WithOrigins("http://localhost:3000");
								  });
				options.AddPolicy("AllowAllHeaders",
								  builder =>
								  {
									  builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
								  });
			});

			builder.Services.AddControllers();
			builder.Services.AddScoped<INextTaskRepository, NextTaskRepository>();
			builder.Services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
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

			app.UseCors("AllowAllHeaders");

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}