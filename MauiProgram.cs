using GuevaraExamenProg3.Interfaces;
using GuevaraExamenProg3.Services;
using GuevaraExamenProg3.ViewModels;
using GuevaraExamenProg3.Views;
using Microsoft.Extensions.Logging;

namespace GuevaraExamenProg3
{
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
            //inyecto dependencias
            builder.Services.AddSingleton<IRecetaService, RecetaService>();
            builder.Services.AddSingleton<RecetaViewModel>();

            //inyecto vistas como servicio transitorio para solucionar error en BindingContext
            builder.Services.AddTransient<FormularioRegistroRecetaView>();
            builder.Services.AddTransient<MostrarLogsView>();
            builder.Services.AddTransient<MostrarRegistrosBDView>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
