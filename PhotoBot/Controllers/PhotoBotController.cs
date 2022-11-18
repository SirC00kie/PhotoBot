using Microsoft.AspNetCore.Mvc;
using PhotoBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PhotoBot.Controllers;

public class PhotoBotController : ControllerBase
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly ICommandService _commandService;
    
    public PhotoBotController(ITelegramBotClient telegramBotClient, ICommandService commandService)
    {
        _telegramBotClient = telegramBotClient;
        _commandService = commandService;
    }

    public async Task<IActionResult> Update(Update update)
    {
        var message = update.Message;

        if (message != null)
        {
            var command = _commandService.Execute(message);
            await command.ExecuteAsync(message, _telegramBotClient);
        }

        return Ok("");
    }
}