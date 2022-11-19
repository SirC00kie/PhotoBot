using Telegram.Bot;
using Telegram.Bot.Types;

namespace PhotoBot.Commands;

public class BaseCommand : ICommand
{
    public string Command => string.Empty;
    public async Task ExecuteAsync(Message message, ITelegramBotClient botClient)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "/hello - Братишка-бот поприветствует тебя \n" +
                  "/photo - Найти фотографию по введеному запросу \n" +
                  "Пример: /photo forest");
    }
}