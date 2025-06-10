using BattleMapMain.Services;
using BattleMapMain.ViewModels;
using BattleMapMain.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace BattleMapMain
{

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureMauiHandlers(handlers => {

#if ANDROID
                        handlers.AddHandler(typeof(Shell),typeof(BattleMapMain.Platforms.Android.CustomShellRenderer));
				
#endif
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterDataServices()
                .RegisterPages()
                .RegisterViewModels();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();

        }
        public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<RegisterView>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<GameStartView>();
            builder.Services.AddTransient<AllMonstersView>();
            builder.Services.AddTransient<BattleMapView>();
            builder.Services.AddTransient<CharacterSheetsView>();
            builder.Services.AddTransient<SessionView>();
            builder.Services.AddTransient<UserMonstersView>();
            builder.Services.AddTransient<LoadingScreenView>();
            builder.Services.AddTransient<MonsterEditView>();
            builder.Services.AddTransient<CharacterEditView>();
            builder.Services.AddTransient<CharacterStatsView>();
            builder.Services.AddTransient<MonsterStatsView>();
            builder.Services.AddTransient<MonsterAddView>();
            builder.Services.AddTransient<CharacterAddView>();
            builder.Services.AddTransient<MiniPickerView>();
            

            return builder;
        }

        public static MauiAppBuilder RegisterDataServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<BattleMapWebAPIProxy>();
            builder.Services.AddSingleton<BattleMapProxy>();
            return builder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<GameStartViewModel>();
            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<AllMonstersViewModel>();
            builder.Services.AddSingleton<BattleMapViewModel>();
            builder.Services.AddTransient<CharacterSheetsViewModel>();
            builder.Services.AddSingleton<SessionViewModel>();
            builder.Services.AddTransient<MonsterStatsViewModel>();
            builder.Services.AddTransient<UserMonstersViewModel>();
            builder.Services.AddTransient<LoadingScreenViewModel>();
            builder.Services.AddTransient<MonsterEditViewModel>();
            builder.Services.AddTransient<CharacterEditViewModel>();
            builder.Services.AddTransient<CharacterStatsViewModel>();
            builder.Services.AddTransient<MonsterAddViewModel>();
            builder.Services.AddTransient<CharacterAddViewModel>();

            return builder;
        }
    }
}
