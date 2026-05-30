using Microsoft.Extensions.Logging;
using ProductosAppQ22026.Services;
using ProductosAppQ22026.ViewModels;
using ProductosAppQ22026.Views;

namespace ProductosAppQ22026;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

			// Una sola conexion a la DB
			builder.Services.AddSingleton<ProductoService>();

			// Transient
			builder.Services.AddTransient<ProductoViewModel>();
			builder.Services.AddTransient<ProductosPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
