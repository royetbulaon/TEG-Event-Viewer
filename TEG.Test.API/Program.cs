using TEG.Test.Application.Services;
using TEG.Test.Domain.Interface;
using TEG.Test.Infrastracture;

namespace TEG.Test.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Disable CORS (allow everything)
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
					policy =>
					{
						policy.AllowAnyOrigin()
							  .AllowAnyHeader()
							  .AllowAnyMethod();
					});
			});

			// Register HttpClientFactory for external API calls
			builder.Services.AddHttpClient();

			// Register repository (singleton for in-memory + file source of truth)
			builder.Services.AddSingleton<IEventRepository, EventRepository>();

			// Register application services (scoped per request)
			builder.Services.AddScoped<IEventService, EventService>();
			// Add services to the container.

			builder.Services.AddControllers();

			var app = builder.Build();

			// Configure the HTTP request pipeline.


			app.UseHttpsRedirection();
			app.UseCors("AllowAll");
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
