using Telegram.Bot;
using Telegram.Bot.Types;

namespace PhotoBot.Commands;

public class HelloCommand : ICommand
{
    public string Command => "/hello";
    public async Task ExecuteAsync(Message message, ITelegramBotClient botClient)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"Привет, {message.Chat.FirstName} {message.Chat.LastName}!\n" +
                  $"Хочешь посмотреть изумительные фоточки? Дерзай! \n" +
                  $"Пример: /photo forest");
    }
}