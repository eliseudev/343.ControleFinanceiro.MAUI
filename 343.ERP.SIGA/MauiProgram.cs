using _343.ERP.SIGA.Repositories;
using _343.ERP.SIGA.Views;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace _343.ERP.SIGA;

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
			})
			.RegisterDataBaseRepository()
			.RegisterViews();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterDataBaseRepository(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<LiteDatabase>(options =>
		{
			return new LiteDatabase($"Filename={AppSettings.DatabasePath};Connection=Shared");
		});

		builder.Services.AddTransient<ITransactionRepository, TransactionRepository>().Reverse();

		return builder;
	}

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<TransactionAdd>();
		mauiAppBuilder.Services.AddTransient<TransactionEdit>();
		mauiAppBuilder.Services.AddTransient<TransactionList>();

        return mauiAppBuilder;
    }
}

