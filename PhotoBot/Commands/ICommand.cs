using Telegram.Bot;
using Telegram.Bot.Types;

namespace PhotoBot.Commands;

public interface ICommand
{
    public string Command { get; }

    public Task ExecuteAsync(Message message, ITelegramBotClient botClient);
}