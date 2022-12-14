using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PhotoBot.Services.CommandService;
using PhotoBot.Services.PhotoService;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);
{
    var configuration = builder.Configuration;
    var token = configuration["Token"];
    var hostingUrl = configuration["Url"];
    
    var telegramBotClient = new TelegramBotClient(token);
    var webHookUrl = hostingUrl + "api/update";
    await telegramBotClient.SetWebhookAsync(webHookUrl);

    builder.Services
        .AddScoped<ICommandService, CommandService>()
        .AddSingleton<IPhotoService, PhotoService>()
        .AddSingleton<ITelegramBotClient>(telegramBotClient)
        .AddHttpClient("photo");
    

    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        var settings = options.SerializerSettings;
        settings.Formatting = Formatting.Indented;
        settings.ContractResolver = new DefaultContractResolver();
    });
}

var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

